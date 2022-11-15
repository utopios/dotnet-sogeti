import { Payment } from "./payment";

export class CardPayment extends Payment {
    
    constructor() {
        super()
    }
    
    pay(amount: number): boolean {
        return amount%2 == 0
    }

}