// Implementation file for parser generated by fsyacc
module Parser
#nowarn "64";; // turn off warnings that type variables used in production annotations are instantiated to concrete type
open Microsoft.FSharp.Text.Lexing
open Microsoft.FSharp.Text.Parsing.ParseHelpers
# 23 "Parser.fsy"

open UntypedAst
open System

# 11 "Parser.fs"
// This type is the type of tokens accepted by the parser
type token = 
  | EOF
  | KW_OPEN of (TokenInfo)
  | KW_ALIAS of (TokenInfo)
  | KW_FN of (TokenInfo)
  | KW_MODULE of (TokenInfo)
  | KW_UNION of (TokenInfo)
  | KW_RECORD of (TokenInfo)
  | KW_STRUCT of (TokenInfo)
  | YIELD of (TokenInfo)
  | SC of (TokenInfo)
  | DOT of (TokenInfo)
  | COL of (TokenInfo)
  | COMMA of (TokenInfo)
  | RIGHT_HASH of (TokenInfo)
  | LEFT_HASH of (TokenInfo)
  | RIGHT_PAREN of (TokenInfo)
  | LEFT_PAREN of (TokenInfo)
  | RIGHT_BRACK of (TokenInfo)
  | LEFT_BRACK of (TokenInfo)
  | RIGHT_BRACE of (TokenInfo)
  | LEFT_BRACE of (TokenInfo)
  | IDENTIFIER of (Identifier)
  | FALSE of (Expr)
  | TRUE of (Expr)
  | CHAR of (Expr)
  | STRING of (Expr)
  | REAL64 of (Expr)
  | SINT64 of (Expr)
// This type is used to give symbolic names to token indexes, useful for error messages
type tokenId = 
    | TOKEN_EOF
    | TOKEN_KW_OPEN
    | TOKEN_KW_ALIAS
    | TOKEN_KW_FN
    | TOKEN_KW_MODULE
    | TOKEN_KW_UNION
    | TOKEN_KW_RECORD
    | TOKEN_KW_STRUCT
    | TOKEN_YIELD
    | TOKEN_SC
    | TOKEN_DOT
    | TOKEN_COL
    | TOKEN_COMMA
    | TOKEN_RIGHT_HASH
    | TOKEN_LEFT_HASH
    | TOKEN_RIGHT_PAREN
    | TOKEN_LEFT_PAREN
    | TOKEN_RIGHT_BRACK
    | TOKEN_LEFT_BRACK
    | TOKEN_RIGHT_BRACE
    | TOKEN_LEFT_BRACE
    | TOKEN_IDENTIFIER
    | TOKEN_FALSE
    | TOKEN_TRUE
    | TOKEN_CHAR
    | TOKEN_STRING
    | TOKEN_REAL64
    | TOKEN_SINT64
    | TOKEN_end_of_input
    | TOKEN_error
// This type is used to give symbolic names to token indexes, useful for error messages
type nonTerminalId = 
    | NONTERM__startstart
    | NONTERM_start
    | NONTERM_document
    | NONTERM_Struct
    | NONTERM_Record
    | NONTERM_Union
    | NONTERM_Module
    | NONTERM_Alias
    | NONTERM_Open
    | NONTERM_decl
    | NONTERM_decl_list
    | NONTERM_field
    | NONTERM_field_list
    | NONTERM_array_type
    | NONTERM_atype
    | NONTERM_func_type
    | NONTERM_fun_args
    | NONTERM_identifier
    | NONTERM_path

// This function maps tokens to integer indexes
let tagOfToken (t:token) = 
  match t with
  | EOF  -> 0 
  | KW_OPEN _ -> 1 
  | KW_ALIAS _ -> 2 
  | KW_FN _ -> 3 
  | KW_MODULE _ -> 4 
  | KW_UNION _ -> 5 
  | KW_RECORD _ -> 6 
  | KW_STRUCT _ -> 7 
  | YIELD _ -> 8 
  | SC _ -> 9 
  | DOT _ -> 10 
  | COL _ -> 11 
  | COMMA _ -> 12 
  | RIGHT_HASH _ -> 13 
  | LEFT_HASH _ -> 14 
  | RIGHT_PAREN _ -> 15 
  | LEFT_PAREN _ -> 16 
  | RIGHT_BRACK _ -> 17 
  | LEFT_BRACK _ -> 18 
  | RIGHT_BRACE _ -> 19 
  | LEFT_BRACE _ -> 20 
  | IDENTIFIER _ -> 21 
  | FALSE _ -> 22 
  | TRUE _ -> 23 
  | CHAR _ -> 24 
  | STRING _ -> 25 
  | REAL64 _ -> 26 
  | SINT64 _ -> 27 

