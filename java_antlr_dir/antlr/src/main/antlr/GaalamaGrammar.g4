grammar GaalamaGrammar;
gaalamaexec             : 'GAALAMA EXEC' ;
gaalamaint              : INT ;
gaalamavarname          : VARNAME ;
gaalamaequals           : ' = ' ;
gaalamaaddoperator      : ' += ' ;
gaalamasubtractoperator : ' -= ' ;
gaalamainit             : 'INIT' ;
gaalamabigint           : 'BIGINT' ;
gaalamadi               : 'DI' ;
gaalamado               : 'DO' ;
gaalamainitbigint       : gaalamainit gaalamabigint gaalamavarname ;
gaalamainitbigintset    : gaalamainitbigint gaalamaequals gaalamaint ;
gaalamasubtract         : gaalamavarname gaalamasubtractoperator gaalamaint ;
gaalamamain             : gaalamaexec (gaalamainitbigint |
                          gaalamainitbigintset |
                          gaalamasubtract |
                          gaalamadi |
                          gaalamado)* ;
INT                     : [0-9]+ ;
VARNAME                 : [a-z0-9\-_]+ ;
WS                      : [ \t\r\n]+ -> skip ;