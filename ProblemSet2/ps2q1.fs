type TERMINAL = IF|THEN|ELSE|BEGIN|END|PRINT|SEMICOLON|ID|EOF
open System.Xml.Xsl.Runtime
open System.Xml.Xsl.Runtime

let eat token = function 
| [] -> failwith "Early termination"
| x::xs ->
    if x = token
    then xs
    else failwith (sprintf "want %A, got %A" token x)

let rec E = function
| [] -> failwith "Early termination or missing EOF"
| ID::xs -> xs
| x::xs -> failwith "error"

let rec L = function 
| [] -> failwith "Early termination or missing EOF"
| x::xs ->
    match x with
    | END -> xs
    | SEMICOLON -> xs |> S |> L
and  S = function 
| [] -> failwith "Early termination or missing EOF"
| x::xs -> 
    match x with
    | IF -> xs |> L |> eat THEN |> S |> eat ELSE
    | THEN -> x::xs
    | BEGIN -> xs |> S |> L
    | PRINT -> E
    | EOF -> x::xs
    | _ -> failwith (sprintf "S: want 0 got %A" x)




let accept() = printfn "Its good"

let error() = printfn "Nope"

let test_program program =
  let result = program |> S
  match result with 
  | [] -> failwith "Early termination or missing EOF"
  | x::xs -> if x = EOF then accept() else error()
