#!/usr/bin/env -S dotnet fsi --exec

(*

https://projecteuler.net/problem=1
Problem 1: Multiples of 3 or 5

If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.

Find the sum of all the multiples of 3 or 5 below 1000.

*)

open System.Diagnostics

let sw = Stopwatch.StartNew()

seq {0..3..999}
|> Seq.filter (fun v -> v % 5 <> 0)
|> Seq.append {0..5..999}
|> Seq.sum
|> printfn "%d"

sw.Stop()

printfn $"took %f{1000. * (float sw.ElapsedTicks) / (float Stopwatch.Frequency)}ms"