// This function maps integer indexes to symbolic token ids
let tokenTagToTokenId (tokenIdx:int) = 
  match tokenIdx with
  | 0 -> TOKEN_EOF 
  | 1 -> TOKEN_KW_OPEN 
  | 2 -> TOKEN_KW_ALIAS 
  | 3 -> TOKEN_KW_FN 
  | 4 -> TOKEN_KW_MODULE 
  | 5 -> TOKEN_KW_UNION 
  | 6 -> TOKEN_KW_RECORD 
  | 7 -> TOKEN_KW_STRUCT 
  | 8 -> TOKEN_YIELD 
  | 9 -> TOKEN_SC 
  | 10 -> TOKEN_DOT 
  | 11 -> TOKEN_COL 
  | 12 -> TOKEN_COMMA 
  | 13 -> TOKEN_RIGHT_HASH 
  | 14 -> TOKEN_LEFT_HASH 
  | 15 -> TOKEN_RIGHT_PAREN 
  | 16 -> TOKEN_LEFT_PAREN 
  | 17 -> TOKEN_RIGHT_BRACK 
  | 18 -> TOKEN_LEFT_BRACK 
  | 19 -> TOKEN_RIGHT_BRACE 
  | 20 -> TOKEN_LEFT_BRACE 
  | 21 -> TOKEN_IDENTIFIER 
  | 22 -> TOKEN_FALSE 
  | 23 -> TOKEN_TRUE 
  | 24 -> TOKEN_CHAR 
  | 25 -> TOKEN_STRING 
  | 26 -> TOKEN_REAL64 
  | 27 -> TOKEN_SINT64 
  | 30 -> TOKEN_end_of_input
  | 28 -> TOKEN_error
  | _ -> failwith "tokenTagToTokenId: bad token"

/// This function maps production indexes returned in syntax errors to strings representing the non terminal that would be produced by that production
let prodIdxToNonTerminal (prodIdx:int) = 
  match prodIdx with
    | 0 -> NONTERM__startstart 
    | 1 -> NONTERM_start 
    | 2 -> NONTERM_document 
    | 3 -> NONTERM_document 
    | 4 -> NONTERM_Struct 
    | 5 -> NONTERM_Struct 
    | 6 -> NONTERM_Record 
    | 7 -> NONTERM_Record 
    | 8 -> NONTERM_Union 
    | 9 -> NONTERM_Union 
    | 10 -> NONTERM_Module 
    | 11 -> NONTERM_Module 
    | 12 -> NONTERM_Alias 
    | 13 -> NONTERM_Open 
    | 14 -> NONTERM_decl 
    | 15 -> NONTERM_decl 
    | 16 -> NONTERM_decl 
    | 17 -> NONTERM_decl 
    | 18 -> NONTERM_decl_list 
    | 19 -> NONTERM_decl_list 
    | 20 -> NONTERM_field 
    | 21 -> NONTERM_field 
    | 22 -> NONTERM_field 
    | 23 -> NONTERM_field_list 
    | 24 -> NONTERM_field_list 
    | 25 -> NONTERM_array_type 
    | 26 -> NONTERM_atype 
    | 27 -> NONTERM_atype 
    | 28 -> NONTERM_atype 
    | 29 -> NONTERM_func_type 
    | 30 -> NONTERM_fun_args 
    | 31 -> NONTERM_fun_args 
    | 32 -> NONTERM_identifier 
    | 33 -> NONTERM_path 
    | 34 -> NONTERM_path 
    | _ -> failwith "prodIdxToNonTerminal: bad production index"

let _fsyacc_endOfInputTag = 30 
let _fsyacc_tagOfErrorTerminal = 28

