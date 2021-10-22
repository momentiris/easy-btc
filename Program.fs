open Suave
open Suave.Filters
open Suave.Operators
open Suave.Successful

let app =
  choose [ GET
           >=> choose [ path "/goodbye" >=> OK "Good bye GET"
                        pathScan "/piglatin/%s" (fun (c) -> OK(c |> PigLatin.make)) ]

           POST
           >=> choose [ path "/hello" >=> OK "Hello POST"
                        path "/goodbye" >=> OK "Good bye POST" ] ]

startWebServer defaultConfig app
