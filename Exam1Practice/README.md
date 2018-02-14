# If I was a senior instructor?

What would I ask?

The following is a combination of all the findings and notes I can muster to remember for the next exam, hopefully they help someone out with their journey into functional programming and the like.

## Questions on F# Basics

### On Syntax

1. What type of ending is needed in order to process code snippets.

`;;`

2. What does the `let` syntax word do?

It binds an identifier to a value, however it is not an assignement. What `let` does, is redefines the value.

`let x = 7;;`

`let x = x+1;;`

`> val it : int = 8`

3. Do what scope would this `let` have?

`let x = expression1 in expression2`

The scope would be in the second expression, you cannot access x in this case outside the second expression.

4. What would be the the value of `z` in this case?

`>let z = 5 in (let z = 3*z+1 in 2*z) + z`

(My guess is as good as yours)

Lets break this down...

z is now 5

so the inner function `(let z = 3*z+1` is evaluated as z=5 BUT once we get that vakue, it exists in the second expression- at this point z = 16, so we plug 16 into `in 2*z)` but outside that scope, z is still 5- so it is 37.

5. Is this a proper function declaration?

`> let succ n = n + 1`

You have a let, a name, a parameter and a return.

(Functions are first class functions, so no more it- it is now associating inputs and outputs) so you will see something to the effect int -> int.

6. Are types defined?

No, they are infered from the usgae in the body.

7. What is the precedence rule in F#?

F# will greedily evaluate the first valid function and param it sees unless you specify. `func 3*7` evaluates as `(func 3)*7`

8. Do you need spaces for negative literals?

Yes, func-1 will throw an error. So you need func -1.

9. How do you declare a lambda function?

`let lamb = fun n -> n+1;;`

The fun n delimits an identifyer for a function where n is taken as a paramater to the return. Lambda's are usefuls when the function will only be used once.

10. Do you need to use the `in` keyword in order to do local declarations?

No, you can do something to the effect of...

```fsharp
let squared_minus_one x =
    let squared = x*x
    squared - 1
```

```fsharp
let cos_squared r =
    let c = cos r
    c*c;;
```
Convoluted examples I know.

11. Where do the parenthesis belong in some functions?

Whenever you want to associate the operator presence.

12. Does indentation play a role in evaluation of your functions?

Spaces, no tabs and yes.

13. How do you deliniate recursive functions?

You add a `rec` in the function declaration.

### On Types

1. The `true` and `false`, `not`, `&&`, `||` are associated with what data type?

Booleans

2. What is the default parameter for parameterless functions?

() Called the unit

3. Which type supports cos, floor, sqrt?

Floats

4. Are there automatic coercions?

No, you cant do `3 * 3.3`

5. What are some legal operators on strings?

"\n", "\t", =, <, <=, ..., +, .length, and postfix

6. How do I get the third character from this String "test"?

`"test".[2]`

7. How are tuples formed?

a * b, to select the components you can call fst (first) and snd (second) to get those values

8. How many different types?

As much memory as you can use, they have to have homogeneous types however.

9. How do you pass a touple to a function?

```fsharp
let rec power pair
    if snd pair = 0
        then 1.0
        else fst pair * power (fst pair, snd pair -1)
``` 

10. What is patten matching?

When we are given a tuple list of types, we can parse and understand what types of the identifiers.

`let (j,e,s) = (14, "QT", true)`

You would get returns like, and thats because it does association by order

`val j : int 14`

11. How would you put pattern matching in functions?

First we will define the tuple that is coming in our params

`let rec power (m,n) =`
//then we have to check if n is 0, thtas our base case
`if n = 0`
`then 1.0`
`else m * poer (m, n-1)`

12. Are tuples first class?

Yes, we can anme tuples.

13. What do tyuples gotta do to be equal?

Same length, same values or else errors throw.

On functions

1. Are functions first class?

I have a feeling I answered this.

2. You should write many functions and explain them

Not a question but sure.

This one adds n and 2 together

`let add2 n = n + 2;;`

Same but now with 3

`let add3 n = n + 3;;`

This one takes in a tuple and returns a function, b ut the way it does it is p tricky.

`let act (f,v) = f v`
^ This is inferencing that you take in atuple a function and params and acting that on v. So the type intference is a function.

```fsharp
let choose n =
    if n > 10 add2
    else add3;;
```

3. What form are F# functions?

`t1 -> t2`

4. What happens to this function? ` let swap (x,y) = (y,x)`

The touple just moves the identyers are arounds.

5. How do you add generics to the type system?

By writing the typing as (test `a, `b)

6. What is a polymorphic function?

A polymorphic function is a function that can accept any type. 

7. How do you deal with overloaded operators.

`>let double x = x+x`

Sometimes you have to work around the limits of the operators, because not all types use +. So it defines the plus as limited or it picks one.

8. How do you get better than that?

Type Annotations!

`>let double (x:string) = x+x;;`

Now we can take in Strings

9. COnstrained Qualification? What is?

The default to int rule only applies to overloaded numberic operators and it doesnt apply to the functions like swap. 

Now what happens we use a compare. 

`let inorder (x,y,z) = (x <= y) && (y <= z)`

The poly moprphism give all the resulting types a bool.

### Curry Functions

1. What is the main limitation of a function passed in as a tuple?

What happens when you pass in one argument that doesnt meet the pair- and why? But of you just calla function, yopu get the function so therefore you should be able to add at will.

Take the old add function...

`let add (a, b) = a+b;;`

Now lets revamp this

`let curry_add a = (fun b -> a+b)`

Now this function can take in one argument at a tgime and still deliver.

2. What are the default associations?

Operators like -, associates to the left so 1 - 2 - 3 is actually (1 - 2) - 3

