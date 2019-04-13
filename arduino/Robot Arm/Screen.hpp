#ifndef SCREEN_H
#define SCREEN_H

#include <TFT_ST7735.h>
#include "RobotServo.hpp"
#include "Joystick.hpp"

#define MAX_ITEMS 10
#define MAIN_ITEMS 2
#define JOGGING_ITEMS 1
#define INFO_ITEMS 1

const int system_info_length = 3;
extern String system_info[3];
extern Joystick j1;
extern Joystick j2;
extern RobotServo SERVO__BASE;
extern RobotServo SERVO__BASE_ARM;
extern RobotServo SERVO__LINK_1;

class Screen {
private:
    TFT_ST7735 tft;
    int refresh_rate;
    unsigned long prev_ms;

    int curr_selection, max_selection;
    String menu_items[MAX_ITEMS];
    static const String main_items[MAIN_ITEMS];
    static const String jogging_items[JOGGING_ITEMS];
    static const String info_items[INFO_ITEMS];
    enum screen_mode {
        MAIN,
        JOGGING,
        INFO
    };
    enum screen_mode curr_mode, prev_mode;
    
    static const int main_menus[MAIN_ITEMS];
    static const int jogging_menus[JOGGING_ITEMS];
    static const int info_menus[INFO_ITEMS];

    void drawScreen();
public:
    Screen(int _refresh_rate);
    ~Screen();
    void screenSetup();
    void update();

    int getSelection() { return curr_selection; }
    void setSelection(int selection);

    void applySelection();
};

#endif