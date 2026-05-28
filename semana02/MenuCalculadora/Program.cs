using System;
using System.Security.Principal;

Main();

void Main()
{
    Console.WriteLine("MENÚ DE CALCULADORA");

    int operazione = LeggereOperazione();

    double num1 = LeggereNumero("Ingrese el primer número: ");
    double num2 = LeggereNumero("Ingrese el segundo número: ");

    ProcessaOperazione(num1, num2, operazione);
}

int LeggereOperazione()
{
    Console.WriteLine("\nSeleccione la operación:");
    Console.WriteLine("1. Suma");
    Console.WriteLine("2. Resta");
    Console.WriteLine("3. Multiplicación");
    Console.WriteLine("4. División");
    Console.Write("Opción: ");

    int opzione = Convert.ToInt32(Console.ReadLine());
    if (opzione < 1 || opzione > 4)
    {
        Console.WriteLine("Opción no válida. Por favor, seleccione una opción del 1 al 4.");
        return LeggereOperazione();
    }

    return opzione;
}

void ProcessaOperazione(double num1, double num2, int operazione)
{
    try
    {
        double risultato = EseguireOperazione(num1, num2, operazione);
        Console.WriteLine($"Resultado: {num1} {operatoreMatematico(operazione)} {num2} = {risultato:N2}");
    }
    catch (DivideByZeroException)
    {
        Console.WriteLine("Número no válido. Por favor, ingrese un número mayor a 0");
        double divisore = LeggereDivisore();
        double risultato = EseguireOperazione(num1, divisore, operazione);
        Console.WriteLine($"Resultado: {num1} {operatoreMatematico(operazione)} {divisore} = {risultato:N2}");
    }
    catch (ArgumentException)
    {
        Console.WriteLine("Un error inesperado ha sucedido");
    }
}

static double LeggereDivisore()
{
    double divisore = LeggereNumero("Ingrese el segundo número: ");
    if (divisore == 0)
    {
        return LeggereDivisore();
    }

    return divisore;

}

double EseguireOperazione(double num1, double num2, int operazione)
{
    switch (operazione)
    {
        case 1:
            return num1 + num2;
        case 2:
            return num1 - num2;
        case 3:
            return num1 * num2;
        case 4:
            return Dividere(num1, num2);
        default:
            throw new ArgumentException();
    }
}

static string operatoreMatematico(int operazione)
{
    switch (operazione)
    {
        case 1:
            return "+";
        case 2:
            return "-";
        case 3:
            return "*";
        case 4:
            return "/";
        default:
            throw new ArgumentException();
    }
}


static double Dividere(double dividendo, double divisore)
{
    if (divisore == 0)
    {
        throw new DivideByZeroException();
    }

    return dividendo / divisore;
}

static double LeggereNumero(string messaggio)
{
    Console.Write(messaggio);

    string? valoreLetto = Console.ReadLine();

    if (double.TryParse(valoreLetto, out double numero))
    {
        return numero;
    }

    Console.WriteLine("Entrada no válida. Por favor, ingrese un número.");
    return LeggereNumero(messaggio);
}