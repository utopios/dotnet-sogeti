import { timeStamp } from "console";
import {IInputs, IOutputs} from "./generated/ManifestTypes";

export class SliderIhab implements ComponentFramework.StandardControl<IInputs, IOutputs> {

    private _value:number
    private _notifyOutputChanged : () => void
    private labelElement: HTMLLabelElement
    private inputElement: HTMLInputElement
    private _container:HTMLDivElement
    private _context:ComponentFramework.Context<IInputs>
    private _eventUpdate: EventListenerOrEventListenerObject

    /**
     * Empty constructor.
     */
    constructor()
    {

    }

    /**
     * Used to initialize the control instance. Controls can kick off remote server calls and other initialization actions here.
     * Data-set values are not initialized here, use updateView.
     * @param context The entire property bag available to control via Context Object; It contains values as set up by the customizer mapped to property names defined in the manifest, as well as utility functions.
     * @param notifyOutputChanged A callback method to alert the framework that the control has new outputs ready to be retrieved asynchronously.
     * @param state A piece of data that persists in one session for a single user. Can be set at any point in a controls life cycle by calling 'setControlState' in the Mode interface.
     * @param container If a control is marked control-type='standard', it will receive an empty div element within which it can render its content.
     */
    public init(context: ComponentFramework.Context<IInputs>, notifyOutputChanged: () => void, state: ComponentFramework.Dictionary, container:HTMLDivElement): void
    {
        this._context = context
        this._container = document.createElement("div")
        this._notifyOutputChanged = notifyOutputChanged
        this._eventUpdate = this.updateValue.bind(this)
        this.inputElement = document.createElement("input")
        this.inputElement.setAttribute("type", "range")
        this.inputElement.setAttribute("min", this._context.parameters.MinProperty.formatted ? this._context.parameters.MinProperty.formatted : "0")
        this.inputElement.setAttribute("max", this._context.parameters.MaxProperty.formatted ? this._context.parameters.MaxProperty.formatted : "1000")
        this.inputElement.setAttribute("value", this._context.parameters.ValueProperty.formatted ? this._context.parameters.ValueProperty.formatted : "0")
        this.inputElement.addEventListener("input", this._eventUpdate)
        this.labelElement = document.createElement("label")
        this.labelElement.innerText =  this._context.parameters.ValueProperty.formatted ? this._context.parameters.ValueProperty.formatted : "0"
        this._container.appendChild(this.inputElement)
        this._container.appendChild(this.labelElement)
        container.appendChild(this._container)
    }

    public updateValue(): void {
        this._value = new Number(this.inputElement.value) as number
        console.log(this._value)
        this.labelElement.innerText = this.inputElement.value
        this._notifyOutputChanged()
    }
    /**
     * Called when any value in the property bag has changed. This includes field values, data-sets, global values such as container height and width, offline status, control metadata values such as label, visible, etc.
     * @param context The entire property bag available to control via Context Object; It contains values as set up by the customizer mapped to names defined in the manifest, as well as utility functions
     */
    public updateView(context: ComponentFramework.Context<IInputs>): void
    {
        this._value = this._context.parameters.ValueProperty.raw!
        this.inputElement.setAttribute("min", this._context.parameters.MinProperty.formatted ? this._context.parameters.MinProperty.formatted : "0")
        this.inputElement.setAttribute("max", this._context.parameters.MaxProperty.formatted ? this._context.parameters.MaxProperty.formatted : "1000")
        this.inputElement.setAttribute("value", this._context.parameters.ValueProperty.formatted ? this._context.parameters.ValueProperty.formatted : "0")
        this.labelElement.innerText = this._context.parameters.ValueProperty.formatted ? this._context.parameters.ValueProperty.formatted : "0"
    }

    /**
     * It is called by the framework prior to a control receiving new data.
     * @returns an object based on nomenclature defined in manifest, expecting object[s] for property marked as “bound” or “output”
     */
    public getOutputs(): IOutputs
    {
        return {
            ValueProperty: this._value
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
