# PROBLEM SET 1

aka F# is fun, aka we learn something new

## So About That Language Design

Since we are doing functional programming, we are going to have to understand some basic syntax that allows us to do our jobs as students and hopefully developers.

Lets see what recursion in F# looks like 

```fsharp
// Classic recursion for calculating Fibonacci numbers:
let rec fib1 = function
| 0 -> 0I
| 1 -> 1I
| n -> fib1(n-1) + fib1(n-2)
```

First, we define our variables using `let`. Our variables in this case are considered immutable and aren't modified. 

### Oh man, you forgot to tell us about let

Okay fine.

But Fsharp doesn't really like to instantiate variables willy nilly, so we call the name space that we reserve in memory an identifier.

We can define the syntax as follows

`let identifier-or-pattern [: type] =expressionbody-expression`

In the classical sense, `let` can just bind values

```fsharp
let i = 1
```

Now, if we are going to do some fun sick nasty multiline expressions we are going to have to indent the following lines.

```fsharp
let sickNasty =
    1 + 1
```

You can even do patterns, like tuples (pronounced tuples) as your identifier

```fsharp
let s, i, c, k = (1, 2, 3, 4)
```

You can even do in body expressions

```fsharp
let nasty =
    let s, i, c, k = (1, 2, 3, 4)
    //Sexy Body
    s + i + c + 4*k
```

Final notes- A let binding can appear at the module level, in the definition of a class type, or in local scopes, such as in a function definition. A let binding at the top level in a module or in a class type does not need to have a body expression, but at other scope levels, the body expression is required. In short- look at this cool snippet.

```fsharp
// Nope:
printfn "%d" immatureValue
let immatureValue = 420
// OK:
printfn "%d" immatureValue
```

### Fun (but no Fun Keyword) in Functions

```fsharp
let sickFunction f =
    f + 1
```

Okay Mr. OO, you must be wondering, why do I just use a `let` and then add a value which I do something to. Well, its `let year = 2018` and function bindings include the name and its parameters in F#. So we have a name and what we are passing it.

Parameters are what we consider patterns (Patterns are just reuseable solutions, in this case we see a trend with commented parameters, we can treat those like like patterns) Typical OO patterns are just treated as functions. You'll see why.

```fsharp
//Totally Valid
let wa (c, k) = c + k
```

Remember that sick inner body let we did, well look at it now.

```fsharp
let nasty =
    let sickFunction (s, i, c, k) = s + i + c + k
    //Look ma, no declaration
    100 * sickFunction (1, 2, 3, 4)
```

### What about my Types Vro?

You have them.

`let function1 (a: int) : int = a + 1`

Where a colon (:) deliniates what is up. Valid types are... 
`int`

`string`

and whatever types are sold at the Fsharp type shop.  

Now, lets do something slightly complex.

```fsharp
//We are going to do is 
type MyClass(a) =
    let field1 = a
    let field2 = "text"
    do printfn "%d %s" field1 field2
    member this.F input =
        printfn "Field1 %d Field2 %s Input %A" field1 field2 input

```

## The Strongly Typed Parable & Other problem set questions

### Q1

```
Which of the following F# expressions is not well typed? Select one:

    a.2 + 5 * 10
    b.10I * 20I
    c.4 + 5.6
    d."4" + "5.6"

```
That would be c.), you cant add a Int and a Float

### Q2

```
A curried function has a type of which form? Select one:

    t1 * t2 -> t3
    t1 -> t2 * t3
    t1 -> (t2 -> t3)
    (t1 -> t2) -> t3
```

That would be c)

### Q3

```
If an F# function has type 'a -> 'b when 'a : comparison, which of the following is not a legal type for it? Select one:

    (float -> float) -> bool
    string -> (int -> int)
    int -> int
    int list -> bool list
```

That will be d) You cant compare lists

### Q4 

- Lists in F# arent heterogeneous

### Q5

```
Which of the following F# expressions evaluates to [1; 2; 3]? Select one:

    1::2::3::[]
    1@2@3@[]
    [1; 2; 3]::[]
    ((1::2)::3)::[]
```
a)

### Q6

