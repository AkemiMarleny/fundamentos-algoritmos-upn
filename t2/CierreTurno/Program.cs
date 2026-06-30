using System;

class SimuladorTarifa
{
    static void Main(string[] args)
    {
        Console.WriteLine("=========================================");
        Console.WriteLine("          InDrive Simulador de Tarifa    ");
        Console.WriteLine("=========================================\n");

        Console.Write("Nombre del pasajero: ");
        string nombre = Console.ReadLine();

        Console.Write("Distancia del viaje (km): ");
        double distancia = double.Parse(Console.ReadLine());

        Console.Write("Hora de salida (0-23): ");
        int hora = int.Parse(Console.ReadLine());

        Console.WriteLine("\nTipo de vehículo:");
        Console.WriteLine("1. Económico");
        Console.WriteLine("2. Confort");
        Console.WriteLine("3. Premium");
        Console.WriteLine("4. Moto");

        Console.Write("Seleccione opción: ");
        int tipoVehiculo = int.Parse(Console.ReadLine());

        double tarifaFinal = CalcularTarifa(distancia, hora, tipoVehiculo);

        if (tarifaFinal < 0)
        {
            Console.WriteLine("\nOpción no válida. Fin del programa.");
            return;
        }
        Console.WriteLine($"\nTARIFA FINAL: S/ {tarifaFinal}");
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
}