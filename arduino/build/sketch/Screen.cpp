#include "Screen.hpp"

Screen::Screen(int _refresh_rate) {
    refresh_rate = _refresh_rate;
    curr_mode = MAIN;
    prev_mode = curr_mode;
    curr_selection = 0;
    tft = TFT_ST7735();
}

Screen::~Screen() { }

void Screen::screenSetup() {
    prev_ms = 0;
    tft.init();
    tft.fillScreen(ST7735_BLACK);
    tft.setRotation(3);
    drawScreen();
}

void Screen::update() {
    unsigned long time = millis();

    if ((time - prev_ms) > refresh_rate) {
        drawScreen();
        prev_ms = time;
    }
}

void Screen::drawScreen() {
    tft.fillScreen(ST7735_BLACK);
    tft.setCursor(0, 0);
    switch(curr_mode) {
        case MAIN:
            max_selection = MAIN_ITEMS - 1;
            for (int i = 0; i < MAIN_ITEMS; i++) {
                if (i == curr_selection) {
                    tft.setTextColor(ST7735_BLACK, ST7735_WHITE);
                } else {
                    tft.setTextColor(ST7735_WHITE, ST7735_BLACK);
                }
                tft.println(main_items[i]);
            }
            break;
        case JOGGING:
            max_selection = JOGGING_ITEMS - 1;
            for (int i = 0; i < JOGGING_ITEMS; i++) {
                if (i == curr_selection) {
                    tft.setTextColor(ST7735_BLACK, ST7735_WHITE);
                } else {
                    tft.setTextColor(ST7735_WHITE, ST7735_BLACK);
                }
                tft.println(jogging_items[i]);
            }
            break;
        case INFO:
            max_selection = INFO_ITEMS - 1;
            for (int i = 0; i < INFO_ITEMS; i++) {
                if (i == curr_selection) {
                    tft.setTextColor(ST7735_BLACK, ST7735_WHITE);
                } else {
                    tft.setTextColor(ST7735_WHITE, ST7735_BLACK);
                }
                tft.println(info_items[i]);
            }
            tft.setTextColor(ST7735_WHITE, ST7735_BLACK);
            for (int j = 0; j < system_info_length; j++) {
                tft.println(system_info[j]);
            }
            break;
        default:
            max_selection = 0;
            break;
    }
    tft.setTextColor(ST7735_WHITE, ST7735_BLACK);
}

void Screen::setSelection(int selection) {
    // change these first 2 if statements if we want looping behaviour
    if (selection < 0) curr_selection = 0;
    else if (selection > max_selection) curr_selection = max_selection;
    else curr_selection = selection;
}

// TODO: Check that this function is okay
void Screen::applySelection() {
    // NEED TO CHANGE THIS FUNCTION, curr_selection isn't equivalent with which mode to change to
    // E.g, if you're on MAIN, and your curr_selection is 0 (jogging), you'll go to MAIN rather than the Jogging screen
    curr_mode = curr_selection;
    curr_selection = 0;

    switch(curr_mode){ 
        case MAIN:
            curr_mode = main_menus[curr_selection];
            break;
        case JOGGING:
            curr_mode = jogging_menus[curr_selection];
            break;
        case INFO:
            curr_mode = info_menus[curr_selection];
            break;
        default:
            break;
    }
    drawScreen();
}

static const String Screen::main_items[] = { "Jog Joints", "Information" };
static const String Screen::jogging_items[] = { "Back" };
static const String Screen::info_items[] = { "Back" };
static const int Screen::main_menus[] = {screen_mode::JOGGING, screen_mode::INFO};
static const int Screen::jogging_menus[] = {screen_mode::MAIN};
static const int Screen::info_menus[] = {screen_mode::MAIN};