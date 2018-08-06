## Home Alarm System
This project is still in development and will have the following features:
* Motion sensing alarm system
  * Makes a loud noise when the PIR motion sensor is triggered
  * Sends a notification to your mobile device alerting you that the alarm has been triggered
    * Requires a Wi-Fi shield
  * Alarm can be enabled/disabled
* An LCD screen will detail the status of the alarm, and enable navigation of menus to change various settings regarding the alarm
  * Navigated by a rotary encoder w/ switch
* There will be a keypad or RFID scanner to facilitate changing the settings of the alarm (via a password or keycard)
* RGB LED detailing status of alarm
  * Red: Off
  * Green: Active
  * Orange: Error
* Camera live feed that can be connected to
  * If alarm is triggered and you are notified via your mobile device, notification will have an option to go to the camera live feed
  
Current tasklist:
[x] Install LCD screen with a 74HC595 shift register to decrease number of required pins
[] Program LCD menu that can be navigated with rotary encoder
[] Install keypad with resistor set-up to enable the use of a single analog pin for input (as opposed to 8 pins)
[] Determine how to install VGA camera to reduce number of required pins
