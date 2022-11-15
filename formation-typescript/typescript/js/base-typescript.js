"use strict";
// let firstName: string = "ihab"
// let test: boolean = false
// let age:number = 35
// let nom: string = "zere"
// let firstArray: Array<number> = []
// firstArray.push(34)
Object.defineProperty(exports, "__esModule", { value: true });
const Personne_1 = require("./classes/Personne");
// let firstTuple : [string, number] = ["one", 24]
// let firstObjet:object = {
//     firstName:"ihab",
//     lastName: "abadi",
//     age:35
// }
// // console.log(firstObjet.age)
// //inférence
// let secondObjet = {
//     firstName:"ihab",
//     lastName: "abadi",
//     age:35
// }
// console.log(secondObjet.age)
// //par attribution
// let number: {
//     firstName: string,
//     lastName: string,
//     age:number
// } = {
//     firstName:"toto",
//     lastName: "tata",
//     age: 34
// }
// enum Role {
//     Admin,
//     public,
//     User,
// }
// console.log(Role.User)
// const testAny:any = true
// let str: unknown
// str = "hello"
// str = true
// console.log(typeof str)
//signature au fonction
function maFonction(arg1, arg2) {
    console.log(arg1);
    console.log(arg2);
}
const addition = (a, b) => {
    return a + b;
};
// function calcule(a:number, b:number, methodeCalcule:Function)  {
//     console.log(methodeCalcule(a,b))
// }
function calcule(a, b, methodeCalcule) {
    console.log(methodeCalcule(a, b));
}
const p1 = new Personne_1.Formateur("ihab", "abadi", 35, "typescript");
p1.methodeAfficher();
