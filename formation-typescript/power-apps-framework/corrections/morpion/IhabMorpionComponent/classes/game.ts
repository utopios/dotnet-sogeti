import { IInputs } from "../generated/ManifestTypes"
import { Player } from "../interfaces/player"
/* eslint-disable */
export class Game {
    //A typer
    private _buttons: any = []
    public firstPlayer: Player
    public secondPlayer: Player
    private eventClickListener: EventListenerOrEventListenerObject
    private isFirstPlayer: boolean
    private _winner: string|undefined
    private _context:ComponentFramework.Context<IInputs>
    private _container:HTMLDivElement

    constructor(firstPlayerName: string | undefined, secondPlayerName: string | null,  context:ComponentFramework.Context<IInputs>, container:HTMLDivElement) {
        this._context = context
        this._container = container
        if (firstPlayerName! && secondPlayerName!) {
            this.firstPlayer = {
                name: firstPlayerName,
                mark: "X",
                avatar: undefined
            }

            this.secondPlayer = {
                name: secondPlayerName,
                mark: "O",
                avatar: undefined
            }
            this.isFirstPlayer = true
            this.eventClickListener = this.handleClick.bind(this)
            this.createGrid()
        }
    }

    get buttons() {
        return this._buttons
    }

    get winner() {
        return this._winner
    }

    private createGrid(): void {
        for (let i = 1; i <= 3; i++) {
            let line = []
            for (let j = 1; j <= 3; j++) {
                const button = document.createElement("button")
                button.classList.add("morpion_button")
                button.addEventListener('click', this.eventClickListener)
                line.push(button)
            }
            this._buttons.push(line)
        }
    }

    private handleClick(element: Event): void {
        const button = element.target as HTMLButtonElement
        if (button.innerText == "") {
            if (this.isFirstPlayer) {
                button.innerText = this.firstPlayer.mark
                button.classList.add("first_player")
            }
            else {
                button.innerText = this.secondPlayer.mark
                button.classList.add("second_player")
            }
            this.isFirstPlayer = !this.isFirstPlayer
            const response = this.testWin()
            if (response[0]) {
                
                //disable button
                for (let i = 0; i < this.buttons.length; i++) {
                    for (let j = 0; j < this.buttons[i].length; j++) {
                        this.buttons[i][j].disabled = true
                    }               
                }

                this._context.webAPI.createRecord("crd4d_ihab_table_winner", {"crd4d_player1": this.firstPlayer.name, "crd4d_player2": this.secondPlayer.name, "crd4d_winner": response[1]}).then(() => {                    
                    this._winner = response[1]
                    
                })
                const div = document.createElement("div")
                div.innerText = response[1]!
                this._container.appendChild(div)
            }
        }
    }

    private testSameValue(tabs: HTMLButtonElement[], value: string): boolean {
        let test: boolean = true
        for (let v of tabs) {
            if (v.innerText != value) {
                test = false
                break
            }
        }
        return test
    }
    private testWin(): [boolean, string | undefined] {
        //Pour chaque lignes et pour chaque cols, on test avec la méthode testSameValue avec chaque joueur
        let response: [boolean, string | undefined] = [false, undefined]
        //ligne
        for (let i = 0; i < this.buttons.length; i++) {
            const tabs = [...this.buttons[i]]
            if (this.testSameValue(tabs, this.firstPlayer.mark)) {
                response = [true, this.firstPlayer.name]
            }
            else if (this.testSameValue(tabs, this.secondPlayer.mark)) {
                response = [true, this.secondPlayer.name]
            }
        }
        if (!response[0]) {
            //cols
            for (let i = 0; i < this.buttons.length; i++) {
                const tabs: HTMLButtonElement[] = []
                for (let j = 0; j < this.buttons[i].length; j++) {
                    tabs.push(this.buttons[j][i])
                }
                if (this.testSameValue(tabs, this.firstPlayer.mark)) {
                    response = [true, this.firstPlayer.name]
                }
                else if (this.testSameValue(tabs, this.secondPlayer.mark)) {
                    response = [true, this.secondPlayer.name]
                }
            }
        }
        if (!response[0]) {
            //diag1
            const tabs: HTMLButtonElement[] = []
            for (let i = 0; i < this.buttons.length; i++) {
                for (let j = 0; j < this.buttons[i].length; j++) {
                    if(i == j)
                    tabs.push(this.buttons[j][i])
                }               
            }
            if (this.testSameValue(tabs, this.firstPlayer.mark)) {
                response = [true, this.firstPlayer.name]
            }
            else if (this.testSameValue(tabs, this.secondPlayer.mark)) {
                response = [true, this.secondPlayer.name]
            }
        }

        if (!response[0]) {
            //diag2
            const tabs: HTMLButtonElement[] = []
            for (let i = 0; i < this.buttons.length; i++) {
                for (let j = 0; j < this.buttons[i].length; j++) {
                    if( i+j+2 == 4)
                        tabs.push(this.buttons[j][i])
                }               
            }
            if (this.testSameValue(tabs, this.firstPlayer.mark)) {
                response = [true, this.firstPlayer.name]
            }
            else if (this.testSameValue(tabs, this.secondPlayer.mark)) {
                response = [true, this.secondPlayer.name]
            }
        }

        return response
    }
}