# Technique

## Équipements

- **Ordinateur** – x1  
  Utilité : Lancer le jeu, uploader le code sur les arduinos, lancer PureData

- **Epson PowerLite 1980OWU Projector** – x1  
  Utilité : Projeter au mur le jeu

- **Haut-parleur** - x2
  Utilité : Diffusion du son

- **Carte son Behringer UMC202HD** - x1
  Utilié : Transmettre le son aux haut-parleurs

- **Câble XLR** - 2x
  Utilité : Connecter la carte son à l'haut-parleur

- **Contrôleur Arduino M5Stack ATOM Lite ESP32** – x1  
  Utilité : Recevoir et transmettre la base du code aux autres logiciels (PureData, Unity)

- **[PBHUB] I/O Hub 1 to 6 Expansion Unit (MEGA328)** – x4  
  Utilité : Étendre le nombre de composants à utiliser
  Justification du nombre : Un par station pour avoir une proximité avec les autres composants et nous laisser une marge pour les composants futurs

- **Encodeur** – x1  
  Utilité : Reçoit les rotations du joueur et les transmet au contrôleur. Contrôle les fumées de côtés de la fusée.

- **BOUTON POUSSOIR (MOMENTARY)** – x6  
  Utilité : Reçoit les pressions du joueur et les transmet au contrôleur. Permet de remplir des objectifs / régler des problèmes

- **CABLE ETHERNET** – x3  
   Utilité : Deux câbles Ethernet sont utilisés pour connecter le projecteur et l’ordinateur à la salle Matrice, et un autre câble Ethernet relie le transmitter au receiver afin d’afficher le contenu du PC sur le projecteur.

- **TOGGLE SWITCH (SAFETY)** - x3
  Utilité: Améliorer l'expérience en ajoutant différentes composantes, autre que des boutons. Servent à activer/désactiver les réacteurs

- **ROTARY SWITCH** - x3
  Utilité: Améliorer l'expérience en ajoutant différentes composantes, autre que des boutons. Servent à activer le lancement de la fusée / remplir des objectifs / régler des problèmes

- **FADERS** - x3
  Utilité: Reçoit la position du fader attribué par le joueur. Permet de contrôler la puissance des réacteurs.

- **UNIT 3.96** - x12
  Utilité: Permet de gérer 2 inputs par composants.

  ---
## Logiciels

- **Unity**  
  Création du projet, des menus et du jeu  
  Gestion des scènes  
  Réception et traitement de l’OSC avec l’extension _extOSC_ disponible sur l’Asset Store

- **Pure Data**  
  Utilisation de _pdchoco_ & _comport_  
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

- Contrôle connecté à un controleur Arduino
- Audio connecté à la carte de son Behringer UMC202HD avec des longs cables XLR
- La vidéo est transmise depuis un ordinateur connecté par un câble HDMI à un émetteur. Cet émetteur HDMI est relié à un récepteur HDMI au moyen d’un câble Ethernet. Le récepteur est ensuite connecté au projecteur à l’aide d’un câble HDMI.

---

## Plans

![implantation](../medias/images/implantation.png)

![implantation](../medias/images/planStudio.png)

![implantation](../medias/images/concept_vue_01.jpg)

![implantation](../medias/images/concept_vue_02.jpg)

---

<!--
Plans d'implantation 2D et 3D
-->


## Budget

