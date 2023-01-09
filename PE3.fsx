#!/usr/bin/env -S dotnet fsi --exec

(*

https://projecteuler.net/problem=3
Problem 3: Largest prime factor

The prime factors of 13195 are 5, 7, 13 and 29.

What is the largest prime factor of the number 600851475143 ?

*)

open System.Diagnostics

let sw = Stopwatch.StartNew()

let rec primeFactorize largest n sqrtN_ =
    let sqrtN =
        if sqrtN_ <> 0L
        then sqrtN_
        else (int64 (ceil (sqrt (float (n / 2L)))))
    
    if n % 2L = 0L then
        primeFactorize (max largest 2L) (n / 2L) sqrtN
    else
        let maybeFactor =
            seq { 3L..2L..sqrtN }
            |> Seq.tryFind (fun v -> n % v = 0L)
        
        match maybeFactor with
        | Some factor -> primeFactorize (max largest factor) (n / factor) sqrtN
        | None -> largest

printfn $"%d{primeFactorize 0 600_851_475_143L 0L}"

sw.Stop()

printfn $"took %f{1000. * (float sw.ElapsedTicks) / (float Stopwatch.Frequency)}ms"