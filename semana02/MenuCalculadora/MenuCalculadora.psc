Proceso Main
	Escribir "MENÚ DE CALCULADORA"

	Definir num1 Como Real;
	Definir num2 Como Real;
	Definir operacion Como Entero;

	num1 <- leerNumero("Ingrese el primer número:")
	num2 <- leerNumero("Ingrese el segundo número:")

	Escribir "Seleccione la operación:"
	Escribir "1. Suma"
	Escribir "2. Resta"
	Escribir "3. Multiplicación"
	Escribir "4. División"

	Escribir "Opción: "
	Leer operacion

	realizarOperacion(num1, num2, operacion)
FinProceso

SubProceso r <- realizarOperacion(num1, num2, operacion)
	Definir r Como Real

	Segun operacion Hacer
		1: Escribir "Resultado: ", num1, " + ", num2, " = ", (num1 + num2);
		2: Escribir "Resultado: ", num1, " - ", num2, " = ", (num1 - num2);
		3: Escribir "Resultado: ", num1, " * ", num2, " = ", (num1 * num2);
		4: dividir(num1, num2)
		De Otro Modo:
			Escribir "Opción no válida. Por favor, seleccione una opción del 1 al 4."
	FinSegun
FinSubProceso 

SubProceso dividir(dividendo, divisor)
	Si divisor = 0 Entonces
		Leer divisor
		dividir(dividendo, divisor)
	Sino
		Escribir "Resultado: ", dividendo, " / ", divisor, " = ", (dividendo / divisor)
	FinSi
FinSubProceso

Funcion r <- leerNumero(mensaje)
	Definir input Como Cadena

  	Escribir mensaje

  	Leer input
	Si esNumero(input) Entonces
		r <- ConvertirANumero(input)
	Sino
		Escribir "Entrada no válida. Por favor, ingrese un número."
		r <- leerNumero(mensaje)
	FinSi

FinFuncion

Funcion es_numero <- esNumero(texto_ingresado)
	Definir caracter_actual Como Cadena
	Definir largo, i Como Entero
	Definir es_numero Como Logico
	Definir cantidad_puntos Como Entero

	
	largo <- Longitud(texto_ingresado)
	es_numero <- Verdadero
	Si largo = 0 Entonces
        es_numero <- Falso
    FinSi

	Para i <- 0 Hasta largo - 1 Con Paso 1 Hacer
        caracter_actual <- Subcadena(texto_ingresado, i + 1, i + 1)

		Si caracter_actual = "." Entonces
			cantidad_puntos <- cantidad_puntos + 1
        SiNo
			Si caracter_actual < "0" O caracter_actual > "9" Entonces
				es_numero <- Falso // Encontró una letra o símbolo
			FinSi
        FinSi
    FinPara

	Si cantidad_puntos > 1 Entonces
        es_numero <- Falso
    FinSi

FinFuncion
