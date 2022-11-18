import { Game } from "./classes/game";
import {IInputs, IOutputs} from "./generated/ManifestTypes";
 /* eslint-disable */
export class IhabMorpionComponent implements ComponentFramework.StandardControl<IInputs, IOutputs> {

    private game:Game
    private _context:ComponentFramework.Context<IInputs>
    private _container:HTMLDivElement
    private _takePicutreEvent:EventListenerOrEventListenerObject
    /**
     * Empty constructor.
     */
    constructor()
    {

    }

    
   
    public init(context: ComponentFramework.Context<IInputs>, notifyOutputChanged: () => void, state: ComponentFramework.Dictionary, container:HTMLDivElement): void
    {
        this._context = context
        this._container = container
        //Création du game
        //récupération des informations du user directement par les settings
        let user = context.userSettings.userName != "" ? context.userSettings.userName : "player 1"
        console.log(user)
        let player2 = this._context.parameters.ChallengerPlayerProperty.raw != null ? this._context.parameters.ChallengerPlayerProperty.raw : "player 2"
        this.game = new Game(user, player2, context, container)
        this.createGrid()
        this.displayPlayers()
    }


    private createGrid():void {
        const h1 = document.createElement("h1")
        h1.innerText = "Morpion"
        this._container.appendChild(h1)
        
        for(let i=0; i< this.game.buttons.length; i++) {
            const line = document.createElement("div")
            for(let j= 0; j < this.game.buttons[i].length; j++) {
                line.appendChild(this.game.buttons[i][j])
            }
            this._container.appendChild(line)
        }
    }

    private displayPlayers():void {
        this._takePicutreEvent = this.takePicture.bind(this)
        
        const blockFirstPlayer = document.createElement("div")
        blockFirstPlayer.innerText = this.game.firstPlayer.name
        const button1 = document.createElement("button")
        button1.innerText = "ajouter photo"
        button1.setAttribute("id", "FirstPlayer")
        button1.addEventListener("click", this._takePicutreEvent)
        blockFirstPlayer.appendChild(button1)
        this._container.appendChild(blockFirstPlayer)
        const blockSecondPlayer = document.createElement("div")
        blockSecondPlayer.innerText = this.game.secondPlayer.name
        const button2= document.createElement("button")
        button2.innerText = "ajouter photo"
        button2.setAttribute("id", "SecondPlayer")
        button2.addEventListener("click", this._takePicutreEvent)
        blockSecondPlayer.appendChild(button2)
        this._container.appendChild(blockSecondPlayer)

    }

    private takePicture(event:Event):void {
        const button = event.target as HTMLButtonElement
        const player = button.getAttribute("id")
        this._context.device.captureImage().then(res => {
            if(player == "FirstPlayer") {
                this.game.firstPlayer.avatar = res.fileContent
            }
            else if(player == "SecondPlayer") {
                this.game.secondPlayer.avatar = res.fileContent
            }
        })
    }

    /**
     * Called when any value in the property bag has changed. This includes field values, data-sets, global values such as container height and width, offline status, control metadata values such as label, visible, etc.
     * @param context The entire property bag available to control via Context Object; It contains values as set up by the customizer mapped to names defined in the manifest, as well as utility functions
     */
    public updateView(context: ComponentFramework.Context<IInputs>): void
    {
        this._container.innerHTML = ""
        let user = context.userSettings.userName != "" ? context.userSettings.userName : "player 1"
        console.log(user)
        let player2 = this._context.parameters.ChallengerPlayerProperty.raw != null ? this._context.parameters.ChallengerPlayerProperty.raw : "player 2"
        this.game = new Game(user, player2, this._context, this._container)
        this.createGrid()
        this.displayPlayers()
    }

    /**
     * It is called by the framework prior to a control receiving new data.
     * @returns an object based on nomenclature defined in manifest, expecting object[s] for property marked as “bound” or “output”
     */
    public getOutputs(): IOutputs
    {
        return {
            ChallengerPlayerProperty: this._context.parameters.ChallengerPlayerProperty.raw!
        };
    }

    /**
     * Called when the control is to be removed from the DOM tree. Controls should use this call for cleanup.
     * i.e. cancelling any pending remote calls, removing listeners, etc.
     */
    public destroy(): void
    {
        // Add code to cleanup control if necessary
    }
}
