import { Player } from "../interfaces/player"
 /* eslint-disable */
export class Game {
    //A typer
    private _buttons:any= []
    public firstPlayer: Player
    public secondPlayer:Player
    private eventClickListener: EventListenerOrEventListenerObject
    private isFirstPlayer:boolean
    
    constructor(firstPlayerName:string|null, secondPlayerName:string|null) {
        if(firstPlayerName! && secondPlayerName!) {
            this.firstPlayer = {
                name: firstPlayerName,
                mark:"X",
                avatar:undefined
            }

            this.secondPlayer = {
                name: secondPlayerName,
                mark:"O",
                avatar:undefined
            }
            this.isFirstPlayer = true
            this.eventClickListener = this.handleClick.bind(this)
            this.createGrid()  
        }
    }

    get buttons() {
        return this._buttons
    }

    private createGrid(): void {
        for(let i=1; i <= 3; i++) {
            let line = []
            for(let j=1; j <= 3; j++) {
                const button = document.createElement("button")
                button.classList.add("morpion_button")
                button.addEventListener('click', this.eventClickListener)
                line.push(button)
            }
            this._buttons.push(line)
        }
    }

    private handleClick(element:Event):void {
        const button = element.target as HTMLButtonElement
        if(button.innerText == "") {
            if(this.isFirstPlayer) {
                button.innerText = this.firstPlayer.mark
                button.classList.add("first_player")
            }
            else {
                button.innerText = this.secondPlayer.mark
                button.classList.add("second_player")
            }
            this.isFirstPlayer = !this.isFirstPlayer
        }
    }
}