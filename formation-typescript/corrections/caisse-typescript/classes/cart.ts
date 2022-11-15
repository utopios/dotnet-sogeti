import { Product } from "../interfaces/product";
import { WithId } from "../interfaces/with-id";
import { Payment } from "./payment";

export interface InCart {
    quantity: number,
    reduction: number
}

export class Cart implements WithId {
    id: number;
    private static counter:number = 0;
    public products: (WithId & Product & InCart)[] = []
    private _payment:Payment
    constructor() {
        this.id = ++Cart.counter
    }
    get total() {
        let _total = 0
        this.products.forEach(p => {
            _total += p.price * p.quantity
        })
        return _total
    }
    public valid(payment:Payment): boolean {
        this._payment = payment
        if(this._payment.pay(this.total)) {
            this.products.forEach(p => {
                p.stock -= p.quantity
            })
            return true
        }
        return false
    }
}