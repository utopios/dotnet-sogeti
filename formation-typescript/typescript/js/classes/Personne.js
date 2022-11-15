"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Formateur = exports.Personne = void 0;
class Personne {
    _firstName;
    _lastName;
    _age;
    constructor(firstName, lastName, age) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
    }
    set lastName(value) {
        this._lastName = value;
    }
    get lastName() {
        return this._lastName;
    }
    set firstName(value) {
        this._firstName = value;
    }
    get firstName() {
        return this._firstName;
    }
    get age() {
        return this._age;
    }
    set age(value) {
        this._age = value;
    }
    methodeAfficher() {
        console.log(this.firstName + " " + this.lastName + " " + this.age);
    }
}
exports.Personne = Personne;
class Formateur extends Personne {
    _formation;
    constructor(firstName, lastName, age, formation) {
        super(firstName, lastName, age);
        this._formation = formation;
    }
    methodeAfficher() {
        super.methodeAfficher();
        console.log(this._formation);
    }
}
exports.Formateur = Formateur;
