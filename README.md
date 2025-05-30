# 🔬 Abiogenesis Simulator

A WPF desktop application to simulate the energy viability of prebiotic reaction networks under fluctuating environmental conditions, inspired by the **Thermodynamic Abiogenesis Likelihood Model (TALM)**.

---

## 📘 Overview

This application plots **net energy viability (z)** of custom or predefined chemical reaction sets over time, in response to time-varying environmental energy inputs. It helps researchers, students, and theorists explore how energy dynamics might have driven the emergence of life's building blocks.

---

## ⚙️ Features

- 📈 Real-time line chart of net energy (z) over time  
- 🌍 Environmental energy modes: sinusoidal, random, step-change, catastrophe  
- 🧪 Editable reaction sets with input/output/storage energy values  
- 🔁 Loadable presets for known or hypothesized environments (e.g. hydrothermal vents, tidal pools)  
- 💥 Collapse-based scenarios to demonstrate thermodynamic filtering  
- ☀️ Star lifecycle modeling (chaotic → stable)  
- 🧠 Visual teaching tool for prebiotic selection theory

---

## 🔬 Scientific Background

The app is based on this viability formula:

z(t) = e_input(t) + ∑storage - ∑input + ∑output


Where:

| Term      | Meaning                                    |
|-----------|--------------------------------------------|
| e_input   | Energy available from the environment      |
| input     | Energy required to initiate reactions      |
| output    | Energy released by reactions               |
| storage   | Energy stored in reaction products         |

If `z(t) > 0`, the reaction set is viable. If `z(t) < 0`, it is unsustainable. This simulates **thermodynamic selection** — an early form of filtering that may precede biological natural selection.

---

## 🚀 Installation

1. Clone the repository or download the source.
2. Open `AbiogenesisSimulator.sln` in Visual Studio 2022+.
3. Restore NuGet packages (LiveChartsCore, SkiaSharp).
4. Build and run the project.

Dependencies:
- .NET 8.0
- WPF
- LiveChartsCore.SkiaSharpView

---

## 🧪 Usage

1. Select an **energy input mode** (e.g., sinusoidal).
2. Choose a **reaction preset** or build your own set.
3. Set **simulation duration** with the slider.
4. Click **Run Simulation** to see the energy trend.
5. Interpret the graph: above zero = sustainable, below zero = collapse.

---

## 📂 Presets Included

| Preset Name            | Description                                     |
|------------------------|-------------------------------------------------|
| Hydrothermal Vent      | High-gradient, mineral-rich deep-sea chemistry |
| Tidal Pool             | Wet-dry polymerization on land                 |
| UV Surface Pool        | Sunlight-driven chemical activity              |
| Overloaded Network     | Unsustainable energy demand                    |
| False Start            | Early success, late failure                    |
| Catastrophe Vulnerable | Prone to sudden collapse                       |
| Storage Dependency     | Over-reliance on stored energy                 |

---

## 📁 File Structure

AbiogenesisSimulator/
│
├── MainWindow.xaml / .cs # UI and core simulation logic
├── Reaction.cs # Reaction object model
├── ReactionLibrary.cs # Preset reaction sets
├── EnergyInput.cs # Environmental energy profiles
├── EnergySystem.cs # Time-based energy events
├── SunModel.cs # Stellar aging model
├── App.xaml / .cs # WPF application entry


---

## 🤝 Contributing

Ideas and contributions are welcome! Potential areas:
- Dynamic reaction persistence modeling
- Evolutionary replication systems
- JSON import/export of reaction sets
- Export graphs as images or data

---

## 🧠 Credits

Developed by [T. M. Prosser]  
Inspired by thermodynamic models of abiogenesis, including work by Deamer, Lane, Russell, Sutherland, and others.

---

## 📜 License

MIT License (or specify your own)

