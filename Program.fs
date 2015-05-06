[<EntryPoint>]
let main argv = 
    let sailors = 5

    let sneak (coconuts, pile, _) = 
        let piles = pile / sailors
        let leftovers = pile % sailors
        (coconuts, piles * (sailors - 1), leftovers)

    let happyMonkey (coconuts, pile, leftovers) = leftovers = 1

    let sailorsneakAndMonkey coconuts = 
        coconuts
        |> Seq.map sneak
        |> Seq.filter happyMonkey

    let viablePileSizes = 
        {sailors .. System.Int32.MaxValue}
        |> Seq.map (fun coconut -> (coconut, coconut, 0))
        |> sailorsneakAndMonkey
        |> sailorsneakAndMonkey
        |> sailorsneakAndMonkey
        |> sailorsneakAndMonkey
        |> sailorsneakAndMonkey
        |> Seq.filter (fun (coconuts, pile, leftovers) -> pile % 5 = 0)
        |> Seq.map (fun (coconuts, _, _) -> coconuts)
        |> Seq.take 10

    printfn "Piles could be : %A" viablePileSizes
    0 // return an integer exit code

