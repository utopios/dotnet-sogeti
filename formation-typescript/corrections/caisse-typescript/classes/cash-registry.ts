import { Product } from "../interfaces/product";
import { WithId } from "../interfaces/with-id";
import { CardPayment } from "./card-payment";
import { Cart } from "./cart";
import { CashPayment } from "./cash-payment";

export class CashRegistry {
    products: (WithId & Product)[] = []
    carts: Cart[] = []

    static productCounter:number = 0

    constructor() {

    }

    addProduct(product:Product):boolean {
        const oldLength = this.products.length
        return this.products.push({...product, id: ++CashRegistry.productCounter}) == oldLength + 1        
    }

    getProductById(id:number) : (Product & WithId) | undefined {
        return this.products.find(p => p.id == id)
    }

    addProductToCart(idProduct:number, cart:Cart):boolean {
        const product = this.getProductById(idProduct)
        if(product != undefined) {
            const pExist = cart.products.find(p => p.id == product.id)
            if(pExist != undefined) {
                pExist.quantity++
            }
            else {
                cart.products.push({...product, quantity:1, reduction:0})
            }
            return true
        }
        return false
    }

    payWithCard(cart:Cart): boolean {
        const payment = new CardPayment()
        if(cart.valid(payment)) {
            this.carts.push(cart)
            return true
        }
        return false
    }

    payWithCash(cart:Cart, givenAmount:number) : [boolean, number] {
        const cashPayment = new CashPayment(givenAmount)
        if(cart.valid(cashPayment)) {
            this.carts.push(cart)
            return [true, cashPayment.returnMoney]
        }
        return [false, 0]
    }
}