//
// FAKE script adapter for FSI
//
// Adapter details from here:
//      https://github.com/fsharp/FAKE/issues/2517
//
// Use this adapter template if you're suffering from this:
//      Error: Package manager key 'paket' was not registered
// Explanation here:
//      https://stackoverflow.com/questions/66665009/fix-for-package-manager-key-paket-was-not-registered-in-build-fsx
//
// Usage:
//   % dotnet fsi build.fsx
//   % dotnet fsi build.fsx --target <target>

#r "nuget: System.Reactive" // Prevent "Could not load file or assembly ..." error when using adapter
#r "nuget: Fake.Core.Target"
#r "nuget: Fake.DotNet.Cli"

open System
open System.IO
open Fake.Core
open Fake.DotNet


// Boilerplate for adapter
System.Environment.GetCommandLineArgs()
|> Array.skip 2 // skip fsi.exe; build.fsx
|> Array.toList
|> Fake.Core.Context.FakeExecutionContext.Create false __SOURCE_FILE__
|> Fake.Core.Context.RuntimeContext.Fake
|> Fake.Core.Context.setExecutionContext

// ---------------------------------------------------
// -- Your targets and regular FAKE code goes below --

Target.create "usage" (fun _ ->
    Console.WriteLine("Targets: build")
)

Target.create "build" (fun _ ->
    DotNet.exec id "fable" "src/ChromeExtension/ChromeExtension.fsproj --run webpack --config webpack.config.js" |> ignore
)

Target.create "build2" (fun _ ->
    DotNet.exec id "fable" "src/ChromeExtension/Background.fsproj --run webpack --config webpack.background.js" |> ignore
    DotNet.exec id "fable" "src/ChromeExtension/Popup.fsproj --run webpack --config webpack.popup.js" |> ignore
)

Target.runOrDefault "build"
