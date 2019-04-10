#include <Arduino.h>
#line 1 "c:\\Users\\Zac\\Documents\\GitHub\\personal-projects\\arduino\\Robot Arm\\Joystick.cpp"
#line 1 "c:\\Users\\Zac\\Documents\\GitHub\\personal-projects\\arduino\\Robot Arm\\Joystick.cpp"
#include "Joystick.hpp"

Joystick::Joystick(int _pin_x, int _pin_y, float _dz_x, float _dz_y) {
    pin_x = _pin_x;
    pin_y = _pin_y;
    dz_x = _dz_x;
    dz_y = _dz_y;
}

Joystick::~Joystick() { }

void Joystick::update() {
  // Read data from analog pins
  x = analogRead(pin_x);
  y = analogRead(pin_y);

  // Map range from [0,1024] to [-1,1]
  x = (float)(x - 512)/512.0;
  y = (float)(y - 512)/512.0;

  // If within deadzone, set to 0, otherwise scale to [0, 1]
  if (abs(x) < dz_x) {
    x = 0;
  } else {
    if (x > 0) {
      x = (float)((x - dz_x) / (1 - dz_x));
    } else {
      x = (float)((x + 1) / (1 - dz_x)) - 1;
    }
  }

  if (abs(y) < dz_y) {
    y = 0;
  } else {
    if (y > 0) {
      y = (float)((y - dz_y) / (1 - dz_y));
    } else {
      y = (float)((y + 1) / (1 - dz_y)) - 1;
    }
  }
}
#line 1 "c:\\Users\\Zac\\Documents\\GitHub\\personal-projects\\arduino\\Robot Arm\\robot-arm.ino"
/*
 Controlling a servo position using a potentiometer (variable resistor)
 by Michal Rinott <http://people.interaction-ivrea.it/m.rinott>

 modified on 8 Nov 2013
 by Scott Fitzgerald
 http://www.arduino.cc/en/Tutorial/Knob
*/

#include <Servo.h>
#include <SPI.h>
#include <Adafruit_GFX.h>
#include <TFT_ILI9163C.h>

#include "RobotServo.hpp"

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
#line 73 "c:\\Users\\Zac\\Documents\\GitHub\\personal-projects\\arduino\\Robot Arm\\robot-arm.ino"
void setup();
#line 96 "c:\\Users\\Zac\\Documents\\GitHub\\personal-projects\\arduino\\Robot Arm\\robot-arm.ino"
void loop();
#line 107 "c:\\Users\\Zac\\Documents\\GitHub\\personal-projects\\arduino\\Robot Arm\\robot-arm.ino"
void servo_1();
#line 178 "c:\\Users\\Zac\\Documents\\GitHub\\personal-projects\\arduino\\Robot Arm\\robot-arm.ino"
float clamp(float val, float min_val, float max_val);
#line 184 "c:\\Users\\Zac\\Documents\\GitHub\\personal-projects\\arduino\\Robot Arm\\robot-arm.ino"
float degToUnits(float deg);
#line 73 "c:\\Users\\Zac\\Documents\\GitHub\\personal-projects\\arduino\\Robot Arm\\robot-arm.ino"

// Will eventually set this in menus on the LCD
#define SERVO_MAX_SPEED 120

#define SERVO_MAX_LIMIT 2300
#define SERVO_MIN_LIMIT 544

#define SERVO_UPDATE_INTERVAL 0  // In microseconds

// Digital Pin Definitions
#define __CS 10
#define __DC 9
#define __RST 12

// Analog Pin Definitions
// Joystick 1 X - Base rotation
// Joystick 1 Y - Base arm rotation
#define __J1_X A2
#define __J1_Y A1

// Joystick 2 X - Link 1 rotation (?)
// Joystick 2 Y - Gripper rotation (for later)
#define __J2_X A3
#define __J2_Y A4

TFT_ILI9163C tft = TFT_ILI9163C(__CS, __DC,__RST);

// struct Joystick {
//   float j_x;  // X position of joystick
//   float j_y;  // Y position of joystick
//   bool j_sw;    // is switch pressed?
//   int j_pin_x;    // pin of joystick x data on arduino
//   int j_pin_y;    // pin of joystick y data on arduino
// };

Joystick j1(__J1_X, __J1_Y, DEADZONE_X, DEADZONE_Y);
Joystick j2(__J2_X, __J2_Y, DEADZONE_X, DEADZONE_Y);

RobotServo SERVO__BASE(6, SERVO_UPDATE_INTERVAL, SERVO_MIN_LIMIT, SERVO_MAX_LIMIT);
RobotServo SERVO__BASE_ARM(5, SERVO_UPDATE_INTERVAL, SERVO_MIN_LIMIT, SERVO_MAX_LIMIT);
RobotServo SERVO__LINK_1(3, SERVO_UPDATE_INTERVAL, SERVO_MIN_LIMIT, SERVO_MAX_LIMIT);
  
void setup() {
  // j1.j_pin_x = __J1_X;
  // j1.j_pin_y = __J1_Y;
  // j2.j_pin_x = __J2_X;
  // j2.j_pin_y = __J2_Y;

  tft.begin();
  tft.fillScreen();

  SERVO__BASE.servoSetup();
  SERVO__BASE_ARM.servoSetup();
  SERVO__LINK_1.servoSetup();

  Serial.begin(9600);
  tft.setRotation(1);
  delay(100);
}

