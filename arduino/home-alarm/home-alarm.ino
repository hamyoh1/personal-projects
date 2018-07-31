#include <ShiftedLCD.h>
#include <SPI.h>

#define ROT_ENC_BUTTON_PIN 5

#define BUZZER_PIN 8
#define RGB_RED_PIN 4
#define RGB_GREEN_PIN 3
#define RGB_BLUE_PIN 2
#define PIR_PIN A0

int pirVal = 0;

bool tripwire_en = true, prev_tripwire_en = true;

LiquidCrystal lcd(10);

enum Col {
  Red,
  Green,
  Blue
};

struct Colour {
  int red;
  int green;
  int blue;
};

void setup() {
  pinMode(ROT_ENC_BUTTON_PIN, INPUT);
  pinMode(BUZZER_PIN,OUTPUT);
  pinMode(RGB_RED_PIN,OUTPUT);
  pinMode(RGB_GREEN_PIN,OUTPUT);
  pinMode(RGB_BLUE_PIN,OUTPUT);
  pinMode(PIR_PIN, INPUT);
  lcd.begin(16,2);
  Serial.begin(9600);
}

void loop() {
  pirVal = digitalRead(PIR_PIN);
  Serial.println(pirVal);
  if (pirVal) {setRGB(Red); tripwire_en = false;}//buzz();
  else {setRGB(Green); tripwire_en = true;} //successBuzz();

  // LCD Stuff
  if (tripwire_en && !prev_tripwire_en) {
    lcd.clear();
    lcd.print("> DISABLE ALARM");
  } else if (!tripwire_en && prev_tripwire_en) {
    lcd.clear();
    lcd.print("> ENABLE ALARM");
  }
  if (!digitalRead(ROT_ENC_BUTTON_PIN)) {
    lcd.print("Button pressed!");
    delay(1000);
    lcd.clear();
  }

  prev_tripwire_en = tripwire_en;
}

void buzz() {
    digitalWrite(BUZZER_PIN, HIGH);
    delay(1000);
    digitalWrite(BUZZER_PIN, LOW);
    delay(1000);
    digitalWrite(BUZZER_PIN, HIGH);
    delay(1000);
    digitalWrite(BUZZER_PIN, LOW);
    delay(1000);
    digitalWrite(BUZZER_PIN, HIGH);
    delay(1000);
    digitalWrite(BUZZER_PIN, LOW);
    delay(1000);
}

void successBuzz() {
    digitalWrite(BUZZER_PIN, HIGH);
    delay(200);
    digitalWrite(BUZZER_PIN, LOW);
    delay(200);
    digitalWrite(BUZZER_PIN, HIGH);
    delay(200);
    digitalWrite(BUZZER_PIN, LOW);
    delay(200);
}

void setRGB(Col colour) {
  Colour c;
  switch(colour) {
    case Red:
      c = {255,0,0};
      break;
    case Green:
      c = {0,255,0};
      break;
    case Blue:
      c = {0,0,255};
      break;
    default:
      c = {255,255,255};
      break;
  }
  digitalWrite(RGB_RED_PIN, c.red);
  digitalWrite(RGB_GREEN_PIN, c.green);
  digitalWrite(RGB_BLUE_PIN, c.blue);
}