But `->` is to the right so the type for curry_add is fun b -> a + b
and the type is parenthetized by int -> (int -> int)

Now- the function applications associate to the left so

`(curry_add 5) 8` is the same as `curry_add 5 8`

3. Super simple curry?

Yes, you can do

`let curry_add a b = a + b;;`

rather than `let curry_add a = (fun b -> a+b)`

Even anon functions can be as well- fun a b -> a+b

4. Infix ops can be converted to function what?

Yes, you can put * to something like (*);;

### Okay we lists now

1. Can lists be of different types?

No, all elements of the lists but be the same type at all times.

2. How many list types are there?

There are infinitely many list types out there.

`[1;2;3]` this is a int list
`[[];[];[]]` this is a list of lists
`[[5;6];[3;4];[1;2]]` this is a list of int lists

3. I hate typing, can I save time?

Yep- you make list ranges with `let cool_list = [ 1 .. 10 ]`

4. Can you use expressins to create a list?

Yes, it really powerful. Look at this-
`let listOfSquares = [ for i in 1 .. 10 -> i*i ]`

5. How about operators?

`@` is a list concatenator

you can do 

```fsharp
> let l1 = [1;2];;
> let l2 = [3;4];;
> let l3 = l1 @ l2;;
```

The result would be `[1;2;3;4]`

`::` this is called a cons

In the above example you can do

`let l4 = 999 :: l1`

6. What are the properties of a list?

You have .Head (first element), .rev (reverse), .length, 

7. What is head, tail, map, filter, and reduce?

```fsharp
List.head [1;2;3] = 1
// Returns the first element
List.tail [1;2;3] = [2;3]
// Returns all but the first element
List.map [fun n -> n*n] [1;2;3] = [1;4;9]
// Map runs a function with a input of the enture list
List.filter (fun x -> x&2 = 0) [1;2;3] = [2]
// Filter applies a condition, the elements that statisfy it will be returned
List.reduce (*) [1;2;3] = 6
// Reduce runs a operatoir on all elements to return a single value
```

8. Are list operations polymorphic?

Yes they are assuming all the lists are homogeneous.

9. Can we have fun with some examples?

I thought you'd never ask...

```fsharp
> List.map (String.length) ["a";"haha"];;
[1;4]
// This runs String.length on all elements
/// Now what about appending for all elements???
> List.map (fun xs -> 5::xs) [[1;2];[3]];;
[[5;1;2];[5;3]]
// Lets break this down, we pass in a list called xs and then cons 5 to each list
> List.map (fun n -> (5,n)) [true; false];;
// This one is a interesting one, so we pass in a input and then return a tuple containing 5 for each boolean, fun fact you cant return another list because of types
[(5, true);(5, false)]
// Given a list of a tuples containing a list you can append the first parameter to the list
> List.map (fun (x,xs) -> x::xs) [(3,[4;5]);(2,[1])];;
// It will return a list of lists without touples
[[3; 4; 5]; [2; 1]]
// Map can take in curried functions
> List.map ((*) 7) [1 .. 5];;
[7; 14; 21; 28; 35]
```

### Fun with functions and patterns

1. How do you space out different cases in F#?

Using something called a guard, so what you are putting into place is a pattern match for integers.

```fsharp
> let rec downFrom = function
    | 0 -> []
    | n -> n :: downFrom (n-1);;
```
F# tries the patterns in order so downFrom is matches by the first one and then processes, even though in theory the second would have matched

2. How would you compose functions?

`(f >> g) = g (f x)`

This says, do f first, then take the value and then bring the value of g. If the first function matches the second function's input type then they can be composed.

3. Lets make a function!

That is not a question

```fsharp
> let fact n = prod (downFrom n);;
// This is the same as writing it like
> let fact = downfrom >> prod;;
// Lets see what type the following produces
> let mystery = prod >> downFrom;;
```

4. What is the forward pipeline operator?

The forward pipeline operator takes in the a generic type and takes the staret at the beginning, so the use of the imput first instead of last.

`let fact n = n |> downFrom |> prod`

This is really good for us whenever we want to have a bunch of code reuse or making streams.

### Syntax Rules to Remember

`List.map (fun n -> n*n) [1;2;3]@[4;5;6]`
 parses as 
`(List.map (fun n -> n*n)) [1;2;3]@[4;5;6]`

Infix operators have the following procedures ordered from highest to the lowest. **, * / %, + -, :: @, = <>...

int -> bool * string list

but this does

list first

then touple

then the functions

int -> (bool * (String list))

- The fun thing about defining functions

Lets say we wanted to define a curried, rec, functin foo with two parameters

You can do

```fsharp
> let rec foo xs ys = ...;;
> let rec foo xs = fun ys -> ...;;
> let rec foo = fun xs -> fun ys ...;;
> let rec foo = fun xs ys -> ...;;
```

- The fun thing about matching parameters

Suppose we wanted to do pattern matching on the just the second parameter

```fsharp
let rec foo xs = function
| [] -> ...
| y::ys -> ...
```

Using this idiom we can redifine map
```fsharp
> let rec map f = function
| [] -> []
| x::xs -> f x :: map f xs
```

But if we want to do pattern matching on the first parameter, the first thing I would be doing is

```fsharp
let rec foo = function 
| [] -> fun ys -> ...
| x::xs -> fun ys -> ...
```

But it's easier if we can see the matching happen in front of our eyes instead

You can read 

```fsharp
let rec foo xs fs = 
    match xs with
    | [] -> ...
    | x::xs -> ...
```

But now, for the big stromboli, what if we were to match it for both parameters
```fsharp
let rec foo xs ys =
    match (xs, ys) with
    | ([], ys) -> ...
    | (xs, []) -> ...
| (x::xs, y::ys) -> ...
```

