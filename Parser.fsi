// Signature file for parser generated by fsyacc
module Parser
type token = 
  | EOF
  | KW_LET of (TokenInfo)
  | KW_ELSE of (TokenInfo)
  | KW_IF of (TokenInfo)
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
type tokenId = 
    | TOKEN_EOF
    | TOKEN_KW_LET
    | TOKEN_KW_ELSE
    | TOKEN_KW_IF
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
    | NONTERM_func
    | NONTERM_func_body
    | NONTERM_expr_list
    | NONTERM_expr
/// This function maps tokens to integer indexes
val tagOfToken: token -> int

/// This function maps integer indexes to symbolic token ids
val tokenTagToTokenId: int -> tokenId

/// This function maps production indexes returned in syntax errors to strings representing the non terminal that would be produced by that production
val prodIdxToNonTerminal: int -> nonTerminalId

/// This function gets the name of a token as a string
val token_to_string: token -> string
val start : (Microsoft.FSharp.Text.Lexing.LexBuffer<'cty> -> token) -> Microsoft.FSharp.Text.Lexing.LexBuffer<'cty> -> (Declaration list) 
