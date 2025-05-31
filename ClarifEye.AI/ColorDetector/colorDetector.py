import os
import random
from PIL import Image
import numpy as np
import matplotlib.pyplot as plt
from tqdm import tqdm

import torch
import torch.nn as nn
from torch.utils.data import Dataset, DataLoader, random_split
from torchvision import transforms
from torchsummary import summary

# --- Config ---
DATA_DIR = './train'
BATCH_SIZE = 64
EPOCHS = 20  # Changed to 20
VAL_RATIO = 0.1
TEST_SIZE = 30
DEVICE = torch.device("cuda" if torch.cuda.is_available() else "cpu")
MODEL_PATH = 'color_classifier.pth'

# --- Prepare data labels ---
colors = os.listdir(DATA_DIR)
num_labels = len(colors)
color_to_label = {color: idx for idx, color in enumerate(colors)}
label_to_color = {idx: color for idx, color in enumerate(colors)}

print(f"Found colors: {colors}")
print(f"Number of labels: {num_labels}")
print(f"Color to label mapping: {color_to_label}")

# --- Image loader with transforms ---
class ImageLoader:
    def __init__(self):
        self.transform = transforms.Compose([
            transforms.Resize((224, 224)),
            transforms.ToTensor(),
            transforms.Normalize(mean=[0.485, 0.456, 0.406],
                                 std=[0.229, 0.224, 0.225]),
        ])
        
    def load(self, img_path):
        img = Image.open(img_path).convert('RGB')
        return self.transform(img)

# --- Dataset ---
class ImageDataset(Dataset):
    def __init__(self, image_loader):
        self.data_dir = DATA_DIR
        self.data = []
        for color in tqdm(colors, desc="Loading images"):
            image_fnames = [f for f in os.listdir(f'{self.data_dir}/{color}') if not f.startswith('.')]
            for img_fname in image_fnames:
                img_path = f'{self.data_dir}/{color}/{img_fname}'
                t_img = image_loader.load(img_path)
                label = color_to_label[color]
                self.data.append((img_path, t_img, label))

    def __len__(self):
        return len(self.data)
    
    def __getitem__(self, idx):
        return self.data[idx]

# --- Model ---
class ColorClassifier(nn.Module):
    def __init__(self):
        super(ColorClassifier, self).__init__()
        self.conv1 = nn.Sequential(
            nn.Conv2d(3, 64, kernel_size=4, stride=2, padding=1),
            nn.MaxPool2d(kernel_size=4, stride=4),
            nn.BatchNorm2d(64),
            nn.ReLU(),
            nn.Dropout2d(0.3),
        )
        self.conv2 = nn.Sequential(
            nn.Conv2d(64, 128, kernel_size=2, stride=2, padding=1),
            nn.MaxPool2d(kernel_size=3, stride=3),
            nn.BatchNorm2d(128),
            nn.ReLU(),
            nn.Dropout2d(0.3),
        )
        self.conv3 = nn.Sequential(
            nn.Conv2d(128, 256, kernel_size=2, stride=1, padding=1),
            nn.MaxPool2d(kernel_size=6, stride=1),
            nn.BatchNorm2d(256),
            nn.ReLU(),
            nn.Dropout2d(0.3),
        )
        self.fc1 = nn.Sequential(
            nn.Flatten(),
            nn.Linear(256 * 1 * 1, 512),
            nn.ReLU(),
            nn.Dropout(0.3),
        )
        self.fc2 = nn.Sequential(
            nn.Linear(512, 256),
            nn.ReLU(),
            nn.Dropout(0.3),
        )
        self.fc3 = nn.Linear(256, num_labels)
        
    def forward(self, x):
        x = self.conv1(x)
        x = self.conv2(x)
        x = self.conv3(x)
        x = self.fc1(x)
        x = self.fc2(x)
        x = self.fc3(x)
        return x

# --- Training and evaluation ---
def train(model, criterion, optimizer, data_loader):
    model.train()
    train_loss, total, corrects = 0, 0, 0
    for _, inputs, labels in tqdm(data_loader, desc="Training"):
        inputs = inputs.to(DEVICE)
        labels = labels.to(DEVICE)
        optimizer.zero_grad()
        outputs = model(inputs)
        loss = criterion(outputs, labels)
        train_loss += loss.item()
        preds = outputs.argmax(dim=1)
        total += inputs.size(0)
        corrects += (preds == labels).sum().item()
        loss.backward()
        optimizer.step()
    train_loss /= len(data_loader)
    train_accuracy = corrects / total
    return train_loss, train_accuracy

def evaluate(model, criterion, data_loader):
    model.eval()
    val_loss, total, corrects = 0, 0, 0
    with torch.no_grad():
        for _, inputs, labels in tqdm(data_loader, desc="Evaluating"):
            inputs = inputs.to(DEVICE)
            labels = labels.to(DEVICE)
            outputs = model(inputs)
            loss = criterion(outputs, labels)
            val_loss += loss.item()
            preds = outputs.argmax(dim=1)
            total += inputs.size(0)
            corrects += (preds == labels).sum().item()
    val_loss /= len(data_loader)
    val_accuracy = corrects / total
    return val_loss, val_accuracy

# --- Main ---
def main():
    print(f"Using device: {DEVICE}")
    image_loader = ImageLoader()
    dataset = ImageDataset(image_loader)
    
    val_size = int(len(dataset) * VAL_RATIO)
    train_size = len(dataset) - (val_size + TEST_SIZE)
    train_dataset, val_dataset, test_dataset = random_split(dataset, [train_size, val_size, TEST_SIZE])

    train_loader = DataLoader(train_dataset, batch_size=BATCH_SIZE, shuffle=True)
    val_loader = DataLoader(val_dataset, batch_size=BATCH_SIZE, shuffle=True)
    test_loader = DataLoader(test_dataset, batch_size=TEST_SIZE, shuffle=False)

    model = ColorClassifier().to(DEVICE)

    # Load previous model if exists
    if os.path.exists(MODEL_PATH):
        print(f"Loading saved model from {MODEL_PATH}")
        model.load_state_dict(torch.load(MODEL_PATH))

    print(model)
    summary(model, (3, 224, 224))

    criterion = nn.CrossEntropyLoss().to(DEVICE)
    optimizer = torch.optim.Adam(model.parameters())

    train_losses, val_losses = [], []
    train_accuracies, val_accuracies = [], []

    for epoch in range(EPOCHS):
        print(f"Epoch {epoch + 1}/{EPOCHS}")
        train_loss, train_acc = train(model, criterion, optimizer, train_loader)
        val_loss, val_acc = evaluate(model, criterion, val_loader)

        train_losses.append(train_loss)
        val_losses.append(val_loss)
        train_accuracies.append(train_acc)
        val_accuracies.append(val_acc)

        print(f"Train loss: {train_loss:.4f}, Train accuracy: {train_acc:.4f}")
        print(f"Val loss: {val_loss:.4f}, Val accuracy: {val_acc:.4f}")

    # Save the trained model at the end
    torch.save(model.state_dict(), MODEL_PATH)
    print(f"Model saved to {MODEL_PATH}")

if __name__ == "__main__":
    main()
