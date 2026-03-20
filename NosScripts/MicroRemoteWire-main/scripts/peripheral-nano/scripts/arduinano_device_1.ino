// FILE main.cpp
#include <Arduino.h>
#include <Wire.h>
#include <MicroRemoteWirePeripheral.h>
#include <MicroOscSlip.h>

constexpr uint8_t PERIPHERAL_I2C_ADDR = 0x42;
// --- IDENTIFIANT UNIQUE PAR ARDUINO ---
const int DEVICE_ID = 1;   // ⚠️ changer pour 2 et 3 sur les autres cartes

// --- CONFIGURATION DES ENTREES / LEDS ---
const int buttonPins[] = {2, 4, 5, 2};
const int ledPins[]    = {3, 5};
const bool hasLed[]    = { true, true, false, false};

enum { numInputs = sizeof(buttonPins) / sizeof(buttonPins[0]) };

int lastReading[numInputs];
int buttonState[numInputs];
unsigned long lastDebounceTime[numInputs];
const unsigned long debounceDelay = 50;

// --- MICRO OSC SLIP ---
MicroOscSlip<128> osc(&Serial);

MicroRemoteWirePeripheral peripheral;

// ==========================
// I2C
// ==========================
void onReceive(int numBytes)
{
  peripheral.onReceive(Wire, numBytes);
}

void onRequest()
{
  peripheral.onRequest(Wire);
}

// ==========================
// SETUP
// ==========================
void setup()
{
  Serial.begin(115200);
  Serial.println("begin");
  Wire.begin(PERIPHERAL_I2C_ADDR);
  Wire.onReceive(onReceive);
  Wire.onRequest(onRequest);

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
