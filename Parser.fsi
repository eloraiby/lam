// Signature file for parser generated by fsyacc
module Parser
type token = 
  | EOF
  | KW_RULE of (TokenInfo)
  | KW_STATE of (TokenInfo)
  | KW_ENTITY of (TokenInfo)
  | KW_MODULE of (TokenInfo)
  | OP_NOT of (TokenInfo)
  | OP_XOR of (TokenInfo)
  | OP_OR of (TokenInfo)
  | OP_AND of (TokenInfo)
  | OP_DISJ of (TokenInfo)
  | OP_MOD of (TokenInfo)
  | OP_DIV of (TokenInfo)
  | OP_MUL of (TokenInfo)
  | OP_SUB of (TokenInfo)
  | OP_ADD of (TokenInfo)
  | OP_LNOT of (TokenInfo)
  | OP_LOR of (TokenInfo)
  | OP_LAND of (TokenInfo)
  | OP_GT of (TokenInfo)
  | OP_LT of (TokenInfo)
  | OP_EQ of (TokenInfo)
  | OP_GEQ of (TokenInfo)
  | OP_LEQ of (TokenInfo)
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
  | FALSE of (Constant)
  | TRUE of (Constant)
  | CHAR of (Constant)
  | STRING of (Constant)
  | REAL64 of (Constant)
  | SINT64 of (Constant)
type tokenId = 
    | TOKEN_EOF
    | TOKEN_KW_RULE
    | TOKEN_KW_STATE
    | TOKEN_KW_ENTITY
    | TOKEN_KW_MODULE
    | TOKEN_OP_NOT
    | TOKEN_OP_XOR
    | TOKEN_OP_OR
    | TOKEN_OP_AND
    | TOKEN_OP_DISJ
    | TOKEN_OP_MOD
    | TOKEN_OP_DIV
    | TOKEN_OP_MUL
    | TOKEN_OP_SUB
    | TOKEN_OP_ADD
    | TOKEN_OP_LNOT
    | TOKEN_OP_LOR
    | TOKEN_OP_LAND
    | TOKEN_OP_GT
    | TOKEN_OP_LT
    | TOKEN_OP_EQ
    | TOKEN_OP_GEQ
    | TOKEN_OP_LEQ
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
    | NONTERM_identifier
    | NONTERM_entity
    | NONTERM_entity_args
    | NONTERM_args
    | NONTERM_entity_body
    | NONTERM_func_args
    | NONTERM_func
    | NONTERM_rs_list
    | NONTERM_rule_elem
    | NONTERM_conjunction
    | NONTERM_disjunction
    | NONTERM_term
    | NONTERM_mul_exp
    | NONTERM_add_exp
    | NONTERM_boolean_op
    | NONTERM_boolean_exp
    | NONTERM_rule
    | NONTERM_state
    | NONTERM_module
    | NONTERM_module_body
    | NONTERM_entities
    | NONTERM_module_list
/// This function maps tokens to integer indexes
val tagOfToken: token -> int

/// This function maps integer indexes to symbolic token ids
val tokenTagToTokenId: int -> tokenId

/// This function maps production indexes returned in syntax errors to strings representing the non terminal that would be produced by that production
val prodIdxToNonTerminal: int -> nonTerminalId

/// This function gets the name of a token as a string
val token_to_string: token -> string
val start : (Microsoft.FSharp.Text.Lexing.LexBuffer<'cty> -> token) -> Microsoft.FSharp.Text.Lexing.LexBuffer<'cty> -> (Module list) 
