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

type State
with
    static member from (identifier, disjunctions) : State =
        { Name      = fst identifier
          Clauses   = }

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

        let 
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
