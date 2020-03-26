module Test002

open Suave
open Suave.Filters
open Suave.Operators
open Suave.Successful


//let qqqqq = (^^)

//let greetings q =
//    defaultArg (Option.ofChoice (q ^^ "name")) "World" |> sprintf "Hello %s"

//let sample : WebPart = 
//    path "/hello" >=> choose 
//        [
//            GET  >=> request (fun r -> OK (greetings r.query));
//            POST >=> request (fun r -> OK (greetings r.form));
//            RequestErrors.NOT_FOUND "Found no handlers" 
//        ]

let randDouble () =
    let rand = new System.Random()
    rand.NextDouble()

let app002 =
    choose
        [ GET >=> choose
            [ path "/hello" >=> request (fun r -> 
                printfn "%O" r.query
                printfn "%O" r.path
                OK (sprintf "The random number is %f" (randDouble())));
              path "/goodbye" >=> OK "Good bye GET" ];
          POST >=> choose
            [ path "/hello" >=> OK "Hello POST";
              path "/goodbye" >=> OK "Good bye POST" ] ]
