import { Utilisateur } from "../interfaces/interfaces"

export abstract class Personne implements Utilisateur {
    private _firstName:string
    private _lastName: string
    private _age:number
    id: number
    
    constructor(firstName:string, lastName:string, age:number) {
        this.firstName = firstName
        this.lastName = lastName
        this.age = age
    }

    public set lastName(value:string) {
        this._lastName = value
    }

    public get lastName() {
        return this._lastName
    }

    public set firstName(value:string) {
        this._firstName = value
    }

    public get firstName() {
        return this._firstName
    }

    public get age() {
        return this._age
    }

    public set age(value) {
        this._age = value
    }
    methodeAfficher():void {
        console.log(this.firstName + " "+ this.lastName+ " "+this.age)
    }
}

export class Formateur extends Personne {
    private _formation:string
    constructor(firstName, lastName, age, formation) {
        super(firstName, lastName, age)
        this._formation = formation
    }

    methodeAfficher(): void {
        super.methodeAfficher()
        console.log(this._formation)
    }
}