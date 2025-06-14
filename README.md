# 🎮 JuntTheSpluges

*A puzzle game built with Unity and C#.*

## 🕹️ Project Description

This is a personal game development project created to explore the full process of building a complete video game from scratch.

As part of my transition from backend software engineering into professional game development, this project showcases not only gameplay but also a strong technical foundation.

### ✨ Key Features

- 🧰 **Custom Level Editor**  
  Built my own map editor to simplify and speed up the level design process.

- 📈 **Well-Designed Difficulty Progression**  
  Special attention was given to balancing challenge and learning curve throughout the game.

- 🧠 **Clean Architecture & Scalable Code**  
  The codebase is organized using clean architecture principles with an emphasis on modularity and maintainability.

- 🧩 **Use of Design Patterns & Polymorphism**  
  Applied patterns like Strategy and Command to structure game logic in a flexible, extensible way.

- 🔁 **Rewind Mechanic**  
  Implemented a rewind feature that lets the player undo actions — adding both gameplay depth and technical challenge.

- 🧪 **Unit Testing**  
  Automated tests were written to ensure feature stability and allow confident iteration. Adding new features without breaking existing ones is fast and safe.

This project represents my commitment to writing solid, testable, and scalable code — even in a creative and fast-paced environment like game development.


---

## 📌 Project Status

Beta Finished 

thing to improve: 
- Menu navigations
- Graphics and animations

---

## 🛠️ Technologies Used

- Unity [2019.4.3f1] (URP)
- C#
- Shader Graph, Unity Tilemap, ScriptableObjects, shaders, unit testing, integration testing.

---

## 🎮 Controls

- **Move**: WASD / Arrow Keys
- **Change Player**: Spacebar
- **Rewind**: Q/E
- **Pause/Menu**: Enter

---

## ▶️ How to Play

### Option 1 — Open in Unity Editor

1. Clone this repository
2. Open the project in **2019.4.3f1**
3. Open and run the scene: `Assets/Scenes/MainMenuAndLevels/init Menu.unity`

> ⚠️ Unity version matters. Using a different version may cause compilation issues.

### Option 2 — Playable Build (if available)

[👉 Download from Itch.io](https://your-game.itch.io)  
*(Or include instructions to run .exe)*

---

## 📁 Project Structure Overview

```plaintext
Assets/
├── Scripts/                # Game logic scripts
│   ├── ConditionCheckes/   # Strategy patters dedicated to manage al the elemnts on the scenary after a movement
│   ├── ScenaryElements/    # All elements on the scenary (including players)
│   └── States/             # All the states on the game (menu with UI, playing, lose screen etc...). all managed with the GameManager
├── Animators/              # Unity animations controllers
├── Prefabs/                # Reusable objects
├── Scenes/                 # Unity scenes
├── Prefabs/                # Reusable objects
├── ScriptableObjects/      # ScriptableObjects uder for map editor
├── Sound/                  # Sound effects and music
├── Shaders/                # Graphical shaders
├── Sprites/                # Sprites and art
├── Audio/                  # Sound effects and music
├── Tiles/                  # Tiles used for map editor (relate a tiles and prefab with scriptableObject)
└── Test/                   # Scripts for unit test and e2e level test

```
🔗 [See this project on my portfolio](https://albertonasarre.dev/game-1/)

 
