// Okay lets say we want to take in two lists and append them

let rec append = function
    | ([], ys) -> ys
    | (xs, []) -> xs
    | (x::xs, ys) -> x :: append(xs,ys)

let rec firstlistlist xs = function
    | [] -> []
    | xs -> List.head xs
