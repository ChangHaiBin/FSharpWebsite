module Test001

open Suave
open Suave.Filters
open Suave.Operators
open Suave.Successful


let sleep milliseconds message: WebPart =
  fun (x : HttpContext) ->
    async {
      do! Async.Sleep milliseconds
      return! OK message x
    }

let app001 =
    choose
        [ GET >=> choose
            [ path "/hello" >=> OK "Hello GET";
              path "/goodbye" >=> OK "Good bye GET" ];
          POST >=> choose
            [ path "/hello" >=> OK "Hello POST";
              path "/goodbye" >=> OK "Good bye POST" ] ]
