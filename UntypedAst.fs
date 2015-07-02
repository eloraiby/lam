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

and FuncType    = Type * (Field list)

and Field      = {
    Identifier  : Identifier
    Type        : Type
}

type ConstBool      = bool * TokenInfo
type ConstChar      = char * TokenInfo
type ConstSInt64    = Int64 * TokenInfo
type ConstReal64    = double * TokenInfo
type ConstString    = string * TokenInfo

type Value  =
    | ConstBool     of ConstBool
    | ConstChar     of ConstChar
    | ConstSInt64   of ConstSInt64
    | ConstReal64   of ConstReal64
    | ConstString   of ConstString
    | Identifier    of Identifier

type Declaration =
    | Alias     of Path * Path
    | Open      of Path
    | Struct    of Identifier * (Field list)
    | Record    of Identifier * (Field list)
    | Union     of Identifier * (Field list)
    | Function  of Identifier * FuncType * ((Expr list) option)
    | ConstBool     of Identifier * ConstBool
    | ConstChar     of Identifier * ConstChar
    | ConstString   of Identifier * ConstString
    | ConstSInt64   of Identifier * ConstSInt64
    | ConstReal64   of Identifier * ConstReal64
    | Module    of Identifier * (Declaration list)

and Expr =
    | If        of Expr * Expr * Expr
    | Let       of Identifier list * Expr
    | Apply     of Identifier * (Expr list)
    | Value     of Value




