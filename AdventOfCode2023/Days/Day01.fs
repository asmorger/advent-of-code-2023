module AdventOfCode2023.Days.Day01

open System
open System.IO

let getFirstAndLastDigits (input: string) =
  let numbers =
    input
    |> Seq.filter Char.IsNumber
    |> Seq.toList
    
  let first = numbers.Head
  let last = numbers |> List.rev |> List.head
  
  Int32.Parse $"{first}{last}"
  
let test input expected =
  let result = getFirstAndLastDigits input
  
  printfn $"{input}: {result} = {expected}"

let validate =
  test "1abd2" 12
  test "pqr3stu8vwx" 38
  test "a1b2c3d4e5f" 15
  test "treb7uchet" 77
  
let runDaily =

  let content = File.ReadAllLines "./Days/Day01.txt"

  let finalResult =
    content
    |> Array.map getFirstAndLastDigits
    |> Array.sum
    
  finalResult
