# VR Furniture Library System

A Virtual Reality application for browsing and interacting with furniture models in immersive 3D environments. This project was developed as part of thesis research at **NCKU Department of Civil Engineering XR Lab** under the guidance of **Prof. Feng Chung Wei**.

![Unity](https://img.shields.io/badge/Unity-2022.3-blue?logo=unity)
![Platform](https://img.shields.io/badge/Platform-Oculus%20Quest%20%7C%20Rift%20S-green?logo=oculus)
![License](https://img.shields.io/badge/License-MIT-green)

---

## 🌟 Overview

This VR application enables users to:
- **Browse multiple virtual environments** - Navigate through different 3D house models
- **Interact with furniture** - Search, grab, and manipulate furniture objects in VR space
- **Edit mode** - Toggle locomotion and object interaction for precise placement
- **Take screenshots** - Capture VR views for documentation and analysis

The system is designed for **Meta Quest 2/Rift S** headsets and leverages **XR Interaction Toolkit** for natural VR interactions.

---

## ✨ Key Features

### 🏠 Environment Management
- Load and switch between different 3D house models
- Visual catalog interface for browsing available environments
- Support for **Gibson**, **3D FUTURE**, and **Polycam** furniture datasets

### 🪑 Object Interaction
- **Physics-based grabbing** - Natural grab and release mechanics
- **Smart orientation** - Objects automatically stay upright when held
- **Height locking** - Objects maintain consistent height during manipulation
- **Search system** - Automatically detect interactable objects within radius

### 🎮 VR Controls
- **Locomotion system** - Continuous movement and turning
- **Teleportation** - Quick navigation to spawn points
- **Edit mode toggle** - Enable/disable movement and object interaction
- **Secondary button rotation** - Rotate objects while holding them

### 📸 Additional Features
- **VR screenshot capture** - Save in-game views for documentation
- **UI menu system** - Intuitive interfaces for all functions
- **Collision-based movement** - Objects move on collision for dynamic scenes
- **Spawn point management** - Define where users appear in each scene

---

## 🛠️ Technology Stack

### Core Frameworks
- **Unity 2022.3** - Game engine and rendering
- **XR Interaction Toolkit 2.3.2** - VR interaction framework
- **OpenXR 1.7.0** - Cross-platform VR standard

### Third-Party Libraries
- **AutoHand** - Automated hand interaction system
- **HurricaneVR** - Advanced VR physics and interactions
- **TextMesh Pro** - High-quality text rendering
- **Modern UI Pack** - User interface components
- **QuickSave** - Data persistence system
- **AllSky Free** - Skybox and environment lighting

---

## 🚀 Getting Started

### Prerequisites
- **Unity 2022.3** or later
- **Meta Quest 2** or **Rift S** headset
- Windows 10/11 for development

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/ansellreff/FurnitureLibrarySystemVR.git
   ```

2. **Open in Unity**
   - Launch Unity Hub
   - Add project: Select the `XRLabFurnitureLibrarySystem` folder
   - Open in Unity 2022.3

3. **Build for VR**
   - Go to `File > Build Settings`
   - Select your target platform (Android for Quest, standalone for Rift)
   - Click "Build and Run"

---

## 📖 Usage

### Basic Controls

| Action | Control |
|---------|----------|
| Move | Thumbstick (continuous movement) |
| Turn | Thumbstick (snap or continuous turning) |
| Grab | Grip button |
| Release | Release grip button |
| Rotate object | Secondary button while holding |
| Teleport | Point and press trigger |
| Toggle menu | Menu button |
| Take screenshot | Dedicated UI button |

### Edit Mode

Toggle **Edit Mode** to:
- Disable locomotion (stay in place)
- Enable/disable object interaction
- Precisely position furniture items
- Take screenshots without movement interference

---

## 📁 Project Structure

```
XRLabFurnitureLibrarySystem/
├── Assets/
│   ├── Scripts/           # Core C# scripts
│   ├── Scenes/             # Unity scene files
│   └── [Packages]/         # Third-party assets
│       ├── AutoHand/
│       ├── HurricaneVR/
│       ├── XR Interaction Toolkit/
│       └── Modern UI Pack/
├── Packages/              # Unity packages
├── ProjectSettings/       # Unity project configuration
└── UserSettings/          # User-specific settings
```

---

## 🔧 Key Scripts

| Script | Purpose |
|--------|---------|
| [HouseCatalogue.cs](XRLabFurnitureLibrarySystem/Assets/Scripts/HouseCatalogue.cs) | Manage environment catalog and loading |
| [EditMode.cs](XRLabFurnitureLibrarySystem/Assets/Scripts/EditMode.cs) | Toggle locomotion and interaction modes |
| [ObjectSearcher.cs](XRLabFurnitureLibrarySystem/Assets/Scripts/ObjectSearcher.cs) | Detect and track interactable objects |
| [VRScreenshot.cs](XRLabFurnitureLibrarySystem/Assets/Scripts/VRScreenshot.cs) | Capture VR screenshots |
| [TeleportationManager.cs](XRLabFurnitureLibrarySystem/Assets/Scripts/TeleportationManager.cs) | Handle teleportation mechanics |
| [UIManager.cs](XRLabFurnitureLibrarySystem/Assets/Scripts/UIManager.cs) | Control user interface elements |

---

## 📚 Research Context

This system was developed to enable **furniture browsing and visualization in virtual reality** for research in:
- **Interior design** - Preview furniture in realistic spaces
- **Spatial computing** - Object manipulation in 3D environments
- **VR user interfaces** - Natural interaction patterns

### Datasets Supported
- **Gibson Environment** - Home indoor scenes
- **3D FUTURE** - Furniture model dataset
- **Polycam** - Photogrammetry-captured furniture

---

## 🤝 Contributing

This project is part of academic research. For questions or collaboration:
- Open an issue for bugs or feature requests
- Submit pull requests for improvements
- Contact the author directly (see below)

---

## 👤 Author

**Aurellius Ansell Reffriandi**

---

## 📧 Contact

**Email:** [reffriandi@gmail.com](mailto:reffriandi@gmail.com)

---

## 📄 License

This project is part of academic research. Please contact the author for usage permissions.

---

## 🙏 Acknowledgments

- **NCKU XR Lab** - Research facility and equipment
- **Prof. Feng Chung Wei** - Research guidance and supervision
- **Meta** - Oculus VR hardware and SDKs
- **Unity Technologies** - Game engine and VR frameworks
- **Asset creators** - Third-party packages and tools listed above

---

*Last updated: February 2026*
