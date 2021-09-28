module Background

open Browser.Dom

// Derived from https://developer.chrome.com/docs/extensions/mv3/getstarted/

let color = "#3aa757"

Chrome.Runtime.onInstalled.addListener( fun _ ->
    console.log("Hello world from extension example (webpack edition)")
    Chrome.Storage.Sync.set( {| color = color |} )
)
