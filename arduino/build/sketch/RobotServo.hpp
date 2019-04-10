#ifndef ROBOTSERVO_H
#define ROBOTSERVO_H

#include <Arduino.h>
#include <SPI.h>
#include <Servo.h>

class RobotServo {
private:
    int pin;
    int update_interval;
    int min_limit;
    int max_limit;
    unsigned long prev_us;
    float rotation;
    Servo s;
public:
    RobotServo(int _pin, int _update_interval, int _min_limit, int _max_limit);
    ~RobotServo();
    void servoSetup();
    void update(float vel);

    float getRotation() { return rotation; }
    
    inline float degToUnits(float deg) {
        return (deg * ((max_limit - min_limit) / 180));
    }

    inline float clamp(float val, float min_val, float max_val) {
        if (val < min_val) return min_val;
        else if (val > max_val) return max_val;
        else return val;
    }
};

#endif