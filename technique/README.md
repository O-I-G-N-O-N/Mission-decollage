# Technique

## Équipements

- **Ordinateur** – x1  
  Utilité : Lancer le jeu, uploader le code sur les arduinos, lancer PureData

- **Epson PowerLite 1980OWU Projector** – x1  
  Utilité : Projeter au mur le jeu

- **Contrôleur Arduino M5Stack ATOM Lite ESP32** – x1  
  Utilité : Recevoir et transmettre la base du code aux autres logiciels (PureData, Unity)

- *[PBHUB] I/O Hub 1 to 6 Expansion Unit (MEGA328)** – x4  
  Utilité : Étendre le nombre de composants à utiliser
  Justification du nombre : Un par station pour avoir une proximité avec les autres composants et nous laisser une marge pour les composants futurs

- **Encodeur** – x1  
  Utilité : Reçoit les rotations du joueur et les transmet au contrôleur. Contrôle les fumées de côtés de la fusée.

- **BOUTON POUSSOIR (MOMENTARY)** – x6  
  Utilité : Reçoit les pressions du joueur et les transmet au contrôleur. Permet de remplir des objectifs / régler des problèmes

- **CABLE ETHERNET** – x3  
   Utilité : Deux câbles Ethernet sont utilisés pour connecter le projecteur et l’ordinateur à la salle Matrice, et un autre câble Ethernet relie le transmitter au receiver afin d’afficher le contenu du PC sur le projecteur.

- **TOGGLE SWICH (SAFETY)** - x3
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

![implantation](../medias/images/rendu_1.jpg)

![implantation](../medias/images/rendu_2.jpg)

![implantation](../medias/images/rendu_3.jpg)

---

<!--
Plans d'implantation 2D et 3D
-->

## Budget

| Produit           | Quantité | Extra | Prix réel        |
|-------------------|----------|-------|------------------|
| [M5Stack Atom](https://shop.m5stack.com/products/atom-lite-esp32-development-kit)  | x2       | 0     | 0 (emprunt)      |
| [Pbhub](https://docs.m5stack.com/en/unit/pbhub_1.1)         | x2       | 0     | 0 (emprunt)      |
| [3.96](https://docs.m5stack.com/en/unit/396port)          | x11      | 0     | 0 (emprunt)      |
| [Bouton](https://www.aliexpress.com/item/1005005628118782.html?spm=a2g0o.productlist.main.18.4a3d388634NrbU&aem_p4p_detail=20260121135432670561894485250000384086&algo_pvid=4600c93b-a553-41a2-8eec-76b69ecde3fe&algo_exp_id=4600c93b-a553-41a2-8eec-76b69ecde3fe-15&pdp_ext_f=%7B%22order%22%3A%221081%22%2C%22eval%22%3A%221%22%2C%22fromPage%22%3A%22search%22%7D&pdp_npi=6%40dis%21CAD%213.03%211.61%21%21%212.14%211.14%21%402101c59117690324729232757e58d1%2112000033804112921%21sea%21CA%210%21ABX%211%210%21n_tag%3A-29910%3Bd%3A4fbbddb2%3Bm03_new_user%3A-29895%3BpisId%3A5000000197831921&curPageLogUid=uNJA9qUuVpPy&utparam-url=scene%3Asearch%7Cquery_from%3A%7Cx_object_id%3A1005005628118782%7C_p_origin_prod%3A&search_p4p_id=20260121135432670561894485250000384086_4)        | x6       | +3    | 14.49 $ CAD ~    |
| [Fader](https://www.aliexpress.com/item/1005007393023800.html)         | x3       | +3    | 9.66 $ CAD ~     |
| [Rotari Switch](https://www.aliexpress.com/item/1005008518194722.html?spm=a2g0o.productlist.main.28.4a0f6162LyhXpU&aem_p4p_detail=20260121123146193860413551400000323070&algo_pvid=3e9a1355-6508-454f-9fec-d82b8a898d8c&algo_exp_id=3e9a1355-6508-454f-9fec-d82b8a898d8c-27&pdp_ext_f=%7B%22order%22%3A%22343%22%2C%22eval%22%3A%221%22%2C%22fromPage%22%3A%22search%22%7D&pdp_npi=6%40dis%21CAD%212.87%212.59%21%21%212.03%211.83%21%402101d9ef17690275059556466ee322%2112000045526129764%21sea%21CA%210%21ABX%211%210%21n_tag%3A-29910%3Bd%3A4fbbddb2%3Bm03_new_user%3A-29895&curPageLogUid=BP2lQwJsMEQu&utparam-url=scene%3Asearch%7Cquery_from%3A%7Cx_object_id%3A1005008518194722%7C_p_origin_prod%3A&search_p4p_id=20260121123146193860413551400000323070_7) | x3       | +3    | 15.54 $ CAD ~    |
| [Switch](https://www.aliexpress.com/item/1005004068738380.html?spm=a2g0o.productlist.main.23.4a0f6162LyhXpU&algo_pvid=3e9a1355-6508-454f-9fec-d82b8a898d8c&algo_exp_id=3e9a1355-6508-454f-9fec-d82b8a898d8c-22&pdp_ext_f=%7B%22order%22%3A%2234%22%2C%22spu_best_type%22%3A%22price%22%2C%22eval%22%3A%221%22%2C%22fromPage%22%3A%22search%22%7D&pdp_npi=6%40dis%21CAD%211.04%211.04%21%21%215.12%215.12%21%402101d9ef17690275059556466ee322%2112000027933069880%21sea%21CA%210%21ABX%211%210%21n_tag%3A-29910%3Bd%3A4fbbddb2%3Bm03_new_user%3A-29895&curPageLogUid=x6FJzV2QFUwG&utparam-url=scene%3Asearch%7Cquery_from%3A%7Cx_object_id%3A1005004068738380%7C_p_origin_prod%3A#nav-specification)        | x3       | +3    | 6.24 $ CAD ~     |
| [Encodeur](https://www.aliexpress.com/item/1005009727108504.html?spm=a2g0o.productlist.main.50.1b22c3ec0A2mN5&algo_pvid=0de8ed4f-6a0d-4596-a3ff-a3f9c5d02e9d&algo_exp_id=0de8ed4f-6a0d-4596-a3ff-a3f9c5d02e9d-49&pdp_ext_f=%7B%22order%22%3A%2299%22%2C%22eval%22%3A%221%22%2C%22fromPage%22%3A%22search%22%7D&pdp_npi=6%40dis%21CAD%218.73%211.61%21%21%2142.95%217.90%21%402101ee6617691166885166032edbf1%2112000049962984185%21sea%21CA%210%21ABX%211%210%21n_tag%3A-29910%3Bd%3A7ce0c33c%3Bm03_new_user%3A-29895%3BpisId%3A5000000197831921&curPageLogUid=mXQ1uvbyUIcx&utparam-url=scene%3Asearch%7Cquery_from%3A%7Cx_object_id%3A1005009727108504%7C_p_origin_prod%3A)      | x1       | +2    | 4.83 $ CAD ~     |


