//
// Lam Reference Compiler
// Copyright (C) 2015  Wael El Oraiby
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Affero General Public License for more details.
// 
// You should have received a copy of the GNU Affero General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.
//
module Program

open System
open Microsoft.FSharp.Text.Lexing

let (|>!) (a: 'A) (b: 'A -> 'B) = b a |> ignore; a

[<EntryPoint>]
let main argv = 
    if argv.Length = 1 then
        if IO.File.Exists argv.[0] then
            let content = IO.File.ReadAllText argv.[0]
            let lexbuf = LexBuffer<char>.FromString content
            try
                Parser.start (Lexer.read argv.[0] content) lexbuf
                |> printfn "%A"

                0 // return an integer exit code
            with e ->
                printfn "%s" e.Message
                printfn "   @line %d : %d" (lexbuf.StartPos.Line + 1) (lexbuf.StartPos.Column + 1)
                3
        else
            printfn "Error: file %s doesn't exist" argv.[0]
            2
    else
        printfn "Error -> usage: lam filename"
        1