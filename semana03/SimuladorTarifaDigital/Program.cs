using Tariffa;


Main();

void Main()
{

    Console.WriteLine("=== CONFIGURACIÓN DE VIAJE INDRIVE ===");

    Console.Write("1. Ingrese el nombre del pasajero: ");
    string nomePasseggero = Console.ReadLine();

    Console.Write("2. Ingrese la distancia del viaje en km: ");
    double distanza = Convert.ToDouble(Console.ReadLine());

    Console.Write("3. Ingrese la hora de salida (0 - 23): ");
    int orarioPartenza = Convert.ToInt32(Console.ReadLine());

    Console.Write("4. Ingrese el tipo de vehículo (1: Económico, 2: Confort, 3: Premium, 4: Moto): ");
    int tipoVeicolo = Convert.ToInt32(Console.ReadLine());

    if (tipoVeicolo < 1 || tipoVeicolo > 4)
    {
        Console.WriteLine("Opción no válida. Por favor, seleccione una opción del 1 al 4.");
        return;
    }

    TariffaVeicolo veicolo = risolveTipoVeicolo(tipoVeicolo);

    Console.WriteLine("\n=======================================");
    Console.WriteLine("          RESUMEN DEL VIAJE            ");
    Console.WriteLine("=======================================");
    Console.WriteLine($"Pasajero:           {nomePasseggero}");
    Console.WriteLine($"Vehículo elegido:   {veicolo.TipoVeicolo}");
    Console.WriteLine($"Distancia:          {distanza} km");
    Console.WriteLine($"Hora de salida:     {orarioPartenza}:00 hrs");
    Console.WriteLine("---------------------------------------");
    Console.WriteLine($"TARIFA FINAL:       S/ {veicolo.Tariffa:F2}");
    Console.WriteLine("=======================================");


}

TariffaVeicolo risolveTipoVeicolo(int tipoVeicolo)
{
    switch (tipoVeicolo)
    {
        case 1:
            return new Economico();
        case 2:
            return new Confort();
        case 3:
            return new Premium();
        case 4:
            return new Moto();
        default:
            return new Economico();
    }
}



namespace Tariffa
{

    interface ITariffaVeicolo
    {
        double Tariffa(double distanza, int orarioPartenza);
    }

    abstract class TariffaVeicolo
    {
        public abstract string TipoVeicolo { get; }
        public abstract double TariffaBase { get; }
        public abstract double CostoKm { get; }

        public double Tariffa(double distanza, int orarioPartenza)
        {
            double sottoTotale = TariffaBase + (CostoKm * distanza);

            // REGLA 2: Hora pico (+30%)
            if ((orarioPartenza >= 7 && orarioPartenza <= 9) || (orarioPartenza >= 17 && orarioPartenza <= 20))
            {
                sottoTotale = sottoTotale * 1.30;
            }

            // REGLA 3: Descuento distancia larga 
            if (distanza > 15)
            {
                sottoTotale = sottoTotale * 0.95;
            }

            // REGLA 4: Tarifa mínima
            double tariffaFinale = Math.Max(sottoTotale, 5.00);

            // REGLA 5: Redondeo
            tariffaFinale = Math.Round(tariffaFinale, 2);

            return tariffaFinale;
        }
    }


    class Economico : TariffaVeicolo, ITariffaVeicolo
    {
        public override string TipoVeicolo { get; } = "Económico";
        public override double TariffaBase { get; } = 2.00;
        public override double CostoKm { get; } = 1.50;
    }

    class Confort : TariffaVeicolo, ITariffaVeicolo
    {
        public override string TipoVeicolo { get; } = "Confort";
        public override double TariffaBase { get; } = 3.00;
        public override double CostoKm { get; } = 2.00;
    }

    class Premium : TariffaVeicolo, ITariffaVeicolo
    {
        public override string TipoVeicolo { get; } = "Premium";
        public override double TariffaBase { get; } = 5.00;
        public override double CostoKm { get; } = 3.00;

    }

    class Moto : TariffaVeicolo, ITariffaVeicolo
    {
        public override string TipoVeicolo { get; } = "Moto";
        public override double TariffaBase { get; } = 1.50;
        public override double CostoKm { get; } = 1.00;

    }


}


