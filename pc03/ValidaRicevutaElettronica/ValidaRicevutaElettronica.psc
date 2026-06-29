Proceso ValidaRicevutaElettronica
    Definir valido Como Logico
    
    valido <- ValidaCodigo("A121-32121")
    Escribir "es valido: ", valido
    Escribir "----"
    
    valido <- ValidaCodigo("B123-00032123")
    Escribir "es valido: ", valido
    Escribir "----"
    
    valido <- ValidaCodigo("B1234-0032123")
    Escribir "es valido: ", valido
    Escribir "----"
    
    valido <- ValidaCodigo("B123-0003212A")
    Escribir "es valido: ", valido
    Escribir "----"
FinProceso

Funcion retorno <- ValidaCodigo(codigo)
    Definir i, longitud Como Entero
    Definir caracterActual Como Caracter
    Definir valido Como Logico
    
    Escribir "[INFO] Validando codigo: ", codigo
    longitud <- Longitud(codigo)
    
    Si longitud <> 13 Entonces
        Escribir "[ERR] La longitud del codigo es incorrecta (debe ser de 13 caracteres)"
        retorno <- Falso
    Sino
        valido <- Verdadero
        i <- 1
        
        Mientras i <= longitud Y valido Hacer
            caracterActual <- Subcadena(codigo, i, i)
            
            Si i = 1 Entonces
                Si caracterActual <> "B" Y caracterActual <> "F" Entonces
                    Escribir "[ERR] Primer caracter no valido"
                    valido <- Falso
                FinSi
            Sino
                Si i = 5 Entonces
                    Si caracterActual <> "-" Entonces
                        Escribir "[ERR] Ubicacion del caracter '-' no valida"
                        valido <- Falso
                    FinSi
                Sino
                    Si caracterActual < "0" O caracterActual > "9" Entonces
                        Escribir "[ERR] No es un digito: ", caracterActual
                        valido <- Falso
                    FinSi
                FinSi
            FinSi
            
            i <- i + 1
        FinMientras
        
        retorno <- valido
    FinSi
FinFuncion
