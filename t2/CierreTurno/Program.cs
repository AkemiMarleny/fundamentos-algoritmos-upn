using System;

class SimuladorTarifa
{
    static void Main(string[] args)
    {
        Console.WriteLine("=========================================");
        Console.WriteLine("          InDrive Simulador de Tarifa    ");
        Console.WriteLine("=========================================\n");

        Console.Write("Cantidad de viajes del conductor: ");
        int n = int.Parse(Console.ReadLine());

        double[] tarifas = new double[n];
        bool[] picoHora = new bool[n];

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\n--- Viaje #{i + 1} ---");

            string nombre;
            double distancia;
            int hora, tipoVehiculo;
            bool valido;

            do
            {
                Console.Write("Nombre del pasajero: ");
                nombre = Console.ReadLine();

                Console.Write("Distancia del viaje (km): ");
                distancia = double.Parse(Console.ReadLine());

                Console.Write("Hora de salida (0-23): ");
                hora = int.Parse(Console.ReadLine());

                Console.Write("Tipo de vehículo (1-4): ");
                tipoVehiculo = int.Parse(Console.ReadLine());

                valido = EsValido(distancia, hora, tipoVehiculo);
                if (!valido)
                {
                    Console.WriteLine("Datos inválidos. Intente nuevamente.");
                }
            } while (!valido);

            picoHora[i] = EsHoraPico(hora);
            tarifas[i] = CalcularTarifa(distancia, hora, tipoVehiculo);
            Console.WriteLine($"TARIFA: S/ {tarifas[i]:F2}");
        }

        Console.WriteLine("\n========== RESUMEN DEL DÍA ==========");
        Console.WriteLine($"Viajes realizados:    {n}");
        Console.WriteLine($"Total ganado:         S/ {CalcularTotal(tarifas):F2}");
        Console.WriteLine($"Tarifa promedio:      S/ {CalcularPromedio(tarifas):F2}");
        Console.WriteLine($"Viaje más rentable:   S/ {EncontrarMaximo(tarifas):F2}");
        Console.WriteLine($"Viaje más económico:  S/ {EncontrarMinimo(tarifas):F2}");
        Console.WriteLine($"Viajes en hora pico:  {ContarHoraPico(picoHora)}");
    }

    static bool EsHoraPico(int hora)
    {
        return (hora >= 7 && hora <= 9) || (hora >= 17 && hora <= 20);
    }

    static double CalcularTarifa(double distancia, int hora, int tipoVehiculo)
    {
        double tarifaBase = 0;
        double costokm = 0;

        switch (tipoVehiculo)
        {
            case 1:
                tarifaBase = 2.00;
                costokm = 1.50;
                break;
            case 2:
                tarifaBase = 3.00;
                costokm = 2.00;
                break;
            case 3:
                tarifaBase = 5.00;
                costokm = 3.00;
                break;
            case 4:
                tarifaBase = 1.50;
                costokm = 1.00;
                break;
            default:
                return -1;
        }

        double subtotal = tarifaBase + costokm * distancia;

        if (EsHoraPico(hora))
        {
            subtotal *= 1.30;
        }

        if (distancia > 15)
        {
            subtotal -= subtotal * 0.05;
        }

        return Math.Round(Math.Max(subtotal, 5.00), 2);
    }

    static bool EsValido(double distancia, int hora, int tipoVehiculo)
    {
        return distancia > 0
            && hora >= 0 && hora <= 23
            && tipoVehiculo >= 1 && tipoVehiculo <= 4;
    }

    static double CalcularTotal(double[] tarifas)
    {
        double suma = 0;
        for (int i = 0; i < tarifas.Length; i++)
        {
            suma += tarifas[i];
        }
        return suma;
    }

    static double CalcularPromedio(double[] tarifas)
    {
        return CalcularTotal(tarifas) / tarifas.Length;
    }

    static double EncontrarMaximo(double[] tarifas)
    {
        double max = tarifas[0];
        for (int i = 1; i < tarifas.Length; i++)
        {
            if (tarifas[i] > max)
            {
                max = tarifas[i];
            }
        }
        return max;
    }

    static double EncontrarMinimo(double[] tarifas)
    {
        double min = tarifas[0];
        for (int i = 1; i < tarifas.Length; i++)
        {
            if (tarifas[i] < min)
            {
                min = tarifas[i];
            }
        }
        return min;
    }

    static int ContarHoraPico(bool[] picoHora)
    {
        int count = 0;
        for (int i = 0; i < picoHora.Length; i++)
        {
            if (picoHora[i])
            {
                count++;
            }
        }
        return count;
    }
}