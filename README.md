# SAE_2.4

## Pour commencer : comment utiliser Git ?

### Comment installer Git et clôner le dépôt sur sa machine locale ?

1] Installer Git sur sa machine puis taper dans l'invite de commande :

```sh
sudo apt install git
```

2] Configurer vos informations d'utilisateur :

```sh
git config --global user.name "[Prenom] [Nom]"
git config --global user.email "[login]@unistra.fr"
```

3] Côner le dépôt SAE_2.4 sur sa machine locale :

```sh
git clone https://git.unistra.fr/nathan.weiss/sae_2.4.git
```

Si toutes les étapes ont été respectées, vous avez maintenant un dossier `sae_2.4` sur votre machine qui contient tous les éléments du dépôt Git.

### Comment envoyer son travail ?

1] Pour commencer, il faut créer un fichier `.gitignore`

Un fichier `.gitignor`e sert à indiquer à Git quels fichiers ou dossiers il ne doit pas prendre en compte.

Dans un projet Visual Studio, le dossier `.vs` contient des fichiers temporaires et des paramètres locaux qui ne doivent pas être envoyés sur GitHub.

On crée donc un fichier `.gitignore` pour éviter les erreurs et garder le dépôt propre :

```sh
echo .vs/ > .gitignore
echo bin/ >> .gitignore
echo obj/ >> .gitignore
echo *.user >> .gitignore
echo *.pdb >> .gitignore
echo *.exe >> .gitignore
```
On peut ensuite regarder le contenu du fichier `.gitignore` avec :

```sh
type .gitignore
```

2] Ajouter tous les fichiers modifiés à la zone de préparation :

```sh
cd sae_2.4
git add .
```

On peut vérifier les dossiers/fichiers modifiés/ajoutés avec :

```sh
git status
```

3] Crée un commit (une sauvegarde de son travail à un instant donné) : 

```sh
git commit -m "nom_commit"
```

`-m "nom_commit"` permet d’ajouter un message pour décrire ce qui a été modifié, il n'est pas obligatoire.

4] Envoyer ses commits vers le dépôt distant pour le partager :

```sh
git push
```

###  Comment mettre à jour son clône ?

```sh
cd sae_2.4
git pull origin main
```

Il est important de mettre à jour son dépôt à chaque fois que l'on souhaite modifier un fichier dans celui-ci pour obtenir les mises à jours des autres commits.

## Répartition du travail

### Nathan WILHELM

    - Volets :

        2) Création d’une nouvelle mission puis affectation des membres et objectifs
        3) Récapitulatif complet des informations sur une mission
        4) Visualisation en mode 1 à 1 des événements survenus lors d’une mission donnée

### Oscar MAGOULES

    - Volets :

### Nathan WEISS

#### **Volets :**

    4)      Affichage des races aliens
    5)      Affichage des planètes
    7.1)    Afficher les cooéquipers d'un membre

#### **Création des images de l'application (sur Canva) :**

    [✓] Logo 'Stargate' + Icône d'application + Typo
    [✓] Logo des boutons du tableau de bord (4)
    [✓] Typo des titres (3)
    [✓] Images pour les specialités de l'équipage sous forme de logo (11)
    [✓] Images pour les grades des militaires (5)
    [✓] Images personalisées pour CHAQUE espèce extraterrestre (35)
    [✓] Images personalisées pour CHAQUE planète (11)

#### **Optimisation des volets**

    [✓] Réduction des "traits bugés" lorsque l'on fait défilé une liste d'éléments (missions + planètes + aliens)
    [✓] Optimisation de petites parties de code (notament pour régler le problème des "traits bugés")

#### **Desing**

    [✓] Desing complet du Volet 4 : Affichage des races aliens 
    [✓] Desing complet du Volet 5 : Affichage des planètes
    [✓] Desing complet du tableau de bord
    [✓] Desing complet d'une partie du Volet 7 (Affichage des cooéquipiers)  

#### **Ergonomie**

    [✓] Rendre ergonomique le Volet 4 : Affichage des races aliens
    [✓] Rendre ergonomique le Volet 5 : Affichage des planètes
    [✓] Rendre ergonomique le Tableau de bord
    [✓] Rendre ergonomique l'Affichage des cooéquipiers