// This function gets the name of a token as a string
let token_to_string (t:token) = 
  match t with 
  | EOF  -> "EOF" 
  | KW_OPEN _ -> "KW_OPEN" 
  | KW_ALIAS _ -> "KW_ALIAS" 
  | KW_FN _ -> "KW_FN" 
  | KW_MODULE _ -> "KW_MODULE" 
  | KW_UNION _ -> "KW_UNION" 
  | KW_RECORD _ -> "KW_RECORD" 
  | KW_STRUCT _ -> "KW_STRUCT" 
  | YIELD _ -> "YIELD" 
  | SC _ -> "SC" 
  | DOT _ -> "DOT" 
  | COL _ -> "COL" 
  | COMMA _ -> "COMMA" 
  | RIGHT_HASH _ -> "RIGHT_HASH" 
  | LEFT_HASH _ -> "LEFT_HASH" 
  | RIGHT_PAREN _ -> "RIGHT_PAREN" 
  | LEFT_PAREN _ -> "LEFT_PAREN" 
  | RIGHT_BRACK _ -> "RIGHT_BRACK" 
  | LEFT_BRACK _ -> "LEFT_BRACK" 
  | RIGHT_BRACE _ -> "RIGHT_BRACE" 
  | LEFT_BRACE _ -> "LEFT_BRACE" 
  | IDENTIFIER _ -> "IDENTIFIER" 
  | FALSE _ -> "FALSE" 
  | TRUE _ -> "TRUE" 
  | CHAR _ -> "CHAR" 
  | STRING _ -> "STRING" 
  | REAL64 _ -> "REAL64" 
  | SINT64 _ -> "SINT64" 

// This function gets the data carried by a token as an object
let _fsyacc_dataOfToken (t:token) = 
  match t with 
  | EOF  -> (null : System.Object) 
  | KW_OPEN _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | KW_ALIAS _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | KW_FN _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | KW_MODULE _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | KW_UNION _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | KW_RECORD _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | KW_STRUCT _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | YIELD _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | SC _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | DOT _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | COL _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | COMMA _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | RIGHT_HASH _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | LEFT_HASH _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | RIGHT_PAREN _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | LEFT_PAREN _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | RIGHT_BRACK _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | LEFT_BRACK _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | RIGHT_BRACE _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | LEFT_BRACE _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | IDENTIFIER _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | FALSE _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | TRUE _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | CHAR _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | STRING _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | REAL64 _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | SINT64 _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
