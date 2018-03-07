open System

type Tree<'a> = 
  | Empty
  | Node of value: 'a * left: Tree<'a> * right: Tree<'a>

let isBST (tree : Tree<'a>) =
  let rec verify lo hi tree =
    match tree with
    | Empty -> true
    | Node (value, left, right) ->
      match lo, hi with
      | Some lo, _ when value < lo -> false
      | _, Some hi when value > hi -> false
      | _ ->
        let hi' = defaultArg hi value |> min value |> Some
        let lo' = defaultArg lo value |> max value |> Some
        verify lo hi' left && verify lo' hi right

  verify None None tree

let rec insert newValue (tree : Tree<'a>) =
  match tree with
  | Empty -> Node (newValue, Empty, Empty)
  | Node (value, left, right) when newValue < value ->
    let left' = insert newValue left
    Node (value, left', right)
  | Node (value, left, right) when newValue > value ->
    let right' = insert newValue right
    Node (value, left, right')
  | _ -> tree