import * as readline from "readline-sync"
import { Batiment } from "./Batiment.js"
import { Maison } from "./Maison.js"
export class Ihm {
    constructor() {
        this.batiments = []
        this.maisons = []
    }

    ajouterMaison(){
        const adresse = readline.question("Merci de saisir l'adresse : ")
        const pieces = readline.question("Merci de saisir le nombre de pièces : ")
        const maison = new Maison(adresse, pieces)
        this.maisons.push(maison)
    }

    ajouterBatiment(){
        const adresse = readline.question("Merci de saisir l'adresse : ")
        const batiment = new Batiment(adresse)
        this.batiments.push(batiment)
    }

    afficherBatiments() {
        this.batiments.forEach(b => {
            console.log(b.toString())
        })
    }

    afficherMaisons() {
        this.maisons.forEach(m => {
            console.log(m.toString())
        })
    }

    start() {
        let choix;
        do {
            console.log("1 -- Ajouter batiment ")
            console.log("2 -- Ajouter maison ")
            console.log("3 -- Afficher maisons ")
            console.log("4 -- Afficher batiments ")
            choix = readline.question("merci de saisir votre choix : ")  
            switch(choix) {
                case "1":
                    this.ajouterBatiment()
                break;
                case "2":
                    this.ajouterMaison();
                    break
                case "3":
                    this.afficherMaisons();
                    break;
                case "4":
                    this.afficherBatiments();    
            }   
        }while(choix != '0')
    }

}