let _fsyacc_gotos = [| 0us; 65535us; 1us; 65535us; 0us; 1us; 1us; 65535us; 0us; 2us; 4us; 65535us; 0us; 29us; 4us; 29us; 25us; 29us; 26us; 29us; 4us; 65535us; 0us; 30us; 4us; 30us; 25us; 30us; 26us; 30us; 4us; 65535us; 0us; 31us; 4us; 31us; 25us; 31us; 26us; 31us; 4us; 65535us; 0us; 32us; 4us; 32us; 25us; 32us; 26us; 32us; 0us; 65535us; 0us; 65535us; 4us; 65535us; 0us; 33us; 4us; 35us; 25us; 33us; 26us; 35us; 2us; 65535us; 0us; 4us; 25us; 26us; 8us; 65535us; 7us; 40us; 8us; 42us; 13us; 40us; 14us; 42us; 19us; 40us; 20us; 42us; 50us; 54us; 55us; 56us; 3us; 65535us; 7us; 8us; 13us; 14us; 19us; 20us; 2us; 65535us; 38us; 48us; 53us; 48us; 2us; 65535us; 38us; 39us; 53us; 44us; 2us; 65535us; 38us; 49us; 53us; 49us; 1us; 65535us; 50us; 51us; 15us; 65535us; 5us; 6us; 7us; 37us; 8us; 37us; 11us; 12us; 13us; 37us; 14us; 37us; 17us; 18us; 19us; 37us; 20us; 37us; 23us; 24us; 38us; 58us; 50us; 37us; 53us; 58us; 55us; 37us; 59us; 60us; 2us; 65535us; 38us; 47us; 53us; 47us; |]
let _fsyacc_sparseGotoTableRowOffsets = [|0us; 1us; 3us; 5us; 10us; 15us; 20us; 25us; 26us; 27us; 32us; 35us; 44us; 48us; 51us; 54us; 57us; 59us; 75us; |]
let _fsyacc_stateToProdIdxsTableElements = [| 1us; 0us; 1us; 0us; 1us; 1us; 1us; 2us; 2us; 3us; 19us; 2us; 4us; 5us; 2us; 4us; 5us; 2us; 4us; 5us; 2us; 4us; 24us; 1us; 4us; 1us; 5us; 2us; 6us; 7us; 2us; 6us; 7us; 2us; 6us; 7us; 2us; 6us; 24us; 1us; 6us; 1us; 7us; 2us; 8us; 9us; 2us; 8us; 9us; 2us; 8us; 9us; 2us; 8us; 24us; 1us; 8us; 1us; 9us; 2us; 10us; 11us; 2us; 10us; 11us; 2us; 10us; 11us; 2us; 10us; 19us; 1us; 10us; 1us; 11us; 1us; 14us; 1us; 15us; 1us; 16us; 1us; 17us; 1us; 18us; 1us; 18us; 1us; 19us; 1us; 19us; 3us; 20us; 21us; 22us; 2us; 20us; 21us; 2us; 20us; 25us; 1us; 23us; 1us; 23us; 1us; 24us; 1us; 24us; 2us; 25us; 29us; 1us; 25us; 1us; 25us; 2us; 26us; 34us; 1us; 27us; 1us; 28us; 1us; 29us; 2us; 29us; 31us; 1us; 29us; 1us; 29us; 1us; 30us; 1us; 31us; 1us; 31us; 1us; 32us; 1us; 33us; 1us; 34us; 1us; 34us; |]
let _fsyacc_stateToProdIdxsTableRowOffsets = [|0us; 2us; 4us; 6us; 8us; 11us; 14us; 17us; 20us; 23us; 25us; 27us; 30us; 33us; 36us; 39us; 41us; 43us; 46us; 49us; 52us; 55us; 57us; 59us; 62us; 65us; 68us; 71us; 73us; 75us; 77us; 79us; 81us; 83us; 85us; 87us; 89us; 91us; 95us; 98us; 101us; 103us; 105us; 107us; 109us; 112us; 114us; 116us; 119us; 121us; 123us; 125us; 128us; 130us; 132us; 134us; 136us; 138us; 140us; 142us; 144us; |]
let _fsyacc_action_rows = 61
let _fsyacc_actionTableElements = [|5us; 32768us; 0us; 3us; 4us; 23us; 5us; 17us; 6us; 11us; 7us; 5us; 0us; 49152us; 0us; 16385us; 0us; 16386us; 4us; 16387us; 4us; 23us; 5us; 17us; 6us; 11us; 7us; 5us; 1us; 32768us; 21us; 57us; 1us; 32768us; 20us; 7us; 2us; 32768us; 19us; 10us; 21us; 57us; 2us; 32768us; 19us; 9us; 21us; 57us; 0us; 16388us; 0us; 16389us; 1us; 32768us; 21us; 57us; 1us; 32768us; 20us; 13us; 2us; 32768us; 19us; 16us; 21us; 57us; 2us; 32768us; 19us; 15us; 21us; 57us; 0us; 16390us; 0us; 16391us; 1us; 32768us; 21us; 57us; 1us; 32768us; 20us; 19us; 2us; 32768us; 19us; 22us; 21us; 57us; 2us; 32768us; 19us; 21us; 21us; 57us; 0us; 16392us; 0us; 16393us; 1us; 32768us; 21us; 57us; 1us; 32768us; 20us; 25us; 5us; 32768us; 4us; 23us; 5us; 17us; 6us; 11us; 7us; 5us; 19us; 28us; 5us; 32768us; 4us; 23us; 5us; 17us; 6us; 11us; 7us; 5us; 19us; 27us; 0us; 16394us; 0us; 16395us; 0us; 16398us; 0us; 16399us; 0us; 16400us; 0us; 16401us; 1us; 32768us; 9us; 34us; 0us; 16402us; 1us; 32768us; 9us; 36us; 0us; 16403us; 1us; 16406us; 11us; 38us; 2us; 16405us; 16us; 50us; 21us; 57us; 1us; 16404us; 18us; 45us; 1us; 32768us; 9us; 41us; 0us; 16407us; 1us; 32768us; 9us; 43us; 0us; 16408us; 1us; 16413us; 18us; 45us; 1us; 32768us; 17us; 46us; 0us; 16409us; 1us; 16410us; 10us; 59us; 0us; 16411us; 0us; 16412us; 1us; 32768us; 21us; 57us; 2us; 32768us; 12us; 55us; 15us; 52us; 1us; 32768us; 8us; 53us; 2us; 32768us; 16us; 50us; 21us; 57us; 0us; 16414us; 1us; 32768us; 21us; 57us; 0us; 16415us; 0us; 16416us; 0us; 16417us; 1us; 32768us; 21us; 57us; 0us; 16418us; |]
let _fsyacc_actionTableRowOffsets = [|0us; 6us; 7us; 8us; 9us; 14us; 16us; 18us; 21us; 24us; 25us; 26us; 28us; 30us; 33us; 36us; 37us; 38us; 40us; 42us; 45us; 48us; 49us; 50us; 52us; 54us; 60us; 66us; 67us; 68us; 69us; 70us; 71us; 72us; 74us; 75us; 77us; 78us; 80us; 83us; 85us; 87us; 88us; 90us; 91us; 93us; 95us; 96us; 98us; 99us; 100us; 102us; 105us; 107us; 110us; 111us; 113us; 114us; 115us; 116us; 118us; |]
let _fsyacc_reductionSymbolCounts = [|1us; 1us; 1us; 1us; 5us; 4us; 5us; 4us; 5us; 4us; 5us; 4us; 3us; 2us; 1us; 1us; 1us; 1us; 2us; 3us; 3us; 2us; 1us; 2us; 3us; 3us; 1us; 1us; 1us; 5us; 1us; 3us; 1us; 1us; 3us; |]
let _fsyacc_productionToNonTerminalTable = [|0us; 1us; 2us; 2us; 3us; 3us; 4us; 4us; 5us; 5us; 6us; 6us; 7us; 8us; 9us; 9us; 9us; 9us; 10us; 10us; 11us; 11us; 11us; 12us; 12us; 13us; 14us; 14us; 14us; 15us; 16us; 16us; 17us; 18us; 18us; |]
let _fsyacc_immediateActions = [|65535us; 49152us; 16385us; 16386us; 65535us; 65535us; 65535us; 65535us; 65535us; 16388us; 16389us; 65535us; 65535us; 65535us; 65535us; 16390us; 16391us; 65535us; 65535us; 65535us; 65535us; 16392us; 16393us; 65535us; 65535us; 65535us; 65535us; 16394us; 16395us; 16398us; 16399us; 16400us; 16401us; 65535us; 16402us; 65535us; 16403us; 65535us; 65535us; 65535us; 65535us; 16407us; 65535us; 16408us; 65535us; 65535us; 16409us; 65535us; 16411us; 16412us; 65535us; 65535us; 65535us; 65535us; 16414us; 65535us; 16415us; 16416us; 16417us; 65535us; 16418us; |]
let _fsyacc_reductions ()  =    [| 
# 280 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Declaration list)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
                      raise (Microsoft.FSharp.Text.Parsing.Accept(Microsoft.FSharp.Core.Operators.box _1))
                   )
                 : '_startstart));
