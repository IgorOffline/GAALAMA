grammar GaalamaGrammar;
gaalamaexec : 'GAALAMA EXEC';
gaalamamain : (gaalamaexec)* ;
INT             : [0-9]+ ;
VARNAME         : [a-zA-Z0-9\-_]+ ;
WS              : [ \t\r\n]+ -> skip ;