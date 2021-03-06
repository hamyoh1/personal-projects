/*
 Controlling a servo position using a potentiometer (variable resistor)
 by Michal Rinott <http://people.interaction-ivrea.it/m.rinott>

 modified on 8 Nov 2013
 by Scott Fitzgerald
 http://www.arduino.cc/en/Tutorial/Knob
*/
#include <SPI.h>

#include "RobotServo.hpp"
#include "Joystick.hpp"
#include "Screen.hpp"

// Color definitions
#define BLACK   0x0000
#define BLUE    0x001F
#define RED     0xF800
#define GREEN   0x07E0
#define CYAN    0x07FF
#define MAGENTA 0xF81F
#define YELLOW  0xFFE0  
#define WHITE   0xFFFF

#define PADDING "      "

#define DEADZONE_X 0.05
#define DEADZONE_Y 0.05

// Will eventually set this in menus on the LCD
#define SERVO_MAX_SPEED 120

#define SERVO_MAX_LIMIT 2300
#define SERVO_MIN_LIMIT 544

// Digital Pin Definitions
// These are not sent to the TFT class
// They are just here for reminder
// To change pin value of TFT screen, need to change in User_Setup.h
// In the arduino library for st7735
#define __CS 10
#define __DC 9
#define __RST 12

// Analog Pin Definitions
// Joystick 1 X - Base rotation
// Joystick 1 Y - Base arm rotation
#define __J1_X A2
#define __J1_Y A1
#define __J1_SW 3

// Joystick 2 X - Link 1 rotation (?)
// Joystick 2 Y - Gripper rotation (for later)
#define __J2_X A3
#define __J2_Y A4
#define __J2_SW 2

#define LCD_REFRESH_RATE 500 //Update rate of LCD in ms

String system_info[3] = {
  "DeskArm Mini",
  "Version: 1.00",
  "Author: Zac Hamid"
};

Screen screen = Screen(LCD_REFRESH_RATE);

// TODO: FIX ERRORS

unsigned long prev_lcd_update;

Joystick j1(__J1_X, __J1_Y, __J1_SW, DEADZONE_X, DEADZONE_Y);
Joystick j2(__J2_X, __J2_Y, __J2_SW, DEADZONE_X, DEADZONE_Y);

RobotServo SERVO__BASE(6, SERVO_MIN_LIMIT, SERVO_MAX_LIMIT);
RobotServo SERVO__BASE_ARM(5, SERVO_MIN_LIMIT, SERVO_MAX_LIMIT);
RobotServo SERVO__LINK_1(4, SERVO_MIN_LIMIT, SERVO_MAX_LIMIT);

bool joystick_moved = false;

void setup() {
  Serial.begin(9600);

  SERVO__BASE.servoSetup();
  SERVO__BASE_ARM.servoSetup();
  SERVO__LINK_1.servoSetup();

  j1.jsSetup();
  j2.jsSetup();

  screen.screenSetup();

  prev_lcd_update = millis();

  delay(100);
}

// TODO: Implement other 3 main servos, and gripper servo
// TODO: Menu functionality stuff
void loop() {
  // if ((millis() - prev_lcd_update) > LCD_REFRESH_RATE) {
    
  //   prev_lcd_update = millis();
  //   //SERVO__BASE.update_micros();
  //   //SERVO__BASE_ARM.update_micros();
  //   //SERVO__LINK_1.update_micros();
  // }

  j1.update();
  j2.update();

  SERVO__BASE.update(j1.getX() * SERVO_MAX_SPEED);
  SERVO__BASE_ARM.update(j1.getY() * SERVO_MAX_SPEED);
  SERVO__LINK_1.update(j2.getX() * SERVO_MAX_SPEED);

  if (!joystick_moved && j1.getY() != 0) {
    if (j1.getY() < 0) {
      screen.setSelection(screen.getSelection() - 1);
    } else {
      screen.setSelection(screen.getSelection() + 1);
    }
    joystick_moved = true;
  }
  if (j1.getY() == 0) joystick_moved = false;

  if (!j1.getSwitch()) screen.applySelection();

  screen.update();
}

// void servo_info() {
//   tft_st.setTextWrap(false);
//   tft_st.setCursor(0, 0);
//   tft_st.setTextColor(ST7735_WHITE,ST7735_BLACK);
//   tft_st.setTextSize(1);
//   String out = "Servo #1 Pos: ";
//   out = out + SERVO__BASE.getRotation();
//   tft_st.println(out);
//   out = "Servo #2 Pos: ";
//   out = out + SERVO__BASE_ARM.getRotation();
//   tft_st.println(out);
//   tft_st.setTextWrap(true);
//   if (!j1.getSwitch()) {
//     out = "Joystick #1 button pressed!";
//   } else {
//     out = "                            ";
//   }
//   tft_st.println(out);
//   if (!j2.getSwitch()) {
//     out = "Joystick #2 button pressed!";
//   } else {
//     out = "                            ";
//   }
//   tft_st.println(out);
// }