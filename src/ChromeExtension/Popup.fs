module Popup

// Derived from https://developer.chrome.com/docs/extensions/mv3/getstarted/

open Sutil
open Sutil.Styling
open type Feliz.length
open Fable.Core.JsInterop

let style = [
    rule "button" [
        Css.height (px 30)
        Css.width (px 30)
        Css.outlineStyleNone
        Css.margin (px 10)
        Css.border( px 0, Feliz.borderStyle.none, "")
        Css.borderRadius (px 2)
    ]
    rule "button.current" [
        Css.custom("box-shadow","0 0 0 2px white, 0 0 0 4px black")
    ]
]

let view() =
    let store = Store.make ""

    let colorToStyle c = if c = "" then "" else sprintf "background-color: %s" c

    Html.button [
        Bind.attr( "style", store |> Store.map colorToStyle )

        Ev.onClick (fun _ ->
            Chrome.Storage.Sync.get("color", fun value -> value?color |> Store.set store)
        )

        CoreElements.disposeOnUnmount [ store ]
    ] |> withStyle style

view() |> Program.mountElement "sutil-app"
