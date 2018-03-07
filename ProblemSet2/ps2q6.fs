let rec foldBack f xs a =
      match xs with
      | []    -> a
      | y::ys -> f y (foldBack f ys a);;

let rec fold f a = function
    | []    -> a
    | x::xs -> fold f (f a x) xs;;