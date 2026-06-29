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

        double tarifaBase = 0;
        double costokm = 0;
        string nombreVehiculo = "";

        switch (tipoVehiculo)
        {
            case 1:
                nombreVehiculo = "Económico";
                tarifaBase = 2.00;
                costokm = 1.50;
                break;
            case 2:
                nombreVehiculo = "Confort";
                tarifaBase = 3.00;
                costokm = 2.00;
                break;
            case 3:
                nombreVehiculo = "Premium";
                tarifaBase = 5.00;
                costokm = 3.00;
                break;
            case 4:
                nombreVehiculo = "Moto";
                tarifaBase = 1.50;
                costokm = 1.00;
                break;
            default:
                Console.WriteLine("\nOpción no válida. Fin del programa.");
                return;
        }

        double subtotal = tarifaBase + (costokm * distancia);
        bool esHoraPico = false;

        esHoraPico = EsHoraPico(hora);
        if (esHoraPico)
        {
            subtotal = subtotal * 1.30;
        }

        double descuento = 0;
        if (distancia > 15)
        {
            descuento = subtotal * 0.05;
            subtotal = subtotal - descuento;
        }

        double tarifaFinal = Math.Max(subtotal, 5.00);
        tarifaFinal = Math.Round(tarifaFinal, 2);

        Console.WriteLine($"\nTARIFA FINAL: S/ {tarifaFinal}");
    }

    static bool EsHoraPico(int hora)
    {
        return (hora >= 7 && hora <= 9) || (hora >= 17 && hora <= 20);
    }
}