```
How does F# interpret the expression List.map List.head foo @ baz? Select one:

    (List.map List.head) (foo @ baz)
    ((List.map List.head) foo) @ baz
    List.map (List.head (foo @ baz))
    (List.map (List.head foo)) @ baz

```
d)

### Q7

```
How does F# interpret the type int * bool -> string list? Select one:

    (int * (bool -> string)) list
    ((int * bool) -> string) list
    int * (bool -> (string list))
    (int * bool) -> (string list)


```

It takes in  a tuple and then returns a string list so d)

### Q8

```
Let F# function foo be defined as follows:

let rec foo = function
	    | (xs, [])    -> xs
	    | (xs, y::ys) -> foo (xs@[y], ys)

If foo is supposed to append its two list parameters, which of the following is true? Select one:

    foo fails Step 1 of the Checklist for Programming with Recursion.
    foo fails Step 2 of the Checklist for Programming with Recursion.
    foo fails Step 3 of the Checklist for Programming with Recursion.
    foo satisfies all three steps of the Checklist for Programming with Recursion.

```
Foo fails step 1, because it fails when two empty lists are appended


### Q9

```
Which of the following is the type that F# infers for (fun f -> f 17)? Select one:

    ('a -> 'b) -> 'b
    (int -> int) -> int
    (int -> 'a) -> 'a
    ('a -> 'a) -> 'a

```

c)

### Q10

```
Which of the following has type int -> int list? Select one:

    (@) [5]
    [fun x -> x+1]
    fun x -> 5::x
    fun x -> x::[5]

```
d)

### Q11
```
What type does F# infer for the expression (3, [], true) ? Select one:

    int * 'a list * bool
    int * 'a * bool
    int * int list * bool
    Type error.
```
a)


### Q12
```
What type does F# infer for the expression fun x y -> x+y+"." ? Select one:

    string -> string -> string
    string * string -> string
    Type error.
    int -> int -> string
```
a)
### Q13
```
What type does F# infer for the expression fun xs -> List.map (+) xs ? Select one:

    int list -> int -> int list
    int list -> int list
    Type error.
    int list -> (int -> int) list
```
d)
### Q14
```
Which of the following does F# infer to have type string -> string -> string ? Select one:

    fun x -> fun y -> x y "."
    fun x y -> String.length x * String.length y
    fun (x, y) -> x + y + "."
    (+)
```
c)
### Q15
```
Which of the following does F# infer to have type (string -> string) -> string ? Select one:

    fun f -> String.length (f "cat")
    fun x y -> x + " " + y
    fun f -> f (f "cat")
    fun f -> f "cat"
```
c)
### Q16
```
A fraction like 2/3 can be represented in F# as a pair of type int * int. Define infix operators .+ and .* to do addition and multiplication of fractions:

  > (1,2) .+ (1,3);;
	    val it : int * int = (5, 6)
	    > (1,2) .+ (2,3) .* (3,7);;
	    val it : int * int = (11, 14)

Note that the F# syntax for defining such an infix operator looks like this:

  let (.+) (a,b) (c,d) = ...

Also note that .+ and .* get the same precedences as + and *, respectively, which is why the second example above gives the result it does.

Finally, note that your functions should always return fractions in lowest terms. To implement this, you will need an auxiliary function to calculate the gcd (greatest common divisor) of the numerator and the denominator; this can be done very efficiently using Euclid's algorithm, which can be implemented in F# as follows:

  let rec gcd = function
	    | (a,0) -> a
	    | (a,b) -> gcd (b, a % b)
```

Answer

```fsharp
//Greatest Common Denominator
let rec gcd (x, y) = 
    if y = 0 then x
    else gcd (y, (x % y));;

//Least Common Multiple
let lcm x y = (x * y) / (gcd (x, y));;

//Add Fractions
let (.+) (a,b) (c,d) =
    let x = gcd(((((lcm b d)  / b) * a) + (((lcm b d)  / d) * c))  ,lcm b d)
    (((((lcm b d)  / b) * a) + (((lcm b d)  / d) * c)) / x  ,(lcm b d) / x);;

//Multiply Fractions
let (.*) (a,b) (c,d) = 
    let x = gcd ((a * b), (c * d))
    ((a * b)/x, (c * d)/x);;
    
```
### Q17

