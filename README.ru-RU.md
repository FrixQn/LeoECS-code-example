[![en](https://img.shields.io/badge/lang-en-red.svg)](https://github.com/FrixQn/LeoECS-code-example/blob/main/README.en-US.md)
[![ru](https://img.shields.io/badge/lang-ru-yellow.svg)](https://github.com/FrixQn/LeoECS-code-example/blob/main/README.ru-RU.md)

# Пример использования фреймворка LeoECS в Unity
В данном примере из объектов Unity использовались только CharacterController и Animator, все остальные системы были написаны полностью с нуля:

- *CameraViewSystem* - система вида игрока, которая позволяет осматриваться в игровом пространстве
- *MovementSystem* - систмеа передвижения игрока в игровом пространсве, используется CharacterController.Move для передвижения
- *AnimationSystem* - система анимаций
- *PlayerInputSystem* - система считывания ввода игрока. Считывает ввод игрока и назначает данные нужным компонентам
- *PlayerSpawnSystem* - систмеа спавна игрока (точка входа для игрока)
- *SimpleGravitySystem* - система гравитации главного игрока (без нее игрок может ходит по воздуху)
- *BalloonsSystem* - система предназначеная для entity с компонентом *BalloonComponent* и обрабатывает импакт с шаром, а также отвечает за менеджмент таких entities

Видео геймплея доступно по [ссылке](https://drive.google.com/file/d/1bT9QtJy2-Rx3AwKvymQvC1Ygt2_vTZz2/view?usp=sharing):
