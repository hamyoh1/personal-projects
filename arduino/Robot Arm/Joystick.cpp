#include "Joystick.hpp"

Joystick::Joystick(int _pin_x, int _pin_y, int _pin_sw, float _dz_x, float _dz_y) {
    pin_x = _pin_x;
    pin_y = _pin_y;
    pin_sw = _pin_sw;
    dz_x = _dz_x;
    dz_y = _dz_y;
}

Joystick::~Joystick() { }

void Joystick::jsSetup() {
  pinMode(pin_sw, INPUT_PULLUP);
}

void Joystick::update() {
  // If a button press has been registered, don't overwrite it until it has been processed
  if (sw != LOW) sw = digitalRead(pin_sw);

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

bool Joystick::getSwitch() {
  bool temp = sw;
  sw = HIGH; 
  return temp;
}