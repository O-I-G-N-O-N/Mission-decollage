#include <Arduino.h>

const int buttonPins[] = {2, 4, 8, 9};
const int ledPins[] = {3, 5, 6, 10};

enum { numPairs = sizeof(buttonPins) / sizeof(buttonPins[0]) };

int lastReading[numPairs];
int buttonState[numPairs];
unsigned long lastDebounceTime[numPairs];
const unsigned long debounceDelay = 50; // ms

// Helper: fade LED to target brightness
void fadeTo(int ledPin, int targetBrightness) {
  int current = analogRead(ledPin); // not valid for OUTPUT, so track separately if needed
  // Instead, we’ll just sweep from 0–255
  int start = (targetBrightness == 0) ? 255 : 0;
  int end   = targetBrightness;
  int step  = (end > start) ? 5 : -5;

  for (int b = start; b != end; b += step) {
    analogWrite(ledPin, b);
    delay(10); // adjust speed of fade
  }
  analogWrite(ledPin, end);
}

void setup() {
  for (int i = 0; i < numPairs; ++i) {
    pinMode(buttonPins[i], INPUT_PULLUP);
    pinMode(ledPins[i], OUTPUT);
    analogWrite(ledPins[i], 255); // default ON (full brightness)
    lastReading[i] = HIGH;
    buttonState[i] = HIGH;
    lastDebounceTime[i] = 0;
  }
  Serial.begin(115200);
}

void loop() {
  unsigned long now = millis();
  for (int i = 0; i < numPairs; ++i) {
    int reading = digitalRead(buttonPins[i]);

    if (reading != lastReading[i]) {
      lastDebounceTime[i] = now;
    }

    if ((now - lastDebounceTime[i]) > debounceDelay) {
      if (reading != buttonState[i]) {
        buttonState[i] = reading;
        if (buttonState[i] == LOW) {
          // Button pressed → fade out
          fadeTo(ledPins[i], 0);
        } else {
          // Button released → fade in
          fadeTo(ledPins[i], 255);
        }
      }
    }
    lastReading[i] = reading;
  }
}
