# Ahmed Kaissoumi

![](./kaissoumi_ahmed.jpg)

## Planification

Cette section, complétée lors de la première semaine, présente les tâches individuelles **hebdomadaires** prévues.

<!--
- Planification sur 9 semaines (8 semaines de cours et 1 semaine de rattrapage) présentant les tâches individuelles hebdomadaires prévues.
- Au moins une tâche par semaine. Les tâches ne peuvent pas se répéter et doivent être suffisamment précises.
- Les tâches doivent être cohérentes avec celles des autres membres de l’équipe et avec le concept du projet, et être mises à jour en continu.
- Critères :
    - Intention et concept clairs
    - Description approfondie de la conception sonore et visuelle
    - Planification détaillée du contenu multimédia à intégrer
    - Planification technique rigoureuse
-->

### Semaine 1


- S'assurer que le schéma de composants et que le budget soit faites.
- S'assurer de la compatibilité de chacun des composants.
- Apporter des modifications à la page .io concernant ces éléments.

- S'organiser avec le comité en communication pour trouver un nom qui reflète tous les projets

### Semaine 2

- À partir de la démo de la session précédente, continuer le développement afin d'avoir une démo produite à présenter aux portes ouvertes.
- Configuration des boutons / arduinos pour son utilisation en temps que contrôles dans le jeu
- Commencer la création partielle d'éléments UI et possiblement commencer leur intégration dans le contexte de notre démo

### Semaine 3

- Présentation de la démo aux portes ouvertes
- Continuer la création des différents éléments de UI liés au projet.
- Commencer ou continuer le placement l'ui sur Unity

### Semaine 4

- Avec les pièces reçus, et à partir de la démo, reconfigurer le code afin de pouvoir jouer avec les nouveaux composants


### Semaine 5

- Création de l'installation (orienté boutons/placement arduino et ordinateur)
- Continuer la création des différents éléments de UI et poursuivre la création de l'ui sur unity pour un produit plus avancé.
- Ajout d'ui dynamique basique (scores, vitesses ect)

### Semaine 6

- Présentation du produit
- Participation à la création de la bande annonce
- Participation à la création du dossier de presse


### Semaine 6.5

- Ajustement en lien avec les retours suite à la présentation

### Semaine 7

- Ajustement en lien avec les retours suite à la présentation

### Semaine 8

- Présentation du produit fini

## Journal de bord

Cette section, complétée **quotidiennement** pendant l’exécution du projet, documente le travail individuel réellement réalisé chaque jour.

<!--
- Une entrée par jour sur 8 semaines (8 semaines à partir de la semaine 2).
   - Un total d'au moins 40 entrées uniques!
- Chaque jour :
    - Documentstion visuelle et/ou sonore du travail effectué
    - Lien vers les billets GitHub résolus
- Démarche rigoureuse de validation de la qualité
- Démonstration d'autonomie.
- Exécution technique précise et complète.
- Évaluation réfléchie de la contribution individuelle au travail d’équipe.
-->

### Semaine 2

#### Lundi

- Planification en groupe sur les derniers ajustements concernant la direction dans laquelle on s’alignera (design, gameplay, installation).

#### Mardi

- Création d’une maquette qui représente notre installation. (Maquette obsolète et éronnée)
- Confirmation du budget et des composants avec Guillaume.

![](./medias/img/schema_obsolete_1.png)


#### Mercredi

- Journée passée à comprendre l’utilisation du bouton d’arcade, celui-ci étant incompatible en soit avec le pbhub, je n’ai pas fait grand-chose de plus.

![](./medias/img/bouton_arcade.jpg)

#### Jeudi

- Création des fichiers C++ qui correspondent à notre nouvelle réalité afin d’y établir les fondations de notre nouveau code (ceux de la démo précédente étant obsolètes et hors contexte).
- Ajout de code afin de pouvoir utiliser 6 keys et 3 faders sur 2 Arduino et 2 PbHub différents.
- Modification légère du fichier Pure Data de la démo précédente.

#### Vendredi

