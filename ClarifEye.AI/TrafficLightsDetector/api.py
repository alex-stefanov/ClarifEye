from fastapi import FastAPI, File, UploadFile
from fastapi.responses import JSONResponse
import uvicorn
import numpy as np
from PIL import Image
import io
import tensorflow as tf

app = FastAPI()

model = tf.keras.models.load_model('model_and_weights.keras')

CLASS_MAP = {0: 'backside', 1: 'green', 2: 'red', 3: 'yellow'}

def preprocess_image(image: Image.Image) -> np.ndarray:
    """
    Preprocess a PIL Image:
    - Resize to (32, 32)
    - Normalize pixels to [-1, 1]
    - Add batch dimension
    """
    image = image.resize((32, 32))
    img_array = np.array(image).astype(np.float32)
    img_array = (img_array / 127.5) - 1.0
    img_array = np.expand_dims(img_array, axis=0)
    return img_array

def predict_from_image_bytes(image_bytes: bytes):
    """
    Given raw image bytes, open and preprocess the image,
    then run the model prediction and return class index and label.
    """
    image = Image.open(io.BytesIO(image_bytes)).convert('RGB')
    processed_img = preprocess_image(image)
    prediction = model.predict(processed_img, verbose=0)
    predicted_class = int(np.argmax(prediction, axis=1)[0])
    color = CLASS_MAP.get(predicted_class, 'unknown')
    return predicted_class, color

@app.post("/predict")
async def predict_traffic_light(file: UploadFile = File(...)):
    try:
        image_bytes = await file.read()
        predicted_class, color = predict_from_image_bytes(image_bytes)
        return JSONResponse(content={
            "predicted_class": predicted_class,
            "color": color
        })
    except Exception as e:
        return JSONResponse(status_code=500, content={"error": str(e)})

if __name__ == "__main__":
    uvicorn.run(app, host="0.0.0.0", port=8000)
