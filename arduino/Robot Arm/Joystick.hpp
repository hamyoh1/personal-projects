#ifndef JOYSTICK_HPP
#define JOYSTICK_HPP

class Joystick {
private:
    int pin_x;    // pin of joystick x data on arduino
    int pin_y;    // pin of joystick y data on arduino
    float x;      // X position of joystick
    float y;      // Y position of joystick
    bool sw;      // is switch pressed?
    float dz_x;   // Deadzone of x-axis
    float dz_y;   // Deadzone of y-axis
public:
    Joystick(int _pin_x, int _pin_y, float _dz_x, float _dz_y);
    ~Joystick();
    void update();
    float getX() { return x; }
    float getY() { return y; }
};

#endif