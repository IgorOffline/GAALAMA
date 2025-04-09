grammar GaalamaGrammar;
gaalamaexec       : 'GAALAMA EXEC';
gaalamavarname    : VARNAME ;
gaalamainit       : 'INIT' ;
gaalamabigint     : 'BIGINT' ;
gaalamadi         : 'DI' ;
gaalamado         : 'DO' ;
gaalamainitbigint : gaalamainit gaalamabigint gaalamavarname ;
gaalamamain       : gaalamaexec (gaalamainitbigint |
                    gaalamadi |
                    gaalamado)* ;
INT               : [0-9]+ ;
VARNAME           : [a-z0-9\-_]+ ;
WS                : [ \t\r\n]+ -> skip ;