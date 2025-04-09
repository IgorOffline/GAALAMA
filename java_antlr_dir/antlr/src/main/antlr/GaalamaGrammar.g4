grammar GaalamaGrammar;
gaalamaexec : 'GAALAMA EXEC';
gaalamadi   : 'DI' ;
gaalamado   : 'DO' ;
gaalamamain : gaalamaexec (gaalamadi |
              gaalamado)* ;
INT         : [0-9]+ ;
VARNAME     : [a-z0-9\-_]+ ;
WS          : [ \t\r\n]+ -> skip ;