let rec inner xs ys =
match (xs, ys) with
| ([],[]) -> 0
| ([],ys) -> failwith "Vector dimensions inconsistent"
| (xs,[]) -> failwith "Vector dimensions inconsistent"
| (x::xs, y::ys) -> x*y + inner xs ys