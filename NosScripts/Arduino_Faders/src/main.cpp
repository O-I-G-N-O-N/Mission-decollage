#include <Arduino.h>
#include <M5_PbHub.h>
#include <M5_Encoder.h>
#include <FastLED.h>
#include <MicroOscSlip.h>


M5_PbHub myPbHub;
M5_Encoder myEncoder;

CRGB keyPixel;

int EtatEnMemoire = 1;



unsigned long monChronoDepart = 0; // Initialisation

#define FADER0_CH 0
#define FADER1_CH 1
#define FADER2_CH 2

// OSC : buffer de 128 octets pour les messages entrants
MicroOscSlip<128> monOsc(&Serial);

// ------------------------------------------------------------
// PARSEUR OSC
// ------------------------------------------------------------
 void myOscMessageParser(MicroOscMessage &receivedOscMessage)
{
  if (receivedOscMessage.checkOscAddress("/changementFader"))
  {
    int premierArgument = receivedOscMessage.nextAsInt();
    // Traitement ici...
  }
  else if (receivedOscMessage.checkOscAddress("/autreFader"))
  {
    // Autre message OSC
  }
}

// ------------------------------------------------------------
// SETUP
// ------------------------------------------------------------
void setup()
{
  FastLED.addLeds<WS2812, 27, GRB>(&keyPixel, 1);
  // ----[PBHUB]----
  Wire.begin();
  myPbHub.begin();
  myEncoder.begin();

  // ----[MICRO_OSC]----
  Serial.begin(115200);

  keyPixel = CRGB(255, 0, 0);
  FastLED.show();
  delay(1000);

  keyPixel = CRGB(0, 255, 0);
  FastLED.show();
  delay(1000);

  keyPixel = CRGB(0, 0, 255);
  FastLED.show();
  delay(1000);
}

// ------------------------------------------------------------
// LOOP
// ------------------------------------------------------------
void loop()
{
  // Lecture des faders
  int maLectureFaderGauche = myPbHub.analogRead(FADER0_CH);
  int maLectureFaderCentre = myPbHub.analogRead(FADER1_CH);
  int maLectureFaderDroit = myPbHub.analogRead(FADER2_CH);

  // Traitement OSC entrant
  // monOsc.onOscMessageReceived(myOscMessageParser);

  // Toutes les 20 ms
  if (millis() - monChronoDepart >= 20)
  {
    monChronoDepart = millis();

    monOsc.sendInt("/faderGauche", maLectureFaderGauche);
    monOsc.sendInt("/faderCentre", maLectureFaderCentre);
    monOsc.sendInt("/faderDroit", maLectureFaderDroit);

    // myEncoder.update();

    // int maLectureEncodeur = myEncoder.getEncoderRotation();
    // int maLectureChangementEncodeur = myEncoder.getEncoderChange();
    // int maLectureBoutonEncodeur = myEncoder.getButtonState();

    // LEDs des faders en vert
    // myPbHub.setPixelColor(FADER0_CH, 0, 0, 0, 255);
    // myPbHub.setPixelColor(FADER1_CH, 0, 0, 0, 255);
    // myPbHub.setPixelColor(FADER2_CH, 0, 0, 0, 255);

    // monOsc.sendInt("/faderGauche", maLectureFaderGauche);
    // monOsc.sendInt("/faderCentre", maLectureFaderCentre);
    // monOsc.sendInt("/faderDroit", maLectureFaderDroit);

    // Exemple de gestion d’un bouton (commenté)
    /*
    if (EtatEnMemoire != maLectureKey)
    {
      EtatEnMemoire = maLectureKey;
      if (maLectureKey == 0)
      {
        myPbHub.setPixelColor(KEY_CH, 0, 0, 0, 0);
        delay(1000);
      }
      else
      {
        myPbHub.setPixelColor(KEY_CH, 0, 0, 255, 0);
      }
    }
    */
  }
}
