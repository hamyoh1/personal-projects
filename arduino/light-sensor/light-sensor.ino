int ledPin = 8;
int value;

void setup() { 
  pinMode(ledPin, OUTPUT);
  Serial.begin(38400);
}

void loop() {
  value = analogRead(A0);
  if(value < 50) {
      digitalWrite(ledPin, HIGH);
  } else { digitalWrite(ledPin, LOW); }
  Serial.println(value, DEC);
  delay(200);
}
