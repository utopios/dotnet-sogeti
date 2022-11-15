interface Animal {

}
interface Poisson {
    nom: string,
    yeux:number
}

interface Chat extends Animal {
    nom: string,
    type:string
}

interface Couleur {
    clr: string
}

//Intersection de type
type TypePoissonRouge = Poisson & Couleur

const pr: Poisson & Couleur = {
    nom: "tt",
    yeux: 2,
    clr: "#cd2127"
}

//Union 
const c: Poisson | Chat = {
    nom: "tt",
    type: "sdfd",
    yeux: 10
}

type IsExtendedFromAnimal = Chat extends Animal ? string : number

type NotIsExtendedFromAnimal = Poisson extends Animal ? string : number