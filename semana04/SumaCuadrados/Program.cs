

using System.ComponentModel;

void Main()
{

    int numero = 0;
    do
    {
        Console.Write("Ingresa un número: ");
        string? input = Console.ReadLine();
        if (int.TryParse(input, out numero) && numero <= 0)
        {
            Console.WriteLine("El valor ingresado, no está permitido");
        }
    }
    while (numero <= 0);

    int somma = 0;
    for (int i = 1; i <= numero; i++)
    {
        int quadrato = i * i;
        somma += quadrato;
        if (i == 1)
        {
            Console.Write($"S = {i}*{i} ");
        }
        else
        {

            Console.Write($"+ {i}*{i} ");
        }
    }

    Console.WriteLine($"\nLa suma total de la serie es {somma}");
}

Main();