# 289 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'document)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 68 "Parser.fsy"
                                                                   _1 
                   )
# 68 "Parser.fsy"
                 : Declaration list));
# 300 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 70 "Parser.fsy"
                                                                   [] 
                   )
# 70 "Parser.fsy"
                 : 'document));
# 310 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Declaration list)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 71 "Parser.fsy"
                                                                   List.rev _1 
                   )
# 71 "Parser.fsy"
                 : 'document));
# 321 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : TokenInfo)) in
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'identifier)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : TokenInfo)) in
            let _4 = (let data = parseState.GetInput(4) in (Microsoft.FSharp.Core.Operators.unbox data : 'field_list)) in
            let _5 = (let data = parseState.GetInput(5) in (Microsoft.FSharp.Core.Operators.unbox data : TokenInfo)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 73 "Parser.fsy"
                                                                                               Struct (_2, List.rev _4) 
                   )
# 73 "Parser.fsy"
                 : 'Struct));
# 336 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : TokenInfo)) in
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'identifier)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : TokenInfo)) in
            let _4 = (let data = parseState.GetInput(4) in (Microsoft.FSharp.Core.Operators.unbox data : TokenInfo)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 74 "Parser.fsy"
                                                                                               raise (Exception (sprintf "Structs cannot be empty: struct %s" (fst _2))) 
                   )
# 74 "Parser.fsy"
                 : 'Struct));
# 350 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : TokenInfo)) in
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'identifier)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : TokenInfo)) in
            let _4 = (let data = parseState.GetInput(4) in (Microsoft.FSharp.Core.Operators.unbox data : 'field_list)) in
            let _5 = (let data = parseState.GetInput(5) in (Microsoft.FSharp.Core.Operators.unbox data : TokenInfo)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 76 "Parser.fsy"
                                                                                               Record (_2, List.rev _4) 
                   )
# 76 "Parser.fsy"
                 : 'Record));
# 365 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : TokenInfo)) in
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'identifier)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : TokenInfo)) in
            let _4 = (let data = parseState.GetInput(4) in (Microsoft.FSharp.Core.Operators.unbox data : TokenInfo)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 77 "Parser.fsy"
                                                                                               Record (_2, []) 
                   )
# 77 "Parser.fsy"
                 : 'Record));
# 379 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : TokenInfo)) in
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'identifier)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : TokenInfo)) in
            let _4 = (let data = parseState.GetInput(4) in (Microsoft.FSharp.Core.Operators.unbox data : 'field_list)) in
            let _5 = (let data = parseState.GetInput(5) in (Microsoft.FSharp.Core.Operators.unbox data : TokenInfo)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 79 "Parser.fsy"
                                                                                               Union  (_2, List.rev _4) 
                   )
# 79 "Parser.fsy"
                 : 'Union));
# 394 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : TokenInfo)) in
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'identifier)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : TokenInfo)) in
            let _4 = (let data = parseState.GetInput(4) in (Microsoft.FSharp.Core.Operators.unbox data : TokenInfo)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 80 "Parser.fsy"
                                                                                               raise (Exception (sprintf "Unions cannot be empty: union %s" (fst _2))) 
                   )
# 80 "Parser.fsy"
                 : 'Union));
# 408 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : TokenInfo)) in
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'identifier)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : TokenInfo)) in
            let _4 = (let data = parseState.GetInput(4) in (Microsoft.FSharp.Core.Operators.unbox data : Declaration list)) in
            let _5 = (let data = parseState.GetInput(5) in (Microsoft.FSharp.Core.Operators.unbox data : TokenInfo)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 82 "Parser.fsy"
                                                                                               Module (_2, List.rev _4) 
                   )
# 82 "Parser.fsy"
                 : 'Module));
# 423 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : TokenInfo)) in
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'identifier)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : TokenInfo)) in
            let _4 = (let data = parseState.GetInput(4) in (Microsoft.FSharp.Core.Operators.unbox data : TokenInfo)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 83 "Parser.fsy"
                                                                                               Module (_2, []) 
                   )
# 83 "Parser.fsy"
                 : 'Module));
# 437 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : TokenInfo)) in
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'path)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : 'path)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 85 "Parser.fsy"
                                                                                               Alias (_2, _3) 
                   )
# 85 "Parser.fsy"
                 : 'Alias));
# 450 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : TokenInfo)) in
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'path)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 87 "Parser.fsy"
                                                                                               Open _2 
                   )
# 87 "Parser.fsy"
                 : 'Open));
# 462 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'Struct)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 89 "Parser.fsy"
                                                                   _1 
                   )
# 89 "Parser.fsy"
                 : Declaration));
