# Maquette (faisabilité)

## Scénarisation

## Scene 1

| Verbe action  | Condition de déclenchement                                                                 | Effet visuel                                      | Effet sonore             | Effet interactif                          |
| ------------- | ------------------------------------------------------------------------------------------ | ------------------------------------------------- | ------------------------ | ----------------------------------------- |
| **Installer** | Les interacteurs s’installent sur les chaises et mettent les écouteurs                     | La scène sélection de menu est affichée (pas sûr) | Musique de la scène menu | Aucun ou immersion dans l’ambiance        |
| **Appuyer**   | Les interacteurs appuient sur un bouton pour commencer le jeu et recevoir les instructions | Transition de scène                               | Son de confirmation      | Passage vers la scène instructions ou jeu |

---

## Scene 2

| Verbe action | Condition de déclenchement     | Effet visuel                                                                   | Effet sonore                                                                                    | Effet interactif                                            |
| ------------ | ------------------------------ | ------------------------------------------------------------------------------ | ----------------------------------------------------------------------------------------------- | ----------------------------------------------------------- |
| **Observer** | Les joueurs ont démarré le jeu | Un tutoriel est affiché à l’écran, indiquant les étapes pour utiliser la fusée | Sons d’environnement terrestres, voix de tutoriel, petite musique d’ambiance                    | Les joueurs sont invités à tester leur pouvoir sur la fusée |
| **Écouter**  | Les joueurs ont démarré le jeu | Un tutoriel est affiché à l’écran indiquant les étapes à suivre                | Sons du tutoriel pour reconnaître les différentes alertes, sons d’environnement, petite musique | Les joueurs doivent écouter et distinguer les sons d’alerte |

---

## Scene 3

| Verbe action  | Condition de déclenchement | Effet visuel                | Effet sonore                                                         | Effet interactif                                                     |
| ------------- | -------------------------- | --------------------------- | -------------------------------------------------------------------- | -------------------------------------------------------------------- |
| **Manipuler** | Les joueurs ont décollé    | Vue 3ᵉ personne de la fusée | Réacteurs, fusée, débris terrestres, communications tour de contrôle | Manipuler bouton et angle pour diriger la fusée vers sa destination  |
| **Écouter**   | Les joueurs ont décollé    | Vue 3ᵉ personne de la fusée | Réacteurs, fusée, débris terrestres, communications tour de contrôle | Écouter les alertes pour détecter un éventuel problème avec la fusée |

---

## Scene 4

| Verbe action | Condition de déclenchement              | Effet visuel                                                                   | Effet sonore                          | Effet interactif                  |
| ------------ | --------------------------------------- | ------------------------------------------------------------------------------ | ------------------------------------- | --------------------------------- |
| **Se lever** | Les joueurs ont réussi ou échoué le jeu | Vue 3ᵉ personne de la fusée atterrissant à destination ou détruite (game over) | Sons de festivité ou de découragement | Aucune, sauf appuyer pour rejouer |

---

## Logiciels

- **Unity**  
  Création du projet, des menus et du jeu  
  Gestion des scènes  
  Réception et traitement de l’OSC avec l’extension *extOSC* disponible sur l’Asset Store

- **Pure Data**  
  Utilisation de *pdchoco* & *comport*  
  Gestion de l’OSC et traitement et transfert des données reçus du contrôleur arduino sur Unity

- **Visual Studio Code & PlatformIO**  
  Développement et programmation sur le contrôleur arduino

- **Maya / Blender**  
  Création des assets 3D et de leurs animations nécessaires au jeu

- **Photoshop & Illustrator**  
  Création des assets 2D  
  Design des interfaces et éléments graphiques

- **Reaper**  
 Conception sonore & modification des sons de notre banque de son

- **Langages de programmation**  
  **C#** (Unity)  
  **C++** (Arduino)

---

## Synoptique

![synoptique](../medias/images/synoptique.png)

---

## Plan d’implantation

