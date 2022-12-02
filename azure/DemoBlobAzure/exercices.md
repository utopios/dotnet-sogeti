# Exercice (Azure SQL et Blob)
- Le but est de créer une API REST qui permet :
    - d'enregistrer des Pokemons *Chaque pokemon a un nom et plusieurs images* uniquement pour les admin.
    - d'afficher la liste des pokémons.
    - à un utilisateur connécté d'attraper un pokémon (random)
    - d'afficher la liste des pokémons d'un utilisateur.

- On sauvegarde le nom et les urls d'images dans une base de données relationnelles azure sql.
- On sauvegarde les images dans un conteneurs azure storage blob.

- On deploie l'application dans azure app service.

- On souhaite avoir une IHM en blazor pour visualiser les fonctionnalités de l'API Rest(sans enregistrement pokemon).
- On deploie l'application blazor dans une app service.

