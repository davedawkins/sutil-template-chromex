var path = require("path");

module.exports = {
    mode: "development",
    devtool: false,
    entry: {
        background: "./src/ChromeExtension/Background.fs.js" ,
        popup: "./src/ChromeExtension/Popup.fs.js"
    },
    output: {
        path: path.join(__dirname, "./dist"),
        filename: "[name].js",
    }
}
