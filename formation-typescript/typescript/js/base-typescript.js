let firstName = "ihab";
let test = false;
let age = 35;
let firstArray = [];
firstArray.push(34);
let firstTuple = ["one", 24];
let firstObjet = {
    firstName: "ihab",
    lastName: "abadi",
    age: 35
};
var Role;
(function (Role) {
    Role[Role["Admin"] = 0] = "Admin";
    Role[Role["public"] = 1] = "public";
    Role[Role["User"] = 2] = "User";
})(Role || (Role = {}));
console.log(Role.User);
const testAny = true;
let str;
str = "hello";
str = true;
console.log(typeof str);
