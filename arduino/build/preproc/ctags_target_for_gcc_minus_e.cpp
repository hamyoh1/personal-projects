# 1 "c:\\Users\\Zac\\Documents\\GitHub\\personal-projects\\arduino\\Robot Arm\\Joystick.cpp"
# 1 "c:\\Users\\Zac\\Documents\\GitHub\\personal-projects\\arduino\\Robot Arm\\Joystick.cpp"
# 2 "c:\\Users\\Zac\\Documents\\GitHub\\personal-projects\\arduino\\Robot Arm\\Joystick.cpp" 2

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
  if (((x)>0?(x):-(x)) < dz_x) {
    x = 0;
  } else {
    if (x > 0) {
      x = (float)((x - dz_x) / (1 - dz_x));
    } else {
      x = (float)((x + 1) / (1 - dz_x)) - 1;
    }
  }

  if (((y)>0?(y):-(y)) < dz_y) {
    y = 0;
  } else {
    if (y > 0) {
      y = (float)((y - dz_y) / (1 - dz_y));
    } else {
      y = (float)((y + 1) / (1 - dz_y)) - 1;
    }
  }
}
# 1 "c:\\Users\\Zac\\Documents\\GitHub\\personal-projects\\arduino\\Robot Arm\\robot-arm.ino"
/*
 Controlling a servo position using a potentiometer (variable resistor)
 by Michal Rinott <http://people.interaction-ivrea.it/m.rinott>

 modified on 8 Nov 2013
 by Scott Fitzgerald
 http://www.arduino.cc/en/Tutorial/Knob
*/

# 11 "c:\\Users\\Zac\\Documents\\GitHub\\personal-projects\\arduino\\Robot Arm\\robot-arm.ino" 2
# 12 "c:\\Users\\Zac\\Documents\\GitHub\\personal-projects\\arduino\\Robot Arm\\robot-arm.ino" 2
# 13 "c:\\Users\\Zac\\Documents\\GitHub\\personal-projects\\arduino\\Robot Arm\\robot-arm.ino" 2
# 14 "c:\\Users\\Zac\\Documents\\GitHub\\personal-projects\\arduino\\Robot Arm\\robot-arm.ino" 2

# 16 "c:\\Users\\Zac\\Documents\\GitHub\\personal-projects\\arduino\\Robot Arm\\robot-arm.ino" 2

// Color definitions
# 32 "c:\\Users\\Zac\\Documents\\GitHub\\personal-projects\\arduino\\Robot Arm\\robot-arm.ino"
// Will eventually set this in menus on the LCD







// Digital Pin Definitions




// Analog Pin Definitions
// Joystick 1 X - Base rotation
// Joystick 1 Y - Base arm rotation



// Joystick 2 X - Link 1 rotation (?)
// Joystick 2 Y - Gripper rotation (for later)



TFT_ILI9163C tft = TFT_ILI9163C(10, 9,12);

// struct Joystick {
//   float j_x;  // X position of joystick
//   float j_y;  // Y position of joystick
//   bool j_sw;    // is switch pressed?
//   int j_pin_x;    // pin of joystick x data on arduino
//   int j_pin_y;    // pin of joystick y data on arduino
// };

Joystick j1(A2, A1, 0.05, 0.05);
Joystick j2(A3, A4, 0.05, 0.05);

RobotServo SERVO__BASE(6, 0 /* In microseconds*/, 544, 2300);
RobotServo SERVO__BASE_ARM(5, 0 /* In microseconds*/, 544, 2300);
RobotServo SERVO__LINK_1(3, 0 /* In microseconds*/, 544, 2300);

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

  SERVO__BASE.update(j1.getX() * 120);
  SERVO__BASE_ARM.update(j1.getY() * 120);
}

void servo_1() {
  //if (serv_1_val != prev_serv_1_val){
    tft.setCursor(3, 0);
    tft.setTextColor(0xFFFF, 0x0000);
    tft.setTextSize(1);
    String out = "Servo #1 Pos: ";
    out = out + SERVO__BASE.getRotation();
    out = out + "      ";
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
  return (deg * ((2300 - 544) / 180));
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
