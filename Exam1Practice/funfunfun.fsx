let rec fib1 = function
| 0 -> 0I
| 1 -> 1I
| n -> fib1(n-1) + fib1(n-2)

//Apparently there is an issue with printing big ints, who knew

fsi.AddPrinter (fun (x:bigint) -> string x + "I")

let mk_expon times one =
    let rec expon x n = 
        if n = 0 then one
        elif n%2 = 0 then expon (times x x) (n/2)
        else times x (expon x (n-1))
    expon

//Apparently this is an exponentiation function

let expon1 = mk_expon (*) 1

let expon2 = mk_expon (+) ""

let matmult (a: bigint, b, c, d) (e, f, g, h) =
    (a*e+b*g, a*f+b*h, c*e+d*g, c*f+d*h)

let identity = (1I, 0I, 0I, 1I)

let expon3 = mk_expon matmult identity

let fib2 n =
    let (a,b,c,d) = expon3 (1I,1I,1I,0I) n
    c

