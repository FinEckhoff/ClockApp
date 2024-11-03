# ClockApp

ClockApp is a Windows Forms application designed to function as a countdown timer with additional functionality. The app features customizable countdown and timeout timers, score tracking, and a full-screen toggle for an immersive experience. Ideal for timed activities and events, the application also offers keyboard shortcuts to control the timer and update scores efficiently.

## Features

- **Countdown Timer**: Main timer with customizable duration (default 12 minutes).
- **Timeout Timers**: Left and right timeout timers with customizable durations.
- **Score Tracking**: Adjustable left and right scores displayed prominently on-screen.
- **Responsive Layout**: Automatic font resizing based on screen size for optimal readability.
- **Full-Screen Mode**: Toggle full-screen mode with `F11` for a focused display.
- **Keyboard Shortcuts**: Control all aspects of the timer and scores using hotkeys.

## Configuration

The app references an external configuration file, `Form0.currentConfig`, with settings such as:

- `n_defaultTime`: Initial countdown time in seconds.
- `n_TimeoutTime`: Initial timeout duration in seconds.
- `n_upperRowPercentage`: Percentage of the top row height.
- `n_scorePercentage`: Score label size as a percentage.
- `b_ColorTimeScore`: Color for the main countdown timer and score text.
- `b_ColorTimeout`: Color for the timeout timers.

## Keyboard Shortcuts

| Shortcut                  | Action                                      |
|---------------------------|---------------------------------------------|
| `Ctrl + Left`             | Start/reset left timeout timer              |
| `Ctrl + Right`            | Start/reset right timeout timer             |
| `Ctrl + Shift + Left`     | Stop and hide left timeout timer            |
| `Ctrl + Shift + Right`    | Stop and hide right timeout timer           |
| `Space`                   | Start/pause countdown timer                 |
| `Escape`                  | Reset all timers and scores                 |
| `Ctrl + +`                | Increase countdown time by 1 minute         |
| `Ctrl + -`                | Decrease countdown time by 1 minute         |
| `Ctrl + A`                | Increase left score                         |
| `Ctrl + B`                | Increase right score                        |
| `Ctrl + C`                | Reset left and right scores to 0            |
| `F11`                     | Toggle full-screen mode                     |

## Installation

1. Clone this repository.
   ```bash
   git clone https://github.com/yourusername/ClockApp.git
   cd ClockApp ```
2. Open the solution in Visual Studio.
3. Ensure Newtonsoft.Json package is installed for handling JSON configurations:
   ```bash
   Install-Package Newtonsoft.Json ```
4. Build and run the application.


