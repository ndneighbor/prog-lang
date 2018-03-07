let curry a = (fun x -> fun y -> a(x,y))

let curry2 f x y = f (x,y)

let uncurry a = (fun (x,y) -> a x y)

let uncurry2 f (x,y) = f x y