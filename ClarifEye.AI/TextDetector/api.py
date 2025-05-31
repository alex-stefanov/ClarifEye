from fastapi import FastAPI, UploadFile, File
from textDetector import extract_text
import uvicorn

app = FastAPI()

@app.post("/text/detect")
async def detect_text_endpoint(file: UploadFile = File(...)):
    contents = await file.read()
    result = extract_text(contents)
    return result

if __name__ == "__main__":
    uvicorn.run("api:app", host="127.0.0.1", port=8000, reload=True)