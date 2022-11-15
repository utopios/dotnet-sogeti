export class Pile<T> {
    private elements:T[] = []

    constructor() {

    }

    public empiler(element:T) : void {
        this.elements.push(element)
    }

    public depiler(): void {
        if(this.elements.length > 0) {
            this.elements.pop()
        }
    }

    public getElement(id:number) : T {
        if(id < this.elements.length && id > 0)
            return this.elements[id]
        else
            return undefined
    }
}