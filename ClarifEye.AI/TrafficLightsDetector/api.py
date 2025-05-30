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

def preprocess_image(image_bytes):
    image = Image.open(io.BytesIO(image_bytes)).convert('RGB')
    image = image.resize((32, 32))
    img_array = np.array(image).astype(np.float32)
    img_array = (img_array / 127.5) - 1.0
    img_array = np.expand_dims(img_array, axis=0)
    return img_array

@app.post("/predict")
async def predict_traffic_light(file: UploadFile = File(...)):
    try:
        image_bytes = await file.read()
        processed_img = preprocess_image(image_bytes)
        prediction = model.predict(processed_img)
        predicted_class = np.argmax(prediction, axis=1)[0]
        
        return JSONResponse(content={
            "predicted_class": int(predicted_class),
            "color": CLASS_MAP.get(predicted_class, "unknown")
        })
    except Exception as e:
        return JSONResponse(status_code=500, content={"error": str(e)})

if __name__ == "__main__":
    uvicorn.run(app, host="0.0.0.0", port=8000)
