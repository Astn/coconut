[<EntryPoint>]
let main argv = 
    let saliors = 5

    let sneak (coconuts, pile, _) = 
        let piles = pile / saliors
        let leftovers = pile % saliors
        (coconuts, piles * (saliors - 1), leftovers)

    let happyMonkey (coconuts, pile, leftovers) = leftovers = 1

    let saliorSneakAndMonkey coconuts = 
        coconuts
        |> Seq.map sneak
        |> Seq.filter happyMonkey

    let viablePileSizes = 
        {saliors .. System.Int32.MaxValue}
        |> Seq.map (fun coconut -> (coconut, coconut, 0))
        |> saliorSneakAndMonkey
        |> saliorSneakAndMonkey
        |> saliorSneakAndMonkey
        |> saliorSneakAndMonkey
        |> saliorSneakAndMonkey
        |> Seq.filter (fun (coconuts, pile, leftovers) -> pile % 5 = 0)
        |> Seq.map (fun (coconuts, _, _) -> coconuts)
        |> Seq.take 5

    printfn "Piles could be : %A" viablePileSizes
    0 // return an integer exit code

