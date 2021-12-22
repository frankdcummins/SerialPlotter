# Serial Plotter

Serial Plotter is a C#/.NET application that plots the real-time values from the PSYONIC touch sensors.

## Testing Procedure

### Rules and Requirements
1. The following procedure shall be conducted on an anti-static mat, which shall be properly grounded.
1. The programming operator shall wear an ESD wrist strap, which shall be properly grounded.

### Required Material
| Item | Quantity | Description |
| ---- | -------- | ----------- |
| 1 | 1 | PSYONIC Touch Sensor Board |
| 2 | 1 | [FTDI Basic Breakout 3.3V](https://www.sparkfun.com/products/9873) |
| 3 | 1 | USB mini type B cable |
| 4 | 3 | Jumper Wires |

### Steps
| Step | Directions | Photo | 
| ---- | ---------- | ----- |
| 1  | Don the grounded, ESD wrist strap. | - |
| 2  | Place the Touch Sensor Board on a grounded, anti-static mat. | - |
| 3  | Plug the Touch Sensor Board leads into the FTDI breakout as follows:<br>PWR --> 3V3<br>GND --> GND<br>TX --> RX | - |
| 4  | Plug the USB cable into the FTDI breakout board and connect the other end to an available USB port on a Windows PC. | - |
| 5  | Open [SerialTest.exe](https://github.com/frankdcummins/SerialPlotter/releases/download/Release/SerialTest.exe) on the host PC. | - |
| 6  | Select the COM port from the pull-down menu and click `Connect`. | - |
| 7  | Ensure that each pad on the Touch Sensor Board responds when touched. | - |
| 8  | Ensure that each pad on the Touch Sensor Board can reach the highest point on the plot. | - |
| 9  | Ensure that each pad returns to a reasonable baseline once the pad is released. | - |
| 9  | Click `Disconnect` once you have verified each touch sensor pad. | - |
| 10 | Unplug the Touch Sensor Board from the FTDI breakout. | - |
| 11 | Update the Touch Sensor Board entry in the [PSYONIC Inventory Tracking Spreadsheet](#insert-link).

### Troubleshooting
| Problem | Solution |
| ------- | -------- |
| Multiple COM ports available | Launch the Device Manager from the Start Menu, and verify which COM port is attached to the FTDI breakout board.|
