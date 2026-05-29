Algoritmo CalculadoraIMC
    Definir peso, altezza, imc Como Real
    
    Escribir "=== CALCULADORA DE IMC CON DIAGNÓSTICO ==="
   
   // --- Flusso Principale ---
    peso <- ValidareInput("Ingrese su peso en kg: ")
    altezza <- ValidareInput("Ingrese su altura en metros: ")
    
    imc <- CalcolareImc(peso, altezza)
    
    Escribir ""
    Escribir "Tu IMC es: ", imc
    
    Diagnosi(imc)
    
FinAlgoritmo


Funcion res <- CalcolareImc(peso, altezza)
    Definir res Como Real
    res <- peso / (altezza * altezza)
FinFuncion

Subproceso Diagnosi(imc)
   
    Si imc < 18.5 Entonces
        Escribir "Bajo peso"
    Sino
        Si imc >= 18.5 Y imc < 25.0 Entonces
            Escribir "Peso normal"
        Sino
            Si imc >= 25.0 Y imc < 30.0 Entonces
                Escribir "Sobrepeso"
            Sino
                Escribir "Obesidad"
            FinSi
        FinSi
    FinSi
FinSubproceso

Funcion valore <- ValidareInput(messaggio)
    Definir valore Como Real
    Definir valido Como Logico
    valido <- Falso
    
Mientras NO valido Hacer
        Escribir messaggio
        Leer valore
        
        // Validamos que sea un número mayor a cero
        Si valore > 0 Entonces
            valido <- Verdadero
        Sino
            Escribir "Entrada inválida. Por favor, ingrese un valor válido"
            Escribir ""
        FinSi
    FinMientras
FinFuncion