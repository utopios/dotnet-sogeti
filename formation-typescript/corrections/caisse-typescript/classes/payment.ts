export abstract class Payment {
    public datePayment : Date

    constructor() {
        this.datePayment = new Date()
    }
    
    abstract pay(amount: number): boolean;
}