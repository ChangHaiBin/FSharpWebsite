// Learn more about F# at http://fsharp.org

open System
open Suave 
open System.Threading
open Test001


let createRandom () = 
    let rand = new System.Random() 
    let selectedNumber = rand.Next(0,10)
    selectedNumber.ToString()

[<EntryPoint>]
let main argv =
    //startWebServer defaultConfig (Successful.OK "Hello World")
    
    let cts = new CancellationTokenSource()
    let conf = { defaultConfig with cancellationToken = cts.Token }
    //let listening, server = startWebServerAsync conf (Successful.OK (createRandom ()))
      
      
    let listening, server = startWebServerAsync conf Test002.app002

    Async.Start(server, cts.Token)
    printfn "Make requests now"
    Thread.Sleep(100000)
      
    cts.Cancel()

    printfn "Hello World from F#!"
    0 // return an integer exit code