- Débogage du problème suivant : Arduino contrôlant la souris d’ordinateur (problème partiellement réglé).
- Ajout d’une animation de démarrage pour les Arduino.
- Ajout de l’OSC pour la communication entre les Arduino, Pure Data et Unity.
- Ajout de contrôles de base avec les faders sur Unity.

![](./medias/img/resolution_bug.jpg)



### Semaine 3

#### Lundi

- Création d'ui
- Tentative de débogage d'un problème de vitesse d'envoi via OSC (non réglé)

![](./medias/img/ui_1.png)
![](./medias/img/ui_menu.png)


#### Mardi

- Soudure des boutons et switchs
- Ajustement et intégration du code arduino pour l'utilisation OSC sur la scène 2 (first person) & événements aléatoires -> [lien](https://github.com/Babouin-Sibyllin/MissionDecollageDemo/commit/8e0f6d0d5be47ca52b9b2d240081f4b24e8ed712)

#### Mercredi

- Retour à la version antérieur suite à un bug majeur -> [lien](https://github.com/Babouin-Sibyllin/MissionDecollageDemo/commit/443264a740d750b8f16ee1ed3928d5aad38fe23d)
- Ajout de L'OSC dans unity -> [lien](https://github.com/Babouin-Sibyllin/MissionDecollageDemo/commit/8ec1d961d6c96222c8306fbb6b011ebdd416b89e)
- Ajout de certains élément d'ui dans unity [lien](https://github.com/Babouin-Sibyllin/MissionDecollageDemo/commit/fad0f44f99fc3e9c300bac110355f97c3a0f0fb3)

#### Jeudi

- Préparation présentation Démo
- Construction de l'installation
- Ajout de lumières aux keys

![](./medias/img/ajout_lumiere.jpg)
![](./medias/img/demo.jpg)


#### Vendredi

- Création d'une autre maquette (maintenant obsolète et éronnée)
![](./medias/img/schema_obsolete_2.png)

### Semaine 4

#### Lundi

- Rien n'a été fait ce jour là

#### Mardi

- Refonte de notre scénarisation 
- Résolution de problèmes liés à unity et platform.io (Merci à Guillaume et aux TTPS)
- Soudure 

#### Mercredi

- Implémentation partielle des boutons sur l'arduino nano 328 old bootloader

#### Jeudi

- Refonte de notre scénarimage et scénarisation, (la troisième fois étant finalement la bonne)

#### Vendredi

- Création d'ui spécifique aux jauges (énergie et chaleur) de notre jeu
![](./medias/img/JaugesTout.png)

### Semaine 5

#### Lundi

- Rien n'a été fait ce jour là

#### Mardi

- Résolution du problème suivant : À chaque pression sur le bouton, l'arduino s'éteignait complètement car ce dernier était branché du mauvais côté et causait des courts-circuits

- Résolution du problème suivant : Un bouton n'était pas détecté car le ground (5) de l'arduino nano était défectueux

#### Mercredi

- Implémentation complète des boutons sur les 3 arduinos + faders sur 1 arduino (Platform.io & PureData)
![](./medias/img/ajustementboutons.jpg.png)

#### Jeudi

- Implémentation partielle des boutons à nos nouvelles fonctionnalités en jeu (merci Mathieu & Justin) [lien](https://github.com/O-I-G-N-O-N/Mission-decollage/commit/c58ac9678d7a731cd4cf130b93ea95a4825e9846) 

#### Vendredi

- Rien n'a été fait ce jour là

### Semaine 6

#### Lundi

- Préparation à la présentation de mardi
- Assemblage en équipe de l'installation

![](./medias/img/installation.jpg)


#### Mardi

#### Mercredi

#### Jeudi

#### Vendredi

### Semaine 6.5

#### Lundi

#### Mardi

#### Mercredi

#### Jeudi

#### Vendredi

### Semaine 7

#### Lundi

#### Mardi

#### Mercredi

#### Jeudi

#### Vendredi

### Semaine 8

#### Lundi

#### Mardi

#### Mercredi

#### Jeudi

#### Vendredi



