## Creating a Chrome Extension in F# Using Sutil ##

Learn more about Sutil at [sutil.dev](https://sutil.dev).

This example was derived from [Getting Started with Chrome Extensions](https://developer.chrome.com/docs/extensions/mv3/getstarted/).

### Getting Started

The extension is ready-built in the `./dist` folder. Clone the repo and try it out as follows:

(By the way, these are the same instructions you'll find [here](https://developer.chrome.com/docs/extensions/mv3/getstarted/))
- In Chrome, go to `chrome://extensions`
- Click `Load unpacked`
- Select the `dist` folder

If all is well, you'll be able test the extension as follows:

![ChromeExtension](https://user-images.githubusercontent.com/285421/135155734-782f5929-4ac8-46fb-9c18-53cfada3d91f.gif)


### Developing the Extension

- Clone the repo

- Initialize the environment

```bash
$ npm install
$ dotnet tool restore
```

- To build

```
$ npm run build
```

Upon each build, go back to the `chrome://extensions` page and `refresh` the extension.

### Console Output

Output from `Background.fs` will be visible in the developer window accessible from `Inspect views:
service worker` link, found on the `chrome://extensions` page.

Output from `Popup.js` will be visible from the developer window accessible when you `right-click -> Inspect` inside the window created from `popup.html` (i.e., where the button appears when you activate the extension)

### Browser APIs

Currently, there is minimal support for the `chrome.storage.*` and `chrome.runtime.*` etc APIs. This will be a work-in-progress, but it's fairly easy to move your project forward in the meantime, thanks to Fable's awesome interop capabilities.
