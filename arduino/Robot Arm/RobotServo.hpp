#ifndef ROBOTSERVO_H
#define ROBOTSERVO_H

#include <Arduino.h>
#include <SPI.h>
#include <Servo.h>

class RobotServo {
private:
    int _pin;
    int _update_interval;
    int _servo_min_limit;
    int _servo_max_limit;
    unsigned long _prev_us;
    float _rotation;
    Servo s;
public:
    RobotServo(int pin, int update_interval, int servo_min_limit, int servo_max_limit);
    ~RobotServo();
    void servoSetup();
    void update(float vel);

    float getRotation() { return _rotation; }
    
    inline float degToUnits(float deg) {
        return (deg * ((_servo_max_limit - _servo_min_limit) / 180));
    }

    inline float clamp(float val, float min_val, float max_val) {
        if (val < min_val) return min_val;
        else if (val > max_val) return max_val;
        else return val;
    }
};

#endif