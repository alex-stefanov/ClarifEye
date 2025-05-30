import os
import time
import numpy as np
import tensorflow as tf
from tensorflow.keras import Sequential, Model
from tensorflow.keras.layers import Conv2D, BatchNormalization, Flatten, Dense, Dropout, MaxPooling2D
from tensorflow.keras.optimizers import Adam
from tensorflow.keras.losses import SparseCategoricalCrossentropy
from tensorflow.keras.callbacks import ModelCheckpoint, EarlyStopping
from tensorflow_datasets import ImageFolder

def resize_image(images: tf.Tensor, new_shape: tuple):
    """Resize and normalize images to [-1, 1]."""
    images = tf.cast(images, tf.float32)
    images = (images / 127.5) - 1.0
    images = tf.image.resize(images, size=new_shape)
    return images

def augment_image(images: tf.Tensor, labels: tf.Tensor):
    """Apply random brightness and horizontal flip augmentation."""
    images = tf.image.random_brightness(images, max_delta=0.3)
    images = tf.image.random_flip_left_right(images)
    return images, labels

class TldTrainingSession:
    def __init__(self):
        self.input_shape = (32, 32, 3)
        self.batch_size = 32
        self.num_classes = 4
        self.images_path = './traffic_light_data'
        self.weights_path = 'model_and_weights.keras'
        self.log_dir = './logs'

        self.optimizer = Adam()
        self.loss_func = SparseCategoricalCrossentropy()

        self.model = self._create_model(self.num_classes)
        self.model.compile(optimizer=self.optimizer, loss=self.loss_func, metrics=['accuracy'])
        print(self.model.summary())

        if os.path.exists(self.weights_path):
            print(f"Loading model from {self.weights_path}")
            self.model = tf.keras.models.load_model(self.weights_path)

    def _create_model(self, num_classes: int) -> Model:
        return Sequential([
            Conv2D(32, kernel_size=5, padding='same', activation='relu', input_shape=self.input_shape),
            BatchNormalization(),
            Conv2D(32, kernel_size=5, padding='same', activation='relu'),
            MaxPooling2D(),
            Conv2D(64, kernel_size=3, padding='same', activation='relu'),
            MaxPooling2D(),
            Conv2D(64, kernel_size=3, padding='same', activation='relu'),
            MaxPooling2D(),
            Flatten(),
            Dropout(0.3),
            Dense(num_classes, activation='softmax')
        ])

    def _load_datasets(self):
        builder = ImageFolder(self.images_path)
        ds_train = builder.as_dataset(split='train', as_supervised=True)
        ds_val = builder.as_dataset(split='val', as_supervised=True)

        resize_op = lambda x, y: (resize_image(x, (32, 32)), y)

        ds_train = ds_train.map(resize_op).map(augment_image)
        ds_train = ds_train.shuffle(1000).batch(self.batch_size).prefetch(tf.data.AUTOTUNE).cache()

        ds_val = ds_val.map(resize_op).batch(self.batch_size).prefetch(tf.data.AUTOTUNE).cache()

        return ds_train, ds_val

    def run_training(self, epochs=20):
        ds_train, ds_val = self._load_datasets()

        checkpoint = ModelCheckpoint(
            self.weights_path,
            monitor='val_accuracy',
            save_best_only=True,
            save_weights_only=False,
            verbose=1
        )

        early_stop = EarlyStopping(
            monitor='val_loss',
            patience=5,
            restore_best_weights=True,
            verbose=1
        )

        print(f"Starting training for {epochs} epochs...")
        self.model.fit(
            ds_train,
            validation_data=ds_val,
            epochs=epochs,
            callbacks=[checkpoint, early_stop],
            verbose=2
        )

        print("Training completed.")
        loss, acc = self.model.evaluate(ds_val, verbose=2)
        print(f"Validation loss: {loss:.4f}, accuracy: {acc:.4f}")

    def predict_single(self, image_path: str):
        """Load image, preprocess and predict its class."""
        image = tf.keras.preprocessing.image.load_img(image_path)
        image = tf.keras.preprocessing.image.img_to_array(image)
        image = resize_image(image, (32, 32))
        image = tf.expand_dims(image, axis=0)  # batch dimension

        preds = self.model.predict(image)
        predicted_class = tf.argmax(preds[0]).numpy()
        class_names = {0: 'backside', 1: 'green', 2: 'red', 3: 'yellow'}
        print(f"Predicted class index: {predicted_class}, color: {class_names[predicted_class]}")

if __name__ == '__main__':
    session = TldTrainingSession()
    session.run_training(epochs=20)

    test_image_path = './traffic_light_data/val/yellow/yellow_4.jpg'
    session.predict_single(test_image_path)
