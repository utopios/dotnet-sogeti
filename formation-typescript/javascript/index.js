import { Etudiant, Personne } from "./Personne.js"
// import DefaultNameImport from "./default-export-example.js"
// import * as DefaultNameImport from "./default-export-example.js"
//Déclaration de variables
const varConst = "test const variable";
let total = 0;
total += 1;
total += 10;

const personnes = []
//Créer des fonctions 
// => avec le mot clé function
// function MaFonction() {
//     console.log("je suis une fonction");
// }

// avec expression lambda depuis 2015

// const MaFonction = () => {
//     console.log("je suis une fonction lambda");
// }

// MaFonction();

// console.log(varConst);
// console.log(total);

//une fonction permet de créer des objets

// function Personne(firstName, lastName)   {
//     this.firstName = firstName;
//     this.lastName = lastName;
//     this.methodAfficher = () => {
//         console.log(this.firstName + " "+ this.lastName);
//     }
// }

const p1 = new Personne("toto", "tata");
const p2 = new Personne("titi", "minet");
const e1 = new Etudiant("e1 firstname", "e2 lastname", "bac+2")
personnes.push(p1)
personnes.push(p2)
personnes.push(e1)
// for(let i=0; i < personnes.length; i++) {
//     personnes[i].methodAfficher();
// }

// for(let p of personnes) {
//     p.methodAfficher();
// }

personnes.forEach(p => {
    p.methodAfficher();
    // p.afficherAvecMessage(["toto",34, new Date()])
});

console.log(p1.firstName);

// console.log(DefaultNameImport.default)