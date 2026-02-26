#include <Arduino.h>
#include <MicroOscSlip.h>

// --- IDENTIFIANT UNIQUE PAR ARDUINO ---
const int DEVICE_ID = 3;   // ⚠️ changer pour 2 et 3 sur les autres cartes

// --- CONFIGURATION DES ENTREES / LEDS ---
const int buttonPins[] = {2, 6, 9, 10};
const int ledPins[]    = {3, 8, };
const bool hasLed[]    = { true, true, false, false };

enum { numInputs = sizeof(buttonPins) / sizeof(buttonPins[0]) };

int lastReading[numInputs];
int buttonState[numInputs];
unsigned long lastDebounceTime[numInputs];
const unsigned long debounceDelay = 50;

// --- MICRO OSC SLIP ---
MicroOscSlip<128> osc(&Serial);

void setup() {
  Serial.begin(115200);

  for (int i = 0; i < numInputs; ++i) {
    pinMode(buttonPins[i], INPUT_PULLUP);

    if (hasLed[i]) {
      pinMode(ledPins[i], OUTPUT);
      analogWrite(ledPins[i], 255);
    }

    int init = digitalRead(buttonPins[i]);
    lastReading[i] = init;
    buttonState[i] = init;
    lastDebounceTime[i] = 0;
  }
}

void loop() {
  unsigned long now = millis();

  for (int i = 0; i < numInputs; ++i) {
    int reading = digitalRead(buttonPins[i]);

    if (reading != lastReading[i]) {
      lastDebounceTime[i] = now;
    }

    if ((now - lastDebounceTime[i]) > debounceDelay) {
      if (reading != buttonState[i]) {
        buttonState[i] = reading;

        int value = (buttonState[i] == LOW ? 1 : 0);

        // --- ENVOI OSC AVEC ID UNIQUE ---
        char address[32];
        sprintf(address, "/device%d/input%d", DEVICE_ID, i + 1);
        osc.sendInt(address, value);

        // --- LED ---
        if (hasLed[i]) {
          analogWrite(ledPins[i], value ? 0 : 255);
        }
      }
    }

    lastReading[i] = reading;
  }
}
