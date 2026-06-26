using System;

int n = 0;

do
{
    Console.Write("Ingrese un valor: ");
    string? input = Console.ReadLine();
    if (int.TryParse(input, out n) && n <= 0)
    {
        Console.WriteLine("Valor inválido. Debe ingresar un número entero mayor que 0.");
    }

} while (n <= 0);

int a = 0;
int b = 1;
int somma = a;

Console.Write($"S = {a}");

while (b <= n)
{
    Console.Write($" + {b}");
    somma += b;

    int seguente = a + b;
    a = b;
    b = seguente;
}

Console.WriteLine($"\nEl valor total de la serie hasta n={n} es: {somma}");

