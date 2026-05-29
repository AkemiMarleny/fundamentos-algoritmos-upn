using System;

// --- Metodi ---

double CalcolareImc(double peso, double altezza)
{
    return peso / (altezza * altezza);
}

// Pattern Matching
void Diagnosi(double imc)
{
    switch (imc)
    {
        case double valor when (valor < 18.5):
            Console.WriteLine("Bajo peso");
            break;

        case double valor when (valor >= 18.5 && valor < 25.0):
            Console.WriteLine("Peso normal");
            break;

        case double valor when (valor >= 25.0 && valor < 30.0):
            Console.WriteLine("Sobrepeso");
            break;

        default:
            Console.WriteLine("Obesidad");
            break;
    }
}

double ValidareInput(string messaggio)
{
    Console.Write(messaggio);
    string? valoreLetto = Console.ReadLine();

    if (double.TryParse(valoreLetto, out double valore) && valore > 0)
    {
        return valore;
    }

    Console.WriteLine("Entrada inválida. Por favor, ingrese un valor válido");
    return ValidareInput(messaggio);
}

// --- Flusso Principale ---

Console.WriteLine("CALCULADORA DE IMC CON DIAGNÓSTICO");

double peso = ValidareInput("Ingrese su peso en kg: ");
double altezza = ValidareInput("Ingrese su altura en metros: ");

double imc = CalcolareImc(peso, altezza);

Console.WriteLine($"\nTu IMC es: {imc:F2}");
Diagnosi(imc);