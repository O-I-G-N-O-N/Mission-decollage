// FILE main.cpp
#include <Arduino.h>
#include <Wire.h>
#include <M5_PbHub.h>
#include <FastLED.h>
#include <MicroNetEthernet.h>
#include <MicroOscUdp.h>

CRGB atomPixel;
#define BROCHE_ATOM_PIXEL 27
M5_PbHub myPbHub;

#define FADER0_CH 0
#define FADER1_CH 1
#define FADER2_CH 2

const char *nameToResolve = "C1712-07"; // Do not append ".local"
MicroNetEthernet myMicroNet(MicroNetEthernet::Configuration::ATOM_POE_WITH_ATOM_LITE);

EthernetUDP udp;
#define MY_PORT 8887
#define CIBLE_PORT 7776
MicroOscUdp<1024> osc(udp);

unsigned long lastMillisSent = 0;

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

void setup()
{
  Serial.begin(115200);
  delay(100);
  Wire.begin();
  delay(100);
  myPbHub.begin();
  delay(100);

  FastLED.addLeds<WS2812, BROCHE_ATOM_PIXEL, GRB>(&atomPixel, 1);

  atomPixel = CRGB(255, 0, 255); FastLED.show(); delay(1000);
  atomPixel = CRGB(255, 0, 255); FastLED.show(); delay(1000);
  atomPixel = CRGB(0, 0, 255);   FastLED.show(); delay(1000);
  atomPixel = CRGB(255, 0, 0);   FastLED.show();

  char myName[MICRO_NET_NAME_MAX_LENGTH] = "atom-";
  myMicroNet.appendMacToCString(myName, MICRO_NET_NAME_MAX_LENGTH, 3);
  myMicroNet.begin(myName);

  Serial.print("My IP is: ");   Serial.println(myMicroNet.getIP());
  Serial.print("My name is: "); Serial.println(myName);

  atomPixel = CRGB(255, 255, 0); FastLED.show();

  IPAddress ipCible = myMicroNet.resolveName(nameToResolve);
  Serial.print("Resolved IP for "); Serial.print(nameToResolve);
  Serial.print(" is: ");          Serial.println(ipCible);

  atomPixel = CRGB(0, 255, 0); FastLED.show();

  udp.begin(MY_PORT);
  osc.setDestination(ipCible, CIBLE_PORT);  // destination pour l'envoi UDP

  Serial.println("Starting loop");
}

void loop()
{
  myMicroNet.update();

 
  //osc.onOscMessageReceived(myOscMessageParser);

  // Lecture des faders
  int maLectureFaderGauche = myPbHub.analogRead(FADER0_CH);
  int maLectureFaderCentre = myPbHub.analogRead(FADER1_CH);
  int maLectureFaderDroit  = myPbHub.analogRead(FADER2_CH);


  if (millis() - lastMillisSent > 10)
  {
    lastMillisSent = millis();
    osc.sendInt("/faderGauche", maLectureFaderGauche);  
    osc.sendInt("/faderCentre", maLectureFaderCentre);  
    osc.sendInt("/faderDroit",  maLectureFaderDroit);   
  }
}