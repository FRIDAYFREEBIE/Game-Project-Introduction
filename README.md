# Maurice

### 🎮 Freshman First Semester Game Project Introduction

---

## 📌 Project Overview

* **Game Genre**: 2D Side-Scrolling Stealth Action
* **Development Period**: 2025-03-25 ~ 2025-06-02
* **Team Size**: 5 Members (2 Game Designers, 1 Programmer, 2 Artists)
* **Goal**: To create a playable prototype and game trailer

---

## 🔑 Key Technologies

* **Unity**

  * Game engine used for gameplay implementation and system development

* **C#**

  * Core programming language used for gameplay and system logic

* **Object-Oriented Programming (OOP)**

  * **Encapsulation**

    * Many game objects required layer detection functionality.
    * To improve reusability, the detection system was separated into a `Detector` class that allowed customizable detection ranges and target layers.

  * **Inheritance**

    * Implementing separate detection logic for each object reduced readability and scalability.
    * To solve this problem, abstract base classes such as `ObjectDetectorBase` and `PlayerDetectorBase` were created and inherited by different detector types.

  * **Polymorphism**

    * Abstract methods such as `OnPlayerDetected()` and `OnPlayerExit()` were overridden so that each object could execute its own unique behavior.

* **SOLID Principles**

  * **Single Responsibility Principle**

    * The player system was divided into multiple scripts to separate responsibilities such as movement and interaction.

  * **Open-Closed Principle**

    * Detection systems such as CCTV cameras and security guards were designed to extend from `ObjectDetectorBase` without modifying the existing base structure.

* **Singleton Pattern**

  * Frequently used systems such as `GameManager` and `TimerManager` were implemented using the Singleton pattern.

---

## 🤔 What I Learned

* Refactoring spaghetti code into a cleaner structure helped me understand the importance of object-oriented design.

* By clearly separating class responsibilities and designing reusable systems, I gained experience building maintainable and scalable code structures.

* The biggest lesson I learned was understanding the object-oriented principle that “good code is code that does not need to be constantly modified.”

* During the project, I actively communicated with game designers by discussing improvements and asking questions about gameplay features.

* I also collaborated closely with artists by requesting additional resources needed for implementation.

* Weekly meetings helped reinforce the importance of role distribution and team communication in collaborative game development.

---

## 📄 Project Resources

### 🎮 Project Video (YouTube)

<p align="center">
  <a href="https://youtu.be/x2vWr0hS0rk">
    <img src="https://img.youtube.com/vi/x2vWr0hS0rk/maxresdefault.jpg" width="500">
  </a>
</p>

* [Google Drive Resources](https://drive.google.com/drive/folders/1wfMrJEdlmW1ml1LGGuPyW2Nc4TxxMshf?usp=sharing)

---