![implantation](../medias/images/implantation.png)

![implantation](../medias/images/planStudio.png)

![implantation](../medias/images/rendu_1.jpg)

![implantation](../medias/images/rendu_2.jpg)

![implantation](../medias/images/rendu_3.jpg)

---

## Liste

- **Ordinateur** – x1  
  Utilité : Lancer le jeu, uploader le code sur les arduinos, lancer PureData

- **Chaise avec accoudoir** – x4  
  Utilité : Permettre aux joueurs de s'installer, les contrôleurs Arduinos seront installés sur les accoudoirs

- **Casques audio** – x4  
  Utilité : Permettre aux joueurs d'entendre les musiques et sons du jeu

- **Epson PowerLite 1980OWU Projector** – x1  
  Utilité : Projeter au mur le jeu

- **Contrôleur Arduino M5Stack ATOM Lite ESP32** – x1  
  Utilité : Recevoir et transmettre la base du code aux autres logiciels (PureData, Unity)

- **[PBHUB] I/O Hub 1 to 6 Expansion Unit (MEGA328)** – x4  
  Utilité : Étendre le nombre de composants à utiliser
  Justification du nombre : Un par station pour avoir une proximité avec les autres composants et nous laisser une marge pour les composants futurs

- **Grove hub** – x4  
  Utilité : Étendre le nombre de composants à utiliser
  Justification du nombre : Un par station pour avoir une proximité avec l'encodeur

- **Encodeur** – x4  
  Utilité : Reçoit les rotations du joueur et les transmet au contrôleur

- **Key Unit** – x4  
  Utilité : Reçoit les pressions du joueur et les transmet au contrôleur

- **Carte son Behringer** – x1  
  Utilité : Recevoir l'audio du jeu et le transmettre à 4 casques simultanément


## Budget

| Composant | Prix réel (unité) | Prix réel total | Prix attendu | Liens |
|-----------|-------------------|-----------------|--------------|-------|
| Ordinateur – x1 | 500 CAD | **500 CAD** | 0 CAD (emprunt école) | |
| Chaise avec accoudoir – x1 | 20–60 CAD | **20–60 CAD** | 20–60 CAD | |
| Casque HD 280 Pro – x4 | — | — | 0 CAD (emprunt école) | |
| Carte de son Behringer – x1 | 109 CAD | **109 CAD** | 0 CAD (emprunt école) | [Lien](https://www.long-mcquade.com/193012/Pro-Audio-Recording/Audio-Interfaces-DAW-Controllers/Behringer/U-Phoria-UMC202HD-2X2-USB-Audio-Interface.htm) |
| Epson PowerLite 1980WU Projector – x1 | 1,844 USD ≈ 2,580.74 CAD | **2,580.74 CAD** | 0 CAD (emprunt école) | [Lien](https://epson.ca/For-Work/Projectors/Meeting-Room/PowerLite-1980WU-WUXGA-3LCD-Projector/p/V11H620020) |
| Contrôleur Arduino M5Stack ATOM Lite ESP32 – x1 | 30 USD ≈ 41 CAD | **41 CAD** | 0 CAD (emprunt école) | [Lien](https://shop.m5stack.com/products/atom-lite-esp32-development-kit) |
| M5Stack I/O Hub 1 to 6 Expansion Unit (STM32F0) U040-B – x4 | 7.95 USD ≈ 10 CAD | **40 CAD** | 0 CAD (emprunt école) | [Lien](https://docs.m5stack.com/en/unit/pbhub_1.1) |
| Encodeur – x4 | 7.95 USD ≈ 10 CAD | **40 CAD** | 0 CAD (emprunt école) | [Lien](https://shop.m5stack.com/products/encoder-unit) |
| M5Stack GROVE – x4 | 5$ CAD | **20 CAD** | 0 CAD (emprunt école) | [Lien](https://ca.robotshop.com/products/m5stack-grove-port-1-to-3-hub-unit) |
