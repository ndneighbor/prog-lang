# Writing Effiicent Functional Programs

In this section we are concerned about the Asymtotic efficiency when it comes to rocessing lists.

We might want to look at various pitfalls that might causes issues with the efficiency of the problem.

F# uses a classic implementation technique that goes all the way back to the 50s that a list as a pointer to a linked list of cells. A ~cons cell~ is just a heap-allocated block of memory containing two pointters. The following pointers have one towards the list head and the list tail.

For `[1;2;3]`

That looks like -> [[_1][]->[_2][]->[_3][x]] (Where x is the null pointer)

## Implementations

With the following representation, we can look at the all the operations 

`e1 :: e2` works by passing in the two pointers of `e1` and `e2` as `p1` and `p2`. Then it will make a cons cell- put the p1 and p2 pointers in the following cell.

`List.isEmpty e` the value of e is a pointer p. Test wether p is the null pointer. If null- then there is nothing

`List.head e` The value of e is a pointer p. If p is a null pointer then it will raise a `ArgumentException` Otherwise, return the left pointer of the cons cell where p points.

`List.tail e` The value of e is a pointer p. If p is a null pointer then raise a `ArgumentException`. Otherwise, return the right pointer of the cons cell where p points.

All of these take O(1) time.

## Pattern Matching

Pattern Matching is proportional to the size of the list- but it is independant of the size of the list. For instance, matching a list L against patten x::y::z just requires looking at the first two cons cells of L (if it has at least cons cells) and making the bindings

->[[x][]]->[[y][z]]

## Determining Complexity

First, in order to check we must see how many recursive invocations of methods and then check the work of those methods.

So lets try one example.

## Analysis of Length

```fsharp
let rec length = function
| [] -> 0
| x::xs -> 1 + length xs
```

First, if L has length n, then we will have a total of n+1 since every call is on the tail

Then we check the work.

Notice, we do have to compute the costs of computing the arguments

So we get (n+1)*O(1) = O(n)

## Analysis of Append

```fsharp
let rec append = function
|([], ys) -> ys
|(x::xs, ys) -> x :: append (xs,ys)
```

How many invocations will there be?

If xs has length n and ys has length m, then notice we get n + 1 invocations

How much work

Each of these invocations again does O(1) work

In total O(1) * O(n) = O(n)

This matters when you use `@`

(next part is from gigamonkeys)

## Sharing Cells

Small values of ints 
[[1][]]-> [[2][]]-> [[3][NL]]

On append xs ys, F# makes a top level copy of the cons cell but shares all the cons cells. This sharing is important in making programming with immuatble values work.

[[1][]]-> [[2][NIL]] ->

[[1][]]-> [[2][NIL]] [[3][]]-> [[4][NIL]]

## Recomputation pitfall

```fsharp
let rec split = function
| [] -> ([],[])
| [a] -> ([a],[])
| a::b::cs -> let (M,N) = split cs (a::M, b::M)
```

The complexity of the two splits does n/2 recursive invocations total and hence takes a linear time.

The version on lists n-2/4 but it recomputes all the local variables

## Calling Linear Functions Pitfall

```fsharp
let rec last xs =
    if List.isEmpty xs
    then failwith "empty list has no last element"
    elif List.length xs = 1 then List.head xs
    else last (List.tail xs)
```

Its easy to fix the fact it is quadratic, just sub out `List.length xs = 1` with `List.isEmpty (List.tail xs)`

There is no need to recalc the whole list to get 1

## Symmetry Pitfall

Consider a definition of reverse

```fsharp
let rec rev = function
| [] -> []
| x::xs -> rev xs @ [x]
```

So on a n list, we do n amount of work. So it is all quadratic. (This is where @ is critical)

How can this be fixed???

([x] @ rev xs not quadratic)- when stuck try something harder

So what we will do is define `apprev(xs,ys)` to return `(List.rev xs)@ys`

- Implment rev xs as simply `apprev(xs,[])
- apprev can be defined easily by recursion

Logically, apprev can be analyzed as:

```fsharp
let rec apprev = function
| ([],ys) -> ys
| (x::xs,ys) -> apprev(xs, x::ys)

let rev xs = apprev(xs, [])
```

In other words what we needed to do- we just needed to do identity transformaion. Definitions with that property is considered tail recursive.

## Accumulation Technique

This idea is not so obvious.

Think of it as us introducing a accumluating parameter to the result.

Many example will see a local function. That makes it O(n!)

```fsharp
let rev zs =
    let rec loop acc = function
    | [] -> acc
    | x::xs -> loop (x::acc) xs
loop []zs
```

