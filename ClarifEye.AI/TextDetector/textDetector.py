import easyocr
from typing import Union

reader = easyocr.Reader(['en'], gpu=False)

def extract_text(image_path: Union[str, bytes]) -> str:
    results = reader.readtext(image_path)
    text = ' '.join([text for _, text, _ in results])
    return text
