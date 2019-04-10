#include "RobotServo.hpp"

RobotServo::RobotServo(int pin, int update_interval, int servo_min_limit, int servo_max_limit) {
    _pin = pin;
    _update_interval = update_interval;
    _servo_min_limit = servo_min_limit;
    _servo_max_limit = servo_max_limit;
    _prev_us = micros();
    _rotation = 1500;   // Start at midpoint
}

RobotServo::~RobotServo() { }

// Must ALWAYS call servoSetup() inside the setup() loop of the main function
void RobotServo::servoSetup() {
    // Attach servo to pin and move to centre
    s.attach(_pin);
    s.writeMicroseconds(_rotation);
}

// vel = rotational velocity in deg/s desired

void RobotServo::update(float vel) {
    unsigned long time = micros();
    // TODO: Remove update interval, it's pointless, want to update every opportunity anyway
    if ((time - _prev_us) > _update_interval) {
        if (vel != 0) {
            _rotation = _rotation + (degToUnits(vel) * (time - _prev_us) / 1000000);
            _rotation = clamp(_rotation, _servo_min_limit, _servo_max_limit);
            if (vel < 0) {
                s.writeMicroseconds((int)ceil(_rotation));
            } else {
                s.writeMicroseconds((int)floor(_rotation));
            }
        }
        _prev_us = time;
    }
}
