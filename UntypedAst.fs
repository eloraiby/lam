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
type Path       = Identifier list

type Type       =
    | Path      of Path
    | Function  of FuncType
    | Array     of Type

and FuncType    = (Field list) * Type

and Field      = {
    Identifier  : Identifier
    Type        : Type
}

type IdentOrOp =
    | Identifier of Identifier
    | OpAdd
    | OpSub
    | OpMul
    | OpDiv
    | OpMod
    | OpAnd
    | OpOr
    | OpXor
    | OpNot
    | OpLAnd
    | OpLOr
    | OpLNot

type ConstBool      = bool * TokenInfo
type ConstChar      = char * TokenInfo
type ConstSInt64    = Int64 * TokenInfo
type ConstReal64    = double * TokenInfo
type ConstString    = string * TokenInfo

type Declaration =
    | Alias     of Path * Path
    | Open      of Path
    | Struct    of Identifier * (Field list)
    | Record    of Identifier * (Field list)
    | Union     of Identifier * (Field list)
    | Function  of Identifier * FuncType * (Expr list)
    | ConstBool     of Identifier * ConstBool
    | ConstChar     of Identifier * ConstChar
    | ConstString   of Identifier * ConstString
    | ConstSInt64   of Identifier * ConstSInt64
    | ConstReal64   of Identifier * ConstReal64
    | Module    of Identifier * (Declaration list)

and Expr =
    | If        of Expr * (Expr list) * (Expr list) * TokenInfo
    | Let       of (Identifier list) * (Expr list) * (Expr list) * TokenInfo
    | Apply     of Expr * (Expr list) // struct/unions/.../function calls and variables
    | Item      of Expr * Expr  // expr * index
    | Access    of Expr * Identifier    // access identifier of expr
    | Identifier of Identifier
    | Tuple     of Expr list
    | Bool      of ConstBool
    | Char      of ConstChar
    | SInt64    of ConstSInt64
    | Real64    of ConstReal64
    | String    of ConstString
    | UnitValue of TokenInfo
    | AnonFunc  of FuncType * (Expr list)



