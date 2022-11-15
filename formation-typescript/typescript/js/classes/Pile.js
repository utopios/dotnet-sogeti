"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Pile = void 0;
class Pile {
    elements = [];
    constructor() {
    }
    empiler(element) {
        this.elements.push(element);
    }
    depiler() {
        if (this.elements.length > 0) {
            this.elements.pop();
        }
    }
    getElement(id) {
        if (id < this.elements.length && id > 0)
            return this.elements[id];
        else
            return null;
    }
}
exports.Pile = Pile;
