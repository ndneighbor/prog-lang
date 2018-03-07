type TERMINAL = IF|THEN|ELSE|BEGIN|END|PRINT|SEMICOLON|ID|EOF

let eat token = function 
| [] -> failwith "Early termination"
| x::xs ->
    if x = token
    then xs
    else failwith (sprintf "want %A, got %A" token x)

let rec L = function 
| [] -> failwith "Early termination or missing EOF"
| x::xs ->
    match x with
    | END -> printf "We are done here"
    | SEMICOLON -> xs |> S |> L
let rec S = function 
| [] -> failwith "Early termination or missing EOF"
| x::xs -> 
    match x with
    | IF -> xs |> L |> eat THEN |> S |> eat ELSE
    | THEN -> x::xs
    | BEGIN -> xs |> S |> L
    | PRINT -> E
    | EOF -> x::xs
    | _ -> failwith (sprintf "S: want 0 got %A" x)


let rec E = function
| [] -> failwith "Early termination or missing EOF"
| ID -> eat

// let accept = function
//     printfn "Its good"

// let error = function
//     failwith "Nope"

let test_program program =
  let result = program |> S
  match result with 
  | [] -> failwith "Early termination or missing EOF"
  | x::xs -> if x = EOF then accept else error

let checkSyntax = function