// TODO: Change Servo min limit to 544? from here: https://www.arduino.cc/en/Reference/ServoAttach
// TODO: Setup GitHub for this project, CANT USE VSCODE FOR THIS ATM BECAUSE ITS LINKED TO UNSW GITLAB FOR OS
// TODO: Implement other 3 main servos, and gripper servo
// TODO: Menu functionality stuff
// TODO: Add power switch to battery
void loop() {
  servo_1();

  //getJoysticks();
  j1.update();
  j2.update();

  SERVO__BASE.update(j1.getX() * SERVO_MAX_SPEED);
  SERVO__BASE_ARM.update(j1.getY() * SERVO_MAX_SPEED);
}

void servo_1() {
  //if (serv_1_val != prev_serv_1_val){
    tft.setCursor(3, 0);
    tft.setTextColor(WHITE, BLACK);
    tft.setTextSize(1);
    String out = "Servo #1 Pos: ";
    out = out + SERVO__BASE.getRotation();
    out = out + PADDING;
    tft.println(out);
    //delay(100);     // Reduce flickering by refreshing once every 0.5s
  //}
  //prev_serv_1_val = serv_1_val;
}

// void getJoysticks() {

//   // Read data from analog pins
//   j1.j_x = analogRead(j1.j_pin_x);
//   j1.j_y = analogRead(j1.j_pin_y);
//   j2.j_x = analogRead(j2.j_pin_x);
//   j2.j_y = analogRead(j2.j_pin_y);

//   // Map range from [0,1024] to [-1,1]
//   j1.j_x = (float)(j1.j_x - 512)/512.0;
//   j1.j_y = (float)(j1.j_y - 512)/512.0;
//   j2.j_x = (float)(j2.j_x - 512)/512.0;
//   j2.j_y = (float)(j2.j_y - 512)/512.0;

//   // TODO: Recurse a list of joysticks instead, can reduce if statements significantly and remove repeated code

//   if (abs(j1.j_x) < DEADZONE_X) {
//     j1.j_x = 0;
//   } else {
//     if (j1.j_x > 0) {
//       j1.j_x = (float)((j1.j_x - DEADZONE_X) / (1 - DEADZONE_X));
//     } else {
//       j1.j_x = (float)((j1.j_x + 1) / (1 - DEADZONE_X)) - 1;
//     }
//   }

//   if (abs(j1.j_y) < DEADZONE_Y) {
//     j1.j_y = 0;
//   } else {
//     if (j1.j_y > 0) {
//       j1.j_y = (float)((j1.j_y - DEADZONE_Y) / (1 - DEADZONE_Y));
//     } else {
//       j1.j_y = (float)((j1.j_y + 1) / (1 - DEADZONE_Y)) - 1;
//     }
//   }
  
//   if (abs(j2.j_x) < DEADZONE_X) {
//     j2.j_x = 0;
//   } else {
//     if (j2.j_x > 0) {
//       j2.j_x = (float)((j2.j_x - DEADZONE_X) / (1 - DEADZONE_X));
//     } else {
//       j2.j_x = (float)((j2.j_x + 1) / (1 - DEADZONE_X)) - 1;
//     }
//   }

//   if (abs(j2.j_y) < DEADZONE_Y) {
//     j2.j_y = 0;
//   } else {
//     if (j2.j_y > 0) {
//       j2.j_y = (float)((j2.j_y - DEADZONE_Y) / (1 - DEADZONE_Y));
//     } else {
//       j2.j_y = (float)((j2.j_y + 1) / (1 - DEADZONE_Y)) - 1;
//     }
//   }
// }

float clamp(float val, float min_val, float max_val) {
  if (val < min_val) return min_val;
  else if (val > max_val) return max_val;
  else return val;
}

float degToUnits(float deg) {
  return (deg * ((SERVO_MAX_LIMIT - SERVO_MIN_LIMIT) / 180));
}


// Old initialisation stuff
/*
  servo__BASE.s.attach(6);  // attaches the servo on pin 6 to the servo object
  servo__BASE_ARM.s.attach(5);
  servo__LINK_1.s.attach(3);

  servo__BASE.prev_us = 0;
  servo__BASE.interval_us = SERVO_UPDATE_INTERVAL;
  servo__BASE_ARM.prev_us = 0;
  servo__BASE.interval_us = SERVO_UPDATE_INTERVAL;
  servo__LINK_1.prev_us = 0;
  servo__BASE.interval_us = SERVO_UPDATE_INTERVAL;

  // Set all servo rotations to midpoint
  servo__BASE.s_rot = 1500;
  servo__BASE_ARM.s_rot = 1500;
  servo__LINK_1.s_rot = 1500;

  servo__BASE.s.writeMicroseconds(servo__BASE.s_rot);
  servo__BASE_ARM.s.writeMicroseconds(servo__BASE_ARM.s_rot);
  servo__LINK_1.s.writeMicroseconds(servo__LINK_1.s_rot);
*/

// Old update stuff
/*

  unsigned long time = micros();
  if ((time - servo__BASE.prev_us) > servo__BASE.interval_us) {
    if (j1.j_x != 0) {
      servo__BASE.s_rot = servo__BASE.s_rot + (degToUnits(j1.j_x * SERVO_MAX_SPEED) * (time - servo__BASE.prev_us) / 1000000);
      servo__BASE.s_rot = clamp(servo__BASE.s_rot, SERVO_MIN_LIMIT, SERVO_MAX_LIMIT);
      Serial.print("time = ");
      Serial.println(time);
      Serial.print("s_rot = ");
      Serial.println(servo__BASE.s_rot);
      Serial.println("--------------");
      if (j1.j_x < 0) {
        servo__BASE.s.writeMicroseconds((int)ceil(servo__BASE.s_rot));
      } else {
        servo__BASE.s.writeMicroseconds((int)floor(servo__BASE.s_rot));
      }
    }
    servo__BASE.prev_us = time;
  }
*/
