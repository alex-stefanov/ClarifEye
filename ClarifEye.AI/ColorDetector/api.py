import io
from fastapi import FastAPI, File, UploadFile
from fastapi.responses import JSONResponse
from PIL import Image
import torch
import torch.nn as nn
from torchvision import transforms
from colorDetector import ColorClassifier 
import os

# --- Configuration ---
MODEL_PATH = 'color_classifier.pth'
DEVICE = torch.device("cuda" if torch.cuda.is_available() else "cpu")
IMAGE_SIZE = (224, 224)
DATA_DIR = './train'
colors = os.listdir(DATA_DIR)
color_to_label = {color: idx for idx, color in enumerate(colors)}
label_to_color = {idx: color for color, idx in color_to_label.items()}

# --- Load model ---
model = ColorClassifier().to(DEVICE)
model.load_state_dict(torch.load(MODEL_PATH, map_location=DEVICE))
model.eval()

# --- Image transforms ---
transform = transforms.Compose([
    transforms.Resize(IMAGE_SIZE),
    transforms.ToTensor(),
    transforms.Normalize(mean=[0.485, 0.456, 0.406],
                         std=[0.229, 0.224, 0.225]),
])

app = FastAPI()

@app.post("/color/detect")
async def predict(file: UploadFile = File(...)):
    try:
        contents = await file.read()
        image = Image.open(io.BytesIO(contents)).convert("RGB")
        image_tensor = transform(image).unsqueeze(0).to(DEVICE)

        with torch.no_grad():
            outputs = model(image_tensor)
            predicted_idx = outputs.argmax(dim=1).item()
            predicted_color = label_to_color[predicted_idx]

        return JSONResponse(content={"prediction": predicted_color})
    except Exception as e:
        return JSONResponse(content={"error": str(e)}, status_code=500)
