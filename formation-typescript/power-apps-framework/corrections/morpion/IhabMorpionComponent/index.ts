import { Game } from "./classes/game";
import {IInputs, IOutputs} from "./generated/ManifestTypes";

export class IhabMorpionComponent implements ComponentFramework.StandardControl<IInputs, IOutputs> {

    private game:Game
    private _context:ComponentFramework.Context<IInputs>
    private _container:HTMLDivElement
    /**
     * Empty constructor.
     */
    constructor()
    {

    }

    
    /* eslint-disable */
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
        const blockFirstPlayer = document.createElement("div")
        blockFirstPlayer.innerText = this.game.firstPlayer.name
        this._container.appendChild(blockFirstPlayer)
        const blockSecondPlayer = document.createElement("div")
        blockSecondPlayer.innerText = this.game.secondPlayer.name
        this._container.appendChild(blockSecondPlayer)

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
