using System;

Console.WriteLine("MENÚ DE CALCULADORA");

double num1 = LeerNumero("Ingrese el primer número: ");
double num2 = LeerNumero("Ingrese el segundo número: ");

Console.WriteLine("\nSeleccione la operación:");
Console.WriteLine("1. Suma");
Console.WriteLine("2. Resta");
Console.WriteLine("3. Multiplicación");
Console.WriteLine("4. División");
Console.Write("Opción: ");
int opzione = Convert.ToInt32(Console.ReadLine());

switch (opzione)
{
    case 1:
        Console.WriteLine($"Resultado: {num1} + {num2} = {num1 + num2:N2} ");
        break;
    case 2:
        Console.WriteLine($"Resultado: {num1} - {num2} = {num1 - num2:N2} ");
        break;
    case 3:
        Console.WriteLine($"Resultado: {num1} * {num2} = {num1 * num2:N2} ");
        break;
    case 4:
        if (num2 != 0)
        {
            Console.WriteLine($"Resultado: {num1} / {num2} = {num1 / num2:N2} ");
        }
        else
        {
            Console.WriteLine("Error: No se puede dividir por cero.");
        }
        break;
    default:
        Console.WriteLine("Opción no válida. Por favor, seleccione una opción del 1 al 4.");
        break;
}

static double LeerNumero(string messaggio)
    {
        double numero;
        while (true)
        {
            Console.Write(messaggio);
            string input = Console.ReadLine();

            if (double.TryParse(input, out numero))
            {
                return numero;
            }
            else
            {
                Console.WriteLine("Entrada no válida. Por favor, ingrese un número.");
            }
        }   
    }