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
module UntypedAst

open System

exception SyntaxError of string

type TokenInfo = {
    FileName    : string
    Line        : int
    Column      : int
    Offset      : int
}
with
    static member New(file: string, lineNumber: int, column: int, offset: int) = {
        FileName    = file
        Line        = lineNumber
        Column      = column
        Offset      = offset
    }

    static member Empty = {
        FileName    = ""
        Line        = 0
        Column      = 0
        Offset      = 0
    }

type Identifier = string * TokenInfo

and Field      = {
    Name        : Identifier
    Type        : Identifier
}

type Operator =
    | OpAdd
    | OpSub
    | OpMul
    | OpDiv
    | OpMod

type BoolOp =
    | OpEq
    | OpNEq
    | OpLT
    | OpGT
    | OpLEq
    | OpGEq

type Constant =
    | ConstBool      of bool * TokenInfo
    | ConstChar      of char * TokenInfo
    | ConstSInt64    of Int64 * TokenInfo
    | ConstReal64    of double * TokenInfo
    | ConstString    of string * TokenInfo

type Term   =
    | Identifier of Identifier
    | Inverse    of Identifier
    | Const      of Constant

type Equation =
    | Term  of Term
    | Operation of Equation * Operator * Equation
    | Function of Identifier * Equation list
    | Negate of Equation
 
type BooleanExp = Equation * BoolOp * Equation

type RuleElem =
    | Identifier    of Identifier
    | BooleanExp    of BooleanExp
    | Negate        of RuleElem

type Conjunctions = RuleElem list
type Disjunctions = Conjunctions list

type Statement =
    | Rule of Identifier * Disjunctions
    | State of Identifier * Disjunctions

type Entity = {
    Name        : Identifier
    Args        : Identifier list // currently identifier list instead of Field list
    Statements  : Statement list
}

type Declaration =
    | Entity    of Entity
    | Module    of Identifier * (Declaration list)






