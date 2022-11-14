let firstName: string = "ihab"
let test: boolean = false
let age:number = 35

let firstArray: Array<number> = []
firstArray.push(34)

let firstTuple : [string, number] = ["one", 24]

let firstObjet:object = {
    firstName:"ihab",
    lastName: "abadi",
    age:35
}

enum Role {
    Admin,
    public,
    User,
}
console.log(Role.User)

const testAny:any = true
let str: unknown
str = "hello"
str = true
console.log(typeof str)