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