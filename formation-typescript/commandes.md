1. ## Créer un module nodejs
npm init => à l'interieur du dossier module

2. ## Pour executer un fichier js avec nodejs
node <nom_du_fichier>


3. ## Créer un composant de type field
pac pcf init --namespace M2iComponents --name SampleInput --template field

# Pour Publier
1. ### Générer un build de notre composant
    - npm run build
2. ### Créer une solution (créer un dossier)
    - A l'interieur du dossier, on lance la commande pac solution init --publisher-name CustomSolution --publisher-prefix cs => pour initialiser une solution avec un nom et un prefix à utiliser 
3. ### On ajoute le composant dans notre solution
    - Pour ajouter le composant dans la solution on utilise la commande pac solution add-reference --path <chemin_composant>
4. ### Générer la solution
    - à l'interieur de la solution dotnet build
               

