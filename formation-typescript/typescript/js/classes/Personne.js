"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Personne = void 0;
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
        console.log();
    }
}
exports.Personne = Personne;
