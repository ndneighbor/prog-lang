let multiply (xs, ys) =
    let rec matrix_mult xs ys =
        match xs with
        | [] -> []
        | x::xs -> List.map (fun f -> inner f x) ys :: matrix_mult xs ys
        matrix_mult xs (transpose ys)

let x = multiply ([[1;2;3];[4;5;6]], [[0;1];[3;2];[1;2]]);;