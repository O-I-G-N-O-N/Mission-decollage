# Maquette (faisabilité)

## Scénarisation

---

## Scene 1

| Verbe action  | Condition de déclenchement                                                              | Effet visuel                                      | Effet sonore             | Effet interactif                          |
| ------------- | --------------------------------------------------------------------------------------- | ------------------------------------------------- | ------------------------ | ----------------------------------------- |
| **Installer** | Les interacteurs s’installent sur les chaises et mettent les écouteurs                  | La scène sélection de menu est affichée (pas sûr) | Musique de la scène menu | Aucun ou immersion dans l’ambiance        |
| **Appuyer**   | Un des interacteurs appuie sur un bouton pour commencer le jeu ou voir les instructions | Transition de scène                               | Son de confirmation      | Passage vers la scène instructions ou jeu |

---

## Scene 2

| Verbe action | Condition de déclenchement                                                                          | Effet visuel                                | Effet sonore                      | Effet interactif                            |
| ------------ | --------------------------------------------------------------------------------------------------- | ------------------------------------------- | --------------------------------- | ------------------------------------------- |
| **Appuyer**  | Après l’affichage de la scène jeu ; les joueurs doivent appuyer sur leurs propulseurs pour décoller | Clignotement du texte “Décollez !”          | Boucle sonore d’alarme            | La fusée décolle et transition vers le ciel |
| **Appuyer**  | Les joueurs doivent se coordonner pour faire monter la fusée                                        | Défilement du ciel, flammes des propulseurs | Sons des réacteurs et de la fusée | Coordination entre joueurs                  |

---

## Scene 3

| Verbe action           | Condition de déclenchement                                  | Effet visuel                              | Effet sonore                 | Effet interactif                      |
| ---------------------- | ----------------------------------------------------------- | ----------------------------------------- | ---------------------------- | ------------------------------------- |
| **Appuyer et pivoter** | Les joueurs ont décollé et doivent se diriger vers l’espace | Vue 3ᵉ personne, feu, nuages qui défilent | Bruits de vent et propulsion | Les actions influencent la direction  |
| **Appuyer et pivoter** | Obstacles présents sur le trajet                            | Apparition d’avions, oiseaux, etc.        | Bruit de moteur ou d’oiseaux | Coopération pour éviter les obstacles |

---

## Scene 4

| Verbe action           | Condition de déclenchement       | Effet visuel                   | Effet sonore                | Effet interactif                 |
| ---------------------- | -------------------------------- | ------------------------------ | --------------------------- | -------------------------------- |
| **Appuyer et pivoter** | Les joueurs atteignent l’espace  | Vue 3ᵉ personne, fond étoilé   | Coupure du vent, propulsion | Actions influencent la direction |
| **Appuyer et pivoter** | Obstacles spatiaux sur le chemin | Astéroïdes, débris, satellites | Message d’avertissement     | Coopération pour les éviter      |

---

## Scene 5

| Verbe action           | Condition de déclenchement        | Effet visuel                                             | Effet sonore                                  | Effet interactif                      |
| ---------------------- | --------------------------------- | -------------------------------------------------------- | --------------------------------------------- | ------------------------------------- |
| **Appuyer**            | Les joueurs décrochent la capsule | Vue 3ᵉ personne de la capsule, fond étoilé, Mars visible | Entrée atmosphérique, mécaniques, propulseurs | Actions influencent la direction      |
| **Appuyer et pivoter** | Après décrochage                  | Vue 3ᵉ personne de la capsule                            | Message de communication sur la manœuvre      | Coopération pour pivoter correctement |

---

## Scene 6

| Verbe action | Condition de déclenchement                | Effet visuel                     | Effet sonore                          | Effet interactif                   |
| ------------ | ----------------------------------------- | -------------------------------- | ------------------------------------- | ---------------------------------- |
| **Appuyer**  | Les joueurs doivent appuyer pour atterrir | Vue 3ᵉ personne, surface de Mars | Débris frappant la coque, propulseurs | Actions influencent l’atterrissage |

---

## Scene 7

| Verbe action | Condition de déclenchement        | Effet visuel                      | Effet sonore | Effet interactif    |
| ------------ | --------------------------------- | --------------------------------- | ------------ | ------------------- |
| **Quitter**  | Les joueurs quittent leurs sièges | Retour au menu. Affichage du menu | Sons du menu | Retour à la scène 1 |

---

## Équipements

- Carte son
- Projecteur
- 4 chaises
- 4 écouteurs
- Ordinateur
- 4 contrôleurs Arduino

---

## Logiciels

- Unity
- Pure Data
- VS code
- Maya/Blender

---

## Synoptique

![synoptique](../medias/images/synoptique.png)

---

## Plan d’implantation

![implantation](../medias/images/implantation.png)

---

## Budget

| Composant                                                   | Prix réel      | Prix attendu       | Liens                                                                                                                                                    |
| ----------------------------------------------------------- | -------------- | ------------------ | -------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Ordinateur - x1                                             | 500 $          | 0$ (emprunt école) |                                                                                                                                                          |
| Chaise avec accoudoir - x1                                  | 20-60$ l'unité | 20-60$ l'unité     |                                                                                                                                                          |
| Carte de son Behringer - x1                                 | 109$ CAD       | 0$ (emprunt école) | [Lien](https://www.long-mcquade.com/193012/Pro-Audio-Recording/Audio-Interfaces-DAW-Controllers/Behringer/U-Phoria-UMC202HD-2X2-USB-Audio-Interface.htm) |
| Casque hd 280 pro - x4                                      |                | 0$ (emprunt école) |                                                                                                                                                          |
| Epson PowerLite 535W Projector - x1                         | 929$ USD       | 0$ (emprunt école) | [Lien](https://www.projectorcentral.com/Epson-PowerLite_535W.htm)                                                                                        |
| [EOL] I/O Hub 1 to 6 Expansion Unit (MEGA328)               | 39.8$ USD      | 0$ (emprunt école) | [Lien](https://shop.m5stack.com/products/pb-hub?variant=17116939354202)                                                                                  |
| Contrôleur Arduino M5Stack ATOM Lite ESP32 - x4             | 30 $           | 0$ (emprunt école) | [Lien](https://shop.m5stack.com/products/atom-lite-esp32-development-kit)                                                                                |
| M5Stack I/O Hub 1 to 6 Expansion Unit (STM32F0) U040-B - x4 | 31.8$          | 0$ (emprunt école) | [Lien](https://docs.m5stack.com/en/unit/pbhub_1.1)                                                                                                       |
