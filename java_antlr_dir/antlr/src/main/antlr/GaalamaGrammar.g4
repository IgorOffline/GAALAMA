grammar GaalamaGrammar;
gaalamaexec          : 'GAALAMA EXEC' ;
gaalamaint           : INT ;
gaalamavarname       : VARNAME ;
gaalamaequals        : ' = ' ;
gaalamainit          : 'INIT' ;
gaalamabigint        : 'BIGINT' ;
gaalamadi            : 'DI' ;
gaalamado            : 'DO' ;
gaalamainitbigint    : gaalamainit gaalamabigint gaalamavarname ;
gaalamainitbigintset : gaalamainitbigint gaalamaequals gaalamaint ;
gaalamamain          : gaalamaexec (gaalamainitbigint |
                       gaalamainitbigintset |
                       gaalamadi |
                       gaalamado)* ;
INT                  : [0-9]+ ;
VARNAME              : [a-z0-9\-_]+ ;
WS                   : [ \t\r\n]+ -> skip ;