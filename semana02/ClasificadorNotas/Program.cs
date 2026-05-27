using System;

Console.WriteLine("CLASIFICADOR DE NOTAS");
        Console.Write("Ingrese la nota del estudiante: ");
        string input = Console.ReadLine();
        if (double.TryParse(input, out double voto))
        {
            ClasificarNota(voto);
        }
        else
        {
            Console.WriteLine("Entrada no válida. Ingrese un número.");
        }

        static void ClasificarNota(double voto)
    {
        
        if (voto < 0 || voto > 20)
        {
            Console.WriteLine("Error: La calificación debe estar comprendida entre 0 y 20.");
        }
        else if (voto == 20)
        {
            Console.WriteLine("Excelente");
        }
        else if (voto >= 11)
        {
            Console.WriteLine("Aprobado");
        }
        else
        {
            Console.WriteLine("Desaprobado");
        }
    }