# 473 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'Record)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 90 "Parser.fsy"
                                                                   _1 
                   )
# 90 "Parser.fsy"
                 : Declaration));
# 484 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'Union)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 91 "Parser.fsy"
                                                                   _1 
                   )
# 91 "Parser.fsy"
                 : Declaration));
# 495 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'Module)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 92 "Parser.fsy"
                                                                   _1 
                   )
# 92 "Parser.fsy"
                 : Declaration));
# 506 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Declaration)) in
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : TokenInfo)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 94 "Parser.fsy"
                                                                   [ _1 ] 
                   )
# 94 "Parser.fsy"
                 : Declaration list));
# 518 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Declaration list)) in
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : Declaration)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : TokenInfo)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 95 "Parser.fsy"
                                                                   _2 :: _1 
                   )
# 95 "Parser.fsy"
                 : Declaration list));
# 531 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'identifier)) in
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : TokenInfo)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : 'atype)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 97 "Parser.fsy"
                                                                   { Field.Identifier = _1; Type = _3 } 
                   )
# 97 "Parser.fsy"
                 : 'field));
# 544 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'identifier)) in
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : TokenInfo)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 98 "Parser.fsy"
                                                                   raise (Exception (sprintf "a 'type' is required after '%s :'" (fst _1))) 
                   )
# 98 "Parser.fsy"
                 : 'field));
