# Exercice bâtiment - héritage

1. Classe Batiment
    1.1 Créer une classe Batiment avec l'attribut suivant :
        - adresse
    1.2 Créer les getter et les setter pour cette classe
    1.3 Créer une méthode toString() qui représente le bâtiment

2. Classe Maison
    2.1 Créer une classe maison qui hérite de Batiment
    2.2 Ajouter l'attribut suivant :
        - Pièces
    2.3 Créer les getter et les setter pour cette classe
    2.4 Créer une méthode toString() qui donne une représentation de la maison

3. Interface
    3.1 Créer un IHM qui permet de :
        - Créer un Batiment
        - Créer une Maison 
        - Afficher les bâtiments
        - Afficher les maisons

# Exercice 2

1. créer une variable « nom » qui n’accepte qu’un type string
2. créer une variable « speed » qui n’accepte que les  numbers et l’initialiser avec la valeur 25
3. créer une variable « isLoading » qui n’accepte que les  types booleans
4. créer une variable « colors » qui est un Array de strings. 
   Ensuite, effectuer un push de la valeur « red » +  console.log de la variable « colors »
5. créer une variable « number » qui ne peut être qu’un objet.
   Via l’indicateur de valeur « object », sans définir le contenu de l’objet. Ensuite, avec les propriétés suivantes :

    firstName: "Dupont"  
    age: 20
    isLoggedIn: true

    Afficher la valeur age via console.log
6. créer une variable « number » qui ne peut être qu’un objet.
    Préciser le type objet via attribution (assignation) tout en indiquant les propriétés suivantes :
    
    firstName: "Dupont"
    age: 20
    isLoggedIn: true

    Afficher la valeur age via console.log
7. créer une variable « number » qui ne peut être qu’un objet.
    - Laisser TypeScript définir le type objet via inférence tout  en indiquant les propriétés suivantes :
    
    firstName: "Dupont"
    age: 20
    isLoggedIn: true

    Afficher la valeur age via console.log
8. Créer une variable «	infos » qui ne peut être qu’un Tuple de seulement 2 valeurs. string et number dans cet ordre-là!

# Exercice Générique

Créer une classe pile générique qui permet :
    - D'empiler des éléments.
    - Depiler le dernier élément.
    - Récupérer un élément par son id

Les éléments de la pile seront stockés dans un tableau.
La pile fonctionnera uniquement avec des éléments qui ont un Id


# Exercise - Caisse enregistreuse

-	Vous pourrez utiliser une classe Caisse possédant une collection de produits et une collections de ventes
-	Vous pourrez utiliser une classe Produit comportant un numéro, un nom, un prix et un stock
-	Vous pourrez utiliser une classe Vente possédant un numéro, une liste de produits et une méthode permettant de
    valider la vente, ce qui confirmera le paiement et changera le stock des produits
-	Deux classes de paiements, une classe PaiementCB et une classe PaiementEspece, qui auront une méthode pour payer (pour les espèces, pensez aussi au champ monnaie)


# Exercice 1 - Power apps framework

- Créer un composant qui permet de saisir les informations d'un contact et afficher le contact en dessous du formulaire.
Un contact a un nom, prénom, email.
- Modifier le composant pour afficher une liste de contact ajoutée par le formulaire.

# Exercice 2 - 
Creer un composant slider avec des paramètre min et max et qui permet de récuper les valeurs du champ. (aide type range)