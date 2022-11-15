import { Payment } from "./payment";

export class CashPayment extends Payment {
    
    private _givenAmount: number;
    private _returnMoney:number;
    constructor(givenAmount:number) {
        super()
        this._givenAmount = givenAmount 
    }

    get returnMoney() {
        return this._returnMoney
    }
    pay(amount: number): boolean {
        if(amount <= this._givenAmount) {
            this._returnMoney = this._givenAmount - amount
            return true
        }
        return false
    }

}