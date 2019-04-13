#include "RobotServo.hpp"

RobotServo::RobotServo(int _pin, int _min_limit, int _max_limit) {
    pin = _pin;
    min_limit = _min_limit;
    max_limit = _max_limit;
    prev_us = micros();
    rotation = 1500;   // Start at midpoint
}

RobotServo::~RobotServo() { }

// Must ALWAYS call servoSetup() inside the setup() loop of the main function
void RobotServo::servoSetup() {
    // Attach servo to pin and move to centre
    s.attach(pin);
    s.writeMicroseconds(rotation);
}

// Run this function after a time-consuming function call to prevent jerky motion in servos
void RobotServo::update_micros() {
    prev_us = micros();
}

// vel = rotational velocity in deg/s desired

void RobotServo::update(float vel) {
    unsigned long time = micros();
    // TODO: Remove update interval, it's pointless, want to update every opportunity anyway
    if (vel != 0) {
        rotation = rotation + (degToUnits(vel) * (time - prev_us) / 1000000);
        rotation = clamp(rotation, min_limit, max_limit);
        if (vel < 0) {
            s.writeMicroseconds((int)ceil(rotation));
        } else {
            s.writeMicroseconds((int)floor(rotation));
        }
    }
    prev_us = time;
}