# 556 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'identifier)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 99 "Parser.fsy"
                                                                   raise (Exception (sprintf "a ': type' is required after '%s'" (fst _1))) 
                   )
# 99 "Parser.fsy"
                 : 'field));
# 567 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'field)) in
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : TokenInfo)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 101 "Parser.fsy"
                                                                   [ _1 ] 
                   )
# 101 "Parser.fsy"
                 : 'field_list));
# 579 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'field_list)) in
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'field)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : TokenInfo)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 102 "Parser.fsy"
                                                                   _2 :: _1 
                   )
# 102 "Parser.fsy"
                 : 'field_list));
# 592 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'atype)) in
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : TokenInfo)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : TokenInfo)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 104 "Parser.fsy"
                                                                   Type.Array _1 
                   )
# 104 "Parser.fsy"
                 : 'array_type));
# 605 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'path)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 106 "Parser.fsy"
                                                                   Type.Path (List.rev _1) 
                   )
# 106 "Parser.fsy"
                 : 'atype));
# 616 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'array_type)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 107 "Parser.fsy"
                                                                   _1
                   )
# 107 "Parser.fsy"
                 : 'atype));
# 627 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'func_type)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 108 "Parser.fsy"
                                                                   Type.Function _1 
                   )
# 108 "Parser.fsy"
                 : 'atype));
# 638 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : TokenInfo)) in
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'fun_args)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : TokenInfo)) in
            let _4 = (let data = parseState.GetInput(4) in (Microsoft.FSharp.Core.Operators.unbox data : TokenInfo)) in
            let _5 = (let data = parseState.GetInput(5) in (Microsoft.FSharp.Core.Operators.unbox data : 'atype)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 110 "Parser.fsy"
                                                                                    (_5, List.rev _2) 
                   )
# 110 "Parser.fsy"
                 : 'func_type));
# 653 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'field)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 112 "Parser.fsy"
                                                                   [ _1 ] 
                   )
# 112 "Parser.fsy"
                 : 'fun_args));
# 664 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'fun_args)) in
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : TokenInfo)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : 'field)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 113 "Parser.fsy"
                                                                   _3 :: _1 
                   )
# 113 "Parser.fsy"
                 : 'fun_args));
# 677 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Identifier)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 116 "Parser.fsy"
                                                                   _1 
                   )
# 116 "Parser.fsy"
                 : 'identifier));
# 688 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'identifier)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 118 "Parser.fsy"
                                                                   [ _1 ] 
                   )
# 118 "Parser.fsy"
                 : 'path));
# 699 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'path)) in
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : TokenInfo)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : 'identifier)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 119 "Parser.fsy"
                                                                   _3 :: _1 
                   )
# 119 "Parser.fsy"
                 : 'path));
|]
# 713 "Parser.fs"
let tables () : Microsoft.FSharp.Text.Parsing.Tables<_> = 
  { reductions= _fsyacc_reductions ();
    endOfInputTag = _fsyacc_endOfInputTag;
    tagOfToken = tagOfToken;
    dataOfToken = _fsyacc_dataOfToken; 
    actionTableElements = _fsyacc_actionTableElements;
    actionTableRowOffsets = _fsyacc_actionTableRowOffsets;
    stateToProdIdxsTableElements = _fsyacc_stateToProdIdxsTableElements;
    stateToProdIdxsTableRowOffsets = _fsyacc_stateToProdIdxsTableRowOffsets;
    reductionSymbolCounts = _fsyacc_reductionSymbolCounts;
    immediateActions = _fsyacc_immediateActions;
    gotos = _fsyacc_gotos;
    sparseGotoTableRowOffsets = _fsyacc_sparseGotoTableRowOffsets;
    tagOfErrorTerminal = _fsyacc_tagOfErrorTerminal;
    parseError = (fun (ctxt:Microsoft.FSharp.Text.Parsing.ParseErrorContext<_>) -> 
                              match parse_error_rich with 
                              | Some f -> f ctxt
                              | None -> parse_error ctxt.Message);
    numTerminals = 31;
    productionToNonTerminalTable = _fsyacc_productionToNonTerminalTable  }
let engine lexer lexbuf startState = (tables ()).Interpret(lexer, lexbuf, startState)
let start lexer lexbuf : Declaration list =
    Microsoft.FSharp.Core.Operators.unbox ((tables ()).Interpret(lexer, lexbuf, 0))
