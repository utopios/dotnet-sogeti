//après 2015
export class Personne {
    constructor(firstName, lastName) {
        this.firstName = firstName
        this.lastName = lastName
    }

    methodAfficher() {
        console.log(this.firstName + " "+this.lastName)
    }
}