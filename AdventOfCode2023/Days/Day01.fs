module AdventOfCode2023.Days.Day01

open System
open System.IO

module Shared =
  
  let combineFirstAndLast<'a> (source: 'a list)  =
    let first = source.Head
    let last = source |> List.rev |> List.head
    
    Int32.Parse $"{first}{last}"
   
 
  let parseStringForNumbers input =
    input
    |> Seq.filter Char.IsNumber
    |> Seq.toList
    
module Part01 =
  
  let getNumber input =
    Shared.parseStringForNumbers input |> Shared.combineFirstAndLast
  
  let test input expected =
    
    let result = getNumber input
    
    printfn $"{input}: {result} = {expected}"

  let validate ()=
    test "1abd2" 12
    test "pqr3stu8vwx" 38
    test "a1b2c3d4e5f" 15
    test "treb7uchet" 77
   
 
  let runPart01 =

    let content = File.ReadAllLines "./Days/Day01.txt"

    let finalResult =
      content
      |> Array.map getNumber
      |> Array.sum
      
    finalResult
module Part02 =
  
  let mappings =
    dict[
      "1", 1
      "2", 2
      "3", 3
      "4", 4
      "5", 5
      "6", 6
      "7", 7
      "8", 8
      "9", 9
      "one", 1
      "two", 2
      "three", 3
      "four", 4
      "five", 5
      "six", 6
      "seven", 7
      "eight", 8
      "nine", 9
    ]
    
  let isANumber (input: string) =
    match (mappings.ContainsKey input) with
    | true -> Some mappings[input]
    | false -> None
    
 
  let generateCombinations (input: string) =
    seq {
      let mutable currentIndex = 0
      for index in [0 .. input.Length] do
        for idx in [index .. input.Length] do
          yield input.Substring (index, (input.Length - idx))
        yield input
      
        currentIndex <- currentIndex + 1
    }
  
  let getNumber input =
    let allPossibleCombinations = generateCombinations input
    
    allPossibleCombinations
    |> Seq.map isANumber 
    |> Seq.choose id
    
  let validate () =
    
    let test1 = getNumber "two1nine"
    let test2 = getNumber "eightwothree"
    
    let inputs =
      [|
        "two1nine"
        "eightwothree"
        "abcone2threexyz"
        "xtwone3four"
        "4nineeightseven2"
        "zoneight234"
        "7pqrstsixteen"
      |]
      
    let finalResult = inputs |> Array.map getNumber

    
    printfn $"{finalResult}"
    finalResult
    
  let runPart02 =

    let content = File.ReadAllLines "./Days/Day01.txt"

    let finalResult =
      content
      |> Array.map getNumber
    
    printfn $"{finalResult}"
    finalResult
