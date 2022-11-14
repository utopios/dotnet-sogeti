export class Batiment {

    constructor(adresse) {
        this.adresse = adresse;
    }

    get adresse() {
        return this._adresse;
    }

    set adresse(value) {
        this._adresse = value
    }

    toString() {
        return `Batiment : ${this._adresse}`
    }
}