#### AliExpress
| Produit | Quantité | Extra | Prix réel |
|--------|----------|-------|-----------|
| [M5Stack Atom](https://shop.m5stack.com/products/atom-lite-esp32-development-kit) | x2 | 0 | 0 (emprunt) |
| [PBHub](https://docs.m5stack.com/en/unit/pbhub_1.1) | x2 | 0 | 0 (emprunt) |
| [Unit 3.96](https://docs.m5stack.com/en/unit/396port) | x11 | 0 | 0 (emprunt) |
| [Bouton](https://www.aliexpress.com/item/1005005628118782.html) | x6 | +3 | 14.49 $ CAD ~ |
| [Fader](https://www.aliexpress.com/item/1005007393023800.html) | x3 | +3 | 9.66 $ CAD ~ |
| [Rotary Switch](https://www.aliexpress.com/item/1005008518194722.html) | x3 | +3 | 15.54 $ CAD ~ |
| [Toggle Switch](https://www.aliexpress.com/item/1005004068738380.html) | x3 | +3 | 6.24 $ CAD ~ |
| [Encodeur](https://www.aliexpress.com/item/1005009727108504.html) | x1 | +2 | 4.83 $ CAD ~ |
| [Bois](https://www.homedepot.ca/product/alexandria-moulding-3-4-inch-x-2-ft-x-4-ft-spruce-handy-panel/1000148919) | x10 | 0 | 310.27 $ CAD ~ |
| [Adhesive](https://www.homedepot.ca/product/lepage-pl-premium-polyurethane-construction-adhesive-interior-exterior-waterproof-295-ml/1000403473) | x1 | 0 | 9.18 $ CAD ~ |
| [Primer](https://www.homedepot.ca/product/zinsser-bulls-eye-1-2-3-interior-exterior-water-base-primer-for-all-surfaces-in-tintable-white-946-ml/1000123370) | x1 | 0 | 21.01 $ CAD ~ |
| [Peinture](https://www.homedepot.ca/product/rust-oleum-universal-interior-exterior-metallic-paint-primer-spray-paint-in-flat-soft-iron-312g/1000655367) | x1 | 0 | 29.87 $ CAD ~ |
| [Vis](https://www.homedepot.ca/product/paulin--6-x-1-inch-flat-head-phillips-drive-fine-thread-drywall-screws-100pcs/1000140793) | x1 | 0 | 5.28 $ CAD ~ |
| **TOTAL** |  |  | **426.37 $ CAD ~** |

#### Abra Electronics
| Produit | Quantité | Prix réel |
|--------|----------|-----------|
| [M5Stack Atom](https://shop.m5stack.com/products/atom-lite-esp32-development-kit) | x2 | 0 (emprunt) |
| [PBHub](https://docs.m5stack.com/en/unit/pbhub_1.1) | x2 | 0 (emprunt) |
| [Unit 3.96](https://docs.m5stack.com/en/unit/396port) | x11 | 0 (emprunt) |
| [Bouton](https://abra-electronics.com/electromechanical/switches/pushbutton-switches-led/latching/pbs-led-2206wh-l.html) | x6 | 60.65 $ CAD ~ |
| [Fader](https://abra-electronics.com/passive-components/potentiometers/slide-potentiometer-pc-mount/com-11620-linear-taper-slide-potentiometer-10k-small-pcb-mount.html) | x3 | 9.28 $ CAD ~ |
| [Rotary Switch](https://addison-electronique.com/fr/interrupteur-rotatif-illumine-1-position-45-n-o-nf-rouge.html) | x3 | 48.27 $ CAD ~ |
| [Toggle Switch](https://abra-electronics.com/electromechanical/switches/toggle-switches/com-11314-toggle-switch-and-cover-illuminated-white-clone.html) | x3 | 16.91 $ CAD ~ |
| [Encodeur](https://abra-electronics.com/electromechanical/encoders/377-rotary-encoder-with-knob-377.html) | x1 | 9.38 $ CAD ~ |
| [Bois](https://www.homedepot.ca/product/alexandria-moulding-3-4-inch-x-2-ft-x-4-ft-spruce-handy-panel/1000148919) | x10 | 310.27 $ CAD ~ |
| [Adhesive](https://www.homedepot.ca/product/lepage-pl-premium-polyurethane-construction-adhesive-interior-exterior-waterproof-295-ml/1000403473) | x1 | 9.18 $ CAD ~ |
| [Primer](https://www.homedepot.ca/product/zinsser-bulls-eye-1-2-3-interior-exterior-water-base-primer-for-all-surfaces-in-tintable-white-946-ml/1000123370) | x1 | 21.01 $ CAD ~ |
| [Peinture](https://www.homedepot.ca/product/rust-oleum-universal-interior-exterior-metallic-paint-primer-spray-paint-in-flat-soft-iron-312g/1000655367) | x1 | 29.87 $ CAD ~ |
| [Vis](https://www.homedepot.ca/product/paulin--6-x-1-inch-flat-head-phillips-drive-fine-thread-drywall-screws-100pcs/1000140793) | x1 | 5.28 $ CAD ~ |
| **TOTAL** |  | **520.10 $ CAD ~** |

