let rec transpose matrix = 
    match matrix with   // matrix is a list<list<int>>
    | row::rows ->      // case when the list of rows is non-empty
        match row with    // rows is a list<int>
        | col::cols ->    // case when the row is non-empty
      // Take first elements from all rows of the matrix
          let first = List.map List.head matrix
          // Take remaining elements from all rows of the matrix
          // and then transpose the resulting matrix
          let rest = transpose (List.map List.tail matrix) 
          first :: rest
        | _ -> []
    | _ -> [] 
let rec inner xs ys =
    match (xs, ys) with
    | ([],[]) -> 0
    | ([],ys) -> failwith "Vector dimensions inconsistent"
    | (xs,[]) -> failwith "Vector dimensions inconsistent"
    | (x::xs, y::ys) -> x*y + inner xs ys


let multiply (xs, ys) =
    let rec matrix_mult xs ys =
        match xs with
        | [] -> []
        | x::xs -> List.map (fun f -> inner f x) ys :: matrix_mult xs ys
    matrix_mult xs (transpose ys);;


let x = multiply ([[1;2;3];[4;5;6]], [[0;1];[3;2];[1;2]]);;