
void Main()
{
    bool valido = ValidaRicevutaElettronica("A121-32121");
    Console.WriteLine($"es valido: {valido}");
    Console.WriteLine($"----");


    bool valido2 = ValidaRicevutaElettronica("B123-00032123");
    Console.WriteLine($"es valido: {valido2}");
    Console.WriteLine($"----");

    bool valido3 = ValidaRicevutaElettronica("B1234-0032123");
    Console.WriteLine($"es valido: {valido3}");
    Console.WriteLine($"----");

    bool valido4 = ValidaRicevutaElettronica("B123-0003212A");
    Console.WriteLine($"es valido: {valido4}");
    Console.WriteLine($"----");
}

bool isBoletaOrFactura(char carattere)
{
    if (carattere.Equals('B') || carattere.Equals('F'))
    {
        return true;
    }

    return false;
}

bool IsTrattino(char carattere)
{
    if (carattere.Equals('-'))
    {
        return true;
    }

    return false;
}

bool ValidaRicevutaElettronica(string codice)
{
    Console.WriteLine($"[INFO] Validando código: {codice}");

    char[] charCodice = codice.ToCharArray();
    Console.WriteLine($"[INFO] Validando longitud: {charCodice.Length}");
    if (charCodice.Length != 13)
    {
        Console.WriteLine($"[ERR] La longitud del código es incorrecta (debe ser de 13 caracteres)");
        return false;
    }


    for (int i = 0; i < charCodice.Length; i++)
    {

        if (i == 0)
        {
            char primoCarattere = charCodice[0];
            Console.WriteLine($"[INFO] Validando primer caracter: {primoCarattere}");
            if (!isBoletaOrFactura(primoCarattere))
            {
                Console.WriteLine($"[ERR] Primer caracter no válido");
                return false;
            }
        }

        else if (i == 4)
        {
            char trattinoCarattere = charCodice[4];
            Console.WriteLine($"[INFO] Validando caracter \"-\" en posición 5: {trattinoCarattere}");
            if (!IsTrattino(trattinoCarattere))
            {
                Console.WriteLine($"[ERR] Ubicación del caracter \"-\" no válida");
                return false;
            }
        }

        else
        {
            char digito = charCodice[i];
            Console.WriteLine($"[INFO] Validando dígito: {digito}");
            if (!char.IsDigit(digito))
            {
                Console.WriteLine($"[ERR] No es un dígito: {digito}");
                return false;
            }
        }

    }

    return true;
}

Main();
