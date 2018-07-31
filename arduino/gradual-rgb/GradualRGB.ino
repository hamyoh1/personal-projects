#define RGB_RED_PIN 9
#define RGB_GREEN_PIN 10
#define RGB_BLUE_PIN 11

long long t = 0;

void setup() {
  pinMode(RGB_RED_PIN, OUTPUT);
  pinMode(RGB_GREEN_PIN, OUTPUT);
  pinMode(RGB_BLUE_PIN, OUTPUT);
  Serial.begin(9600);
}

void loop() {
  double x1 = sin(t*PI/180);
  double x2 = sin((t+120)*PI/180);
  double x3 = sin((t+240)*PI/180);
  
  x1 = (x1 + 1) * 255 / 2;
  x2 = (x2 + 1) * 255 / 2;
  x3 = (x3 + 1) * 255 / 2;

  analogWrite(RGB_RED_PIN, int(x1));
  analogWrite(RGB_GREEN_PIN, int(x2));
  analogWrite(RGB_BLUE_PIN, int(x3));

  delay(200);
  t++;
}
