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
module TypedAst

open System
open UntypedAst

type Result<'R> =
    | Success of 'R
    | Failure of string list // error list
with
    member x.AddSuccess (su : 'R -> 'R) =
        match x with
        | Success s -> Success (su s)
        | Failure _ -> x

    member x.AddFailure f =
        match x with
        | Success s  -> Failure [ f ]
        | Failure fl -> Failure (f :: fl)

type State = {
    Name    : string
    Clauses : Clause list
}

and Rule = {
    Name    : string
    Clauses : Clause list
}

and LogEl = // logical element
    | State of State
    | Rule  of Rule

and LogNode =
    | Normal    of LogEl
    | Negate    of LogEl

and Clause = LogNode list

let getDisjunctionsIdentifiers (disj: UntypedAst.Disjunctions) : Result<string list> =
    let getConjunctionsIdentifiers (conj: UntypedAst.Conjunctions) : Result<string list> =
        conj
        |> List.fold
            (fun (state: Result<string list>) re ->
                match re with
                | RuleElem.Identifier    ident -> state.AddSuccess (fun s -> fst ident :: s)
                | RuleElem.BooleanExp    b     -> state.AddFailure (sprintf "boolean expressions not supported yet")
                | RuleElem.Negate        re    ->
                    match re with
                    | RuleElem.Identifier ident -> state.AddSuccess (fun s -> fst ident :: s)
                    | _                         -> state.AddFailure (sprintf "negation is only supported on identifier")) (Result.Success [])
    
    let mergeResult (a: Result<string list>, b: Result<string list>) =
        match a, b with
        | Success sa, Success sb -> Success (sa |> List.append sb)
        | Failure fa, Failure fb -> Failure (fa |> List.append fb)
        | Success _, Failure _ -> b
        | Failure _, Success _ -> a

    disj
    |> List.fold (fun s d -> mergeResult(s, getConjunctionsIdentifiers d)) (Result.Success [])

(*
type State
with
    static member from (identifier: UntypedAst.Identifier, disjunctions: UntypedAst.Disjunctions) : State =
        let identifiers = getDisjunnctionsIdentifiers disjunctions

        { Name      = fst identifier
          Clauses   = clauses }
*)

type Entity = {
    Name    : string
    Inputs  : Set<string>
    States  : Map<string, State>
    Rules   : Map<string, Rule>
} with
    static member from (e: UntypedAst.Entity) : Entity =
        let inputs  =
            e.Args
            |> List.map fst
            |> Set.ofList

        let stateNames, ruleNames  =
            e.Statements
            |> List.fold
                (fun (s, r) stmt ->
                    match stmt with
                    | Statement.State (name, _) -> ((fst name) :: s, r) 
                    | Statement.Rule  (name, _) -> (s, (fst name) :: r)) ([], [])

        // check for duplicate state names and rules (and cross duplication)
        let stateSet = stateNames |> Set.ofList
        let ruleSet  = ruleNames  |> Set.ofList

        if stateSet.Count <> stateNames.Length
        then    // some states are duplicated. Find them!
            let dups =
                stateNames
                |> List.fold
                    (fun (state: Map<string, int>) (n: string) ->
                        match state.TryFind n with
                        | Some s -> state.Add(n, s + 1)
                        | None   -> state.Add(n, 1)) Map.empty
            dups
            |> Map.filter(fun k v -> v > 1)
            |> Map.iter(fun k v -> printfn "state %s is duplicated" k)

        { Name   = fst e.Name
          Inputs = inputs
          States = states
          Rules  = rules }

type Module = {
    Name    : string
    Entities: Entity list
} with
    static member from (m: UntypedAst.Module) : Module =
        let entities =
            m.Entities
            |> List.map Entity.from
        { Name     = fst m.Name
          Entities = entities }