```
Write an F# function revlists xs that takes a list of lists xs and reverses all the sub-lists:

  > revlists [[0;1;1];[3;2];[];[5]];;
	    val it : int list list = [[1; 1; 0]; [2; 3]; []; [5]]

Hint: This takes just one line of code, using List.map and List.rev.
```

```
let revlists xs = 
    List.map (List.rev) xs;;
```
### Q18
```
Write an F# function interleave(xs,ys) that interleaves two lists:

  > interleave ([1;2;3],[4;5;6]);;
	    val it : int list = [1; 4; 2; 5; 3; 6]

Assume that the two lists have the same length.
```

```
//Interleave Two Lists
let rec interleave (xs, ys) = 
    if List.length xs <> List.length ys then printf("There is an error ")
    match xs, ys with
    |(xs, []) -> xs
    |([], ys) -> ys
    |(x::xs, y::ys) -> x :: y :: interleave (xs, ys) ;;
```
### Q19
```
Write an F# function cut xs that cuts a list into two equal parts:

  > cut [1;2;3;4;5;6];;
	    val it : int list * int list = ([1; 2; 3], [4; 5; 6])

Assume that the list has even length.

To implement cut, first define an auxiliary function gencut(n, xs) that cuts xs into two pieces, where n gives the size of the first piece:

  > gencut(2, [1;3;4;2;7;0;9]);;
	    val it : int list * int list = ([1; 3], [4; 2; 7; 0; 9])

Paradoxically, although gencut is more general than cut, it is easier to write! (This is an example of Polya's Inventor's Paradox: "The more ambitious plan may have more chances of success.")

Another Hint: To write gencut efficiently, it is quite convenient to use F#'s local let expression (as in the cos_squared example in the Notes).
```

```
//Split a List in Two Equal Parts
let cut xs = 
 let n = (List.length xs) / 2 
 let rec gencut(n, xs) = function
 |(n,[]) -> ([],[])
 |(1,x::xs) -> (x::[],xs)
 |(n,x::xs) -> gencut(n-1,xs);;
```

### Q20

```
Write an F# function shuffle xs that takes an even-length list, cuts it into two equal-sized pieces, and then interleaves the pieces:


  > shuffle [1;2;3;4;5;6;7;8];;
	    val it : int list = [1; 5; 2; 6; 3; 7; 4; 8]

(On a deck of cards, this is called a perfect out-shuffle.)
```

```
let shuffle xs = interleave ( cut xs) 

let rec myrecursivewhile(deck, shuffleDeck, numberOfShuffles)=
    match deck, shuffleDeck, numberOfShuffles with
    | (d1,d2,a) -> if d1 = d2 then a else myrecursivewhile(d1,shuffle d2,a+1) 
```

### Q21

```
Write an F# function countshuffles n that counts how many calls to shuffle on a deck of n distinct "cards" it takes to put the deck back into its original order:

  > countshuffles 4;;
	    val it : int = 2

(To see that this result is correct, note that shuffle [1;2;3;4] = [1;3;2;4], and shuffle [1;3;2;4] = [1;2;3;4].) What is countshuffles 52?

Hint: Define an auxiliary function countaux(deck, target) that takes two lists and returns the number of shuffles it takes to make deck equal to target.
```

```
let countshuffles n =                           
    let initDeck = [1..n]                          
    let intermDeck = shuffle initDeck      
    let count =  1                       
    myrecursivewhile(initDeck,intermDeck,count) 
        


```
### Q22

```
Write an uncurried F# function cartesian (xs, ys) that takes as input two lists xs and ys and returns a list of pairs that represents the Cartesian product of xs and ys. (The pairs in the Cartesian product may appear in any order.) For example,

  > cartesian (["a"; "b"; "c"], [1; 2]);;
	    val it : (string * int) list =
	    [("a", 1); ("b", 1); ("c", 1); ("a", 2); ("b", 2); ("c", 2)]
```

```
let rec cartesian xs ys = 
  match xs, ys with
  | _, [] -> []
  | [], _ -> []
  | x::xs', _ -> (List.map (fun y -> x, y) ys) @ (cartesian xs' ys)
```
```
The following problems are intended to deepen your mastery of the Checklist for Programming with Recursion:

    Section 01: Checklist for Programming with Recursion
    Section 02: Checklist for Programming with Recursion
    Section 04: Checklist for Programming with Recursion 

Please follow the steps of the Checklist carefully as you solve them!
```

### Q23
```
An F# list can be thought of as representing a set, where the order of the elements in the list is irrelevant. Write an F# function powerset such that powerset set returns the set of all subsets of set. For example,

  > powerset [1;2;3];;
	    val it : int list list
	    = [[]; [3]; [2]; [2; 3]; [1]; [1; 3]; [1; 2]; [1; 2; 3]]
	  

Note that you can order the elements of the powerset however you wish.
```

```
let rec powerset = 
   function
   | [] -> [[]]
   | (x::xs) -> 
      let xss = powerset xs 
      List.map (fun xs' -> x::xs') xss @ xss
```

### Q24
```
The transpose of a matrix M is the matrix obtained by reflecting Mabout its diagonal. For example, the transpose of

 / 1 2 3 \
 \ 4 5 6 /
	  

is

 / 1 4 \
 | 2 5 |
 \ 3 6 /
	  

An m-by-n matrix can be represented in F# as a list of m rows, each of which is a list of length n. For example, the first matrix above is represented as the list

  [[1;2;3];[4;5;6]]
	  

Write an efficient F# function to compute the transpose of an m-by-nmatrix:

  > transpose [[1;2;3];[4;5;6]];;
	    val it : int list list = [[1; 4]; [2; 5]; [3; 6]]
	  

Assume that all the rows in the matrix have the same length.
```

```
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
```

### Q25
```
In this problem and the next, I ask you to analyze code, as discussed in the last section of the Checklist. Suppose we wish to define an F# function to sort a list of integers into non-decreasing order. For example, we would want the following behavior:

  > sort [3;1;4;1;5;9;2;6;5];;
	    val it : int list = [1; 1; 2; 3; 4; 5; 5; 6; 9]
	  

We might try the following definition:

  let rec sort = function
	    | []         -> []
	    | [x]        -> [x]
	    | x1::x2::xs -> if x1 <= x2 then x1 :: sort (x2::xs)
            else x2 :: sort (x1::xs)
	  

Analyze the correctness of this definition with respect to the Checklist for Programming with Recursion, being sure to address all three Steps.
```
### Q26
```
Here is an attempt to write mergesortin F#:

  
    let rec merge = function
    | ([], ys)       -> ys
    | (xs, [])       -> xs
    | (x::xs, y::ys) -> if x < y then x :: merge (xs, y::ys)
		        else y :: merge (x::xs, ys)

    let rec split = function
    | []       -> ([], [])
    | [a]      -> ([a], [])
    | a::b::cs -> let (M,N) = split cs
		  (a::M, b::N)

    let rec mergesort = function
    | []  -> []
    | L   -> let (M, N) = split L
             merge (mergesort M, mergesort N)
	  

    Analyze mergesort with respect to the Checklist for Programming with Recursion, again addressing all three Steps. (Assume that merge and split both work correctly, as indeed they do.)
    Enter this program into F# and see what type F# infers for mergesort. Why is this type a clue that something is wrong with mergesort?
    Based on your analysis, correct the bug in mergesort.
```


The following questions deal with Context Free Grammars.

### Q27
```
Recall the unambiguous grammar for arithmetic expressions discussed in class:

  E -> E+T | E-T | T
	    T -> T*F | T/F | F
	    F -> i | (E)

Modify this grammar to allow an exponentiation operator, ^, so that we can write expressions like i+i^i*i. Of course, your modified grammar should be unambiguous. Give exponentiation higher precedence than the other binary operators and (unlike the other binary operators) make it associate to the right.
```

### Q28
```
Consider the grammar for the a language that has if-else, if-then-else, begin-end block, and print statements:

  S -> if E then S | if E then S else S | begin S L | print E
	    L -> end | ; S L
	    E -> i
```

