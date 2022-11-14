//après 2015
export class Personne {
    constructor(firstName, lastName) {
        //propriété set
        this.firstName = firstName
        this.lastName = lastName
    }

    methodAfficher() {
        console.log(this.firstName + " "+this.lastName)
    }

    afficherAvecMessage(message) {
        console.log(message)
        this.methodAfficher();
    }

    get firstName() {
        return this._firstName;
    }

    set firstName(value) {
        this._firstName = value
    }
}

export class Etudiant extends Personne {
    constructor(firstName, lastName, level) {
        super(firstName, lastName)
        this.level = level;
    }

    methodAfficher() {
        super.methodAfficher();
        console.log(this.level);
    }
}