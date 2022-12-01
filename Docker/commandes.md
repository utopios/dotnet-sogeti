## Démarrer un conteneur
docker run <options> <nom_image> <cmd_démarrage_à_executer_au_démarrage_du_conteneur>

## Executer une commande en ssh dans conteneur démarré
docker exec -it <id_container> <commande>

## Créer une image à partir d'un conteneur.
docker commit <id_container> <nom_image>

## accèder aux logs
docker logs <id_container>

### Exemple:
1. démarrer l'api rest dans un conteneur.
2. démarrer l'application blazor dans un conteneur.

## Création d'une image à partir d'un dockerfile
docker build -t <nom_image> <chemin_vers_le_dossier_avec_dockerfile>

## Exercice 
Démarrer l'api cash registry avec un dockerfile

1. docker build -t api-cash-registry-image . 
2. docker run -d -p 5183:5183 --name nom_container -it api-cash-registry-image sh
3. docker exec -it nom_container sh
4. à l'interieur du conteneur, on démarre l'application dotnet run


## Pour se connecter à acr
 az acr login --name m2iformation  

## Pour donner un alias à une image
docker tag api-cash-registry-image  m2iformation.azurecr.io/api-ihab:1

## pour push une image sur un acr
docker push m2iformation.azurecr.io/api-ihab:1

# Exercice 

Démarrer 3 conteneurs de service Azure

1. Pour la base de données, ensuite appliquer une migration sur cette base de données.
2. Api cash Registry
3. Blazor cash Registry

# Exercice 

Démarrer 2 app service

1. Pour la base de données, on utilise une instance de conteneurs.
2. Une app service pour l'api cash registry.
3. Une app service pour l'application blazor.