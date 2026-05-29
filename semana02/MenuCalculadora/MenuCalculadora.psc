Algoritmo MenuCalculadora
    // 1. Declaración de variables esenciales
    Definir num1, num2, risultato Como Real
    Definir operazione Como Entero
    
    Escribir "=== MENÚ DE CALCULADORA ==="
    
    // 2. Lectura de los números
    Escribir "Ingrese el primer número:"
    Leer num1
    Escribir "Ingrese el segundo número:"
    Leer num2
    
    // 3. Mostrar opciones del menú por primera vez
    Escribir "Seleccione la operación:"
    Escribir "1. Suma"
    Escribir "2. Resta"
    Escribir "3. Multiplicación"
    Escribir "4. División"
    Escribir "Opción (1-4): "
    Leer operazione

    // Mientras la opción NO sea válida (menor que 1 o mayor que 4)
    Mientras operazione < 1 O operazione > 4 Hacer
        Escribir "Opción no válida. Por favor, seleccione una opción del 1 al 4."
        Escribir "Opción: "
        Leer operazione
    FinMientras

    // 4. Procesar la operación seleccionada
    Segun operazione Hacer
        1:
            risultato <- num1 + num2
            Escribir "Resultado: ", num1, " + ", num2, " = ", risultato
        2:
            risultato <- num1 - num2
            Escribir "Resultado: ", num1, " - ", num2, " = ", risultato
        3:
            risultato <- num1 * num2
            Escribir "Resultado: ", num1, " * ", num2, " = ", risultato
        4:
            Mientras num2 = 0 Hacer
                Escribir "Error: No se puede dividir entre cero."
                Escribir "Por favor, ingrese un segundo número válido:"
                Leer num2
            FinMientras
            risultato <- num1 / num2
            Escribir "Resultado: ", num1, " / ", num2, " = ", risultato
    FinSegun
FinAlgoritmo