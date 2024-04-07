[![en](https://img.shields.io/badge/lang-en-red.svg)](https://github.com/FrixQn/LeoECS-code-example/blob/main/README.en-US.md)
[![ru](https://img.shields.io/badge/lang-ru-yellow.svg)](https://github.com/FrixQn/LeoECS-code-example/blob/main/README.ru-RU.md)

# Example of using the LeoECS framework in Unity
In this example, only CharacterController and Animator were used from Unity objects, all other systems were written completely from scratch:

- *CameraViewSystem* is a player view system that allows you to look around in the game space
- *MovementSystem* - the system of movement of the player in the game space, CharacterController is used.Move to move
- *AnimationSystem* - animation system
- *PlayerInputSystem* - Player input reading system. Reads the player's input and assigns the data to the necessary components
- *PlayerSpawnSystem* - the player's spawn system (the entry point for the player)
- *SimpleGravitySystem* - the gravity system of the main player (without it, the player can walk through the air)
- *BalloonsSystem* is a system designed for an entity with a *BalloonComponent* component and processes the impact with the ball, as well as is responsible for the management of such entities

The gameplay video is available at the [link](https://drive.google.com/file/d/1bT9QtJy2-Rx3AwKvymQvC1Ygt2_vTZz2/view?usp=sharing):