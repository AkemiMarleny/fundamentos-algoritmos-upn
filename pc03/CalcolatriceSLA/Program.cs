void Main()
{
    // Pruebas de ejecución
    CalcolaOraLavorativa(new DateTime(2026, 6, 01, 08, 00, 0), new DateTime(2026, 6, 01, 16, 00, 0));
    Console.WriteLine("------");
    CalcolaOraLavorativa(new DateTime(2026, 6, 01, 08, 00, 0), new DateTime(2026, 6, 02, 16, 00, 0));
    Console.WriteLine("------");
    CalcolaOraLavorativa(new DateTime(2026, 6, 26, 17, 00, 0), new DateTime(2026, 6, 30, 17, 00, 0));
    Console.WriteLine("------");
    CalcolaOraLavorativa(new DateTime(2026, 7, 1, 22, 00, 0), new DateTime(2026, 8, 1, 13, 00, 0));
    Console.WriteLine("------");
    CalcolaOraLavorativa(new DateTime(2026, 6, 25, 09, 15, 0), new DateTime(2026, 6, 25, 16, 45, 0));
}

void CalcolaOraLavorativa(DateTime dataCreazione, DateTime dataRisoluzione)
{
    if (dataCreazione >= dataRisoluzione)
    {
        Console.WriteLine("[Error]: La fecha de creación debe ser anterior a la de resolución.");
        return;
    }

    Console.WriteLine($"[INFO] Calculando desde {dataCreazione:yyyy-MM-dd HH:mm} hasta {dataRisoluzione:yyyy-MM-dd HH:mm}");

    double oreLavorativeTotali = 0;
    DateTime giornoAttuale = dataCreazione.Date;

    while (giornoAttuale <= dataRisoluzione.Date)
    {
        if (giornoAttuale.DayOfWeek == DayOfWeek.Saturday || giornoAttuale.DayOfWeek == DayOfWeek.Sunday)
        {
            giornoAttuale = giornoAttuale.AddDays(1);
            continue;
        }

        DateTime inizioOrarioLavorativo = giornoAttuale.AddHours(9);
        DateTime fineOrarioLavorativo = giornoAttuale.AddHours(17);

        DateTime inizioEffettivo = (dataCreazione > inizioOrarioLavorativo) ? dataCreazione : inizioOrarioLavorativo;
        DateTime fineEffettivo = (dataRisoluzione < fineOrarioLavorativo) ? dataRisoluzione : fineOrarioLavorativo;

        if (inizioEffettivo < fineEffettivo)
        {
            TimeSpan lapso = fineEffettivo - inizioEffettivo;
            oreLavorativeTotali += lapso.TotalHours;
        }

        giornoAttuale = giornoAttuale.AddDays(1);
    }

    Console.WriteLine($"[INFO] Horas laborables acumuladas: {oreLavorativeTotali:F2}");

    if (oreLavorativeTotali <= 8)
    {
        Console.WriteLine("[INFO] Estado: [CUMPLIDO]");
    }
    else
    {
        double exceso = oreLavorativeTotali - 8;
        Console.WriteLine($"[INFO] Estado: [INCUMPLIDO] - Exceso de {exceso:F2} horas");
    }
}

Main();