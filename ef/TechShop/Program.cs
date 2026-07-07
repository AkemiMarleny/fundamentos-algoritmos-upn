void Main()
{
    int maxProductos = 20;

    string[] codigos = new string[maxProductos];
    string[] nombres = new string[maxProductos];
    double[] precios = new double[maxProductos];
    int[] stocks = new int[maxProductos];
    int cantidadProductos = 0;


    int opcionSeleccionada = 0;
    do
    {
        opcionSeleccionada = SolicitarOpcion();
        switch (opcionSeleccionada)
        {
            case 0:
                SalirPrograma();
                break;
            case 1:
                RegistrarProducto(ref codigos, ref nombres, ref precios, ref stocks, ref cantidadProductos);
                break;
            case 2:
                MostrarCatalogoProductos(ref codigos, ref nombres, ref precios, ref stocks, ref cantidadProductos);
                break;
            case 3:
                BuscarProductoPorCodigo(ref codigos, ref nombres, ref precios, ref stocks);
                break;
            case 4:
                ActualizarStockProducto(ref codigos, ref stocks);
                break;
            case 5:
                OrdenarCatalogoPrecio(ref codigos, ref nombres, ref precios, ref stocks, ref cantidadProductos);
                break;
            case 6:
                InsertarProductoEnPosicion();
                break;
            case 7:
                EliminarProductoPorCodigo();
                break;
            case 8:
                OrdernarCatalogoPorNombreAlfabetico();
                break;
            case 9:
                DemostracionParametroValorReferencia();
                break;
        }
    } while (opcionSeleccionada != 0);
}

void DemostracionParametroValorReferencia() { }

void OrdernarCatalogoPorNombreAlfabetico() { }

void EliminarProductoPorCodigo() { }

void InsertarProductoEnPosicion() { }

void OrdenarCatalogoPrecio(ref string[] codigos, ref string[] nombres, ref double[] precios, ref int[] stocks, ref int cantidadProductos)
{
    Console.WriteLine("ORDENAR CATÁLOGO POR PRECIO");

    if (cantidadProductos == 0)
    {
        Console.WriteLine("El catálogo está vacío. No hay productos que ordenar.");
        return;
    }

    for (int i = 0; i < cantidadProductos - 1; i++)
    {
        for (int j = 0; j < cantidadProductos - 1 - i; j++)
        {
            if (precios[j] > precios[j + 1])
            {
                double tempPrecio = precios[j];
                precios[j] = precios[j + 1];
                precios[j + 1] = tempPrecio;

                string tempCodigo = codigos[j];
                codigos[j] = codigos[j + 1];
                codigos[j + 1] = tempCodigo;

                string tempNombre = nombres[j];
                nombres[j] = nombres[j + 1];
                nombres[j + 1] = tempNombre;

                int tempStock = stocks[j];
                stocks[j] = stocks[j + 1];
                stocks[j + 1] = tempStock;
            }
        }
    }

    Console.WriteLine("Catálogo ordenado por precio de menor a mayor.");
}

void ActualizarStockProducto(ref string[] codigos, ref int[] stocks)
{
    Console.WriteLine("ACTUALIZAR STOCK");

    string codigo = LeerCodigo();
    int indiceProducto = BuscarIndicePorCodigo(codigo, ref codigos);
    if (indiceProducto == -1)
    {
        Console.WriteLine("Error: Producto con código no encontrado");
        return;
    }

    Console.WriteLine("Ingrese la cantidad a actualizar (positivo para sumar, negativo para restar): ");
    int cantidad = 0;
    if (!int.TryParse(Console.ReadLine(), out cantidad))
    {
        Console.WriteLine("Error: Cantidad no válida");
        return;
    }

    int nuevoStock = stocks[indiceProducto] + cantidad;
    if (nuevoStock < 0)
    {
        Console.WriteLine("Error: El nuevo stock no puede quedar negativo. Operación rechazada.");
    }
    else
    {
        stocks[indiceProducto] = nuevoStock;
        Console.WriteLine("Stock actualizado satisfactoriamente");
    }
}

void BuscarProductoPorCodigo(ref string[] codigos, ref string[] nombres, ref double[] precios, ref int[] stocks)
{
    Console.WriteLine("BUSCAR PRODUCTO POR CÓDIGO");

    string codigo = LeerCodigo();
    int indiceProducto = BuscarIndicePorCodigo(codigo, ref codigos);
    if (indiceProducto == -1)
    {
        Console.WriteLine("Error: Producto con código no encontrado");
    }
    else
    {
        MostrarProductoEnLinea(indiceProducto, ref codigos, ref nombres, ref precios, ref stocks);
    }
}

void MostrarCatalogoProductos(ref string[] codigos, ref string[] nombres, ref double[] precios, ref int[] stocks, ref int cantidadProductos)
{
    Console.WriteLine("CATÁLOGO DE PRODUCTOS");

    for (int i = 0; i < cantidadProductos; i++)
    {
        MostrarProductoEnLinea(i, ref codigos, ref nombres, ref precios, ref stocks);
    }
}

void MostrarProductoEnLinea(int indiceProducto, ref string[] codigos, ref string[] nombres, ref double[] precios, ref int[] stocks)
{
    Console.WriteLine($"{indiceProducto}  Codigo: {codigos[indiceProducto]}  |  Nombre: {nombres[indiceProducto]}  |  Precio: {precios[indiceProducto]}  |  Stock: {stocks[indiceProducto]}");

}

void RegistrarProducto(ref string[] codigos, ref string[] nombres, ref double[] precios, ref int[] stocks, ref int cantidadProductos)
{
    Console.WriteLine("REGISTRAR PRODUCTO");

    string codigo = LeerCodigoNoExistente(ref codigos);
    string nombre = LeerNombre();
    double precio = LeerPrecio();
    int stock = LeerStockInicial();

    codigos[cantidadProductos] = codigo;
    nombres[cantidadProductos] = nombre;
    precios[cantidadProductos] = precio;
    stocks[cantidadProductos] = stock;

    cantidadProductos++;

    Console.WriteLine("Producto registrado satisfactoriamente");
}


int LeerStockInicial()
{
    int stock = 0;
    bool stockValido = false;
    do
    {
        Console.WriteLine("Ingrese stock: ");
        if (!int.TryParse(Console.ReadLine(), out stock))
        {
            Console.WriteLine("Error: Stock no válido");
            stockValido = false;
        }
        else if (stock < 0)
        {
            Console.WriteLine("Error: Stock debería ser mayor que cero");
            stockValido = false;
        }
        else
        {
            stockValido = true;
        }
    }
    while (stockValido == false);

    return stock;
}


double LeerPrecio()
{
    double precio = 0.0;
    bool precioValido = false;
    do
    {
        Console.WriteLine("Ingrese precio: ");
        if (!double.TryParse(Console.ReadLine(), out precio))
        {
            Console.WriteLine("Error: Precio no válido");
            precioValido = false;
        }
        else if (precio <= 0)
        {
            Console.WriteLine("Error: Precio deberia ser mayor que cero");
            precioValido = false;
        }
        else
        {
            precioValido = true;
        }
    }
    while (precioValido == false);

    return precio;
}


string LeerNombre()
{
    string nombre = "";
    bool nombreValido = false;
    do
    {
        Console.WriteLine("Ingrese nombre: ");
        nombre = Console.ReadLine().Trim();
        if (string.IsNullOrEmpty(nombre))
        {
            Console.WriteLine("Error: Nombre no deberia estar vacio");
            nombreValido = false;
        }
        else
        {
            nombreValido = true;
        }
    }
    while (nombreValido == false);

    return nombre;
}

string LeerCodigoNoExistente(ref string[] codigos)
{
    string codigo = "";
    bool codigoValido = false;
    do
    {
        Console.WriteLine("Ingrese código: ");
        codigo = Console.ReadLine().Trim();
        if (string.IsNullOrEmpty(codigo))
        {
            Console.WriteLine("Error: Código no deberia estar vacio");
            codigoValido = false;
        }
        else if (BuscarIndicePorCodigo(codigo, ref codigos) != -1)
        {
            Console.WriteLine("Error: El código ya existe.");
        }
        else
        {
            codigoValido = true;
        }
    }
    while (codigoValido == false);

    return codigo;
}


string LeerCodigo()
{
    string codigo = "";
    bool codigoValido = false;
    do
    {
        Console.WriteLine("Ingrese código: ");
        codigo = Console.ReadLine().Trim();
        if (string.IsNullOrEmpty(codigo))
        {
            Console.WriteLine("Error: Código no deberia estar vacio");
            codigoValido = false;
        }
        else
        {
            codigoValido = true;
        }
    }
    while (codigoValido == false);

    return codigo;
}


int BuscarIndicePorCodigo(string codigo, ref string[] codigos)
{
    for (int i = 0; i < codigos.Length; i++)
    {
        string codigoVal = codigos[i];
        if (codigoVal is null)
        {
            continue;
        }

        if (codigoVal.Equals(codigo, StringComparison.OrdinalIgnoreCase))
        {
            return i;
        }
    }

    return -1;
}

void SalirPrograma()
{
    // TODO
}

int SolicitarOpcion()
{
    int opcionSeleccionada = 0;
    bool opcionValida = false;
    do
    {
        MostrarMenu();
        Console.Write("Seleccione una opción del menú: ");

        if (!int.TryParse(Console.ReadLine(), out opcionSeleccionada))
        {
            opcionValida = false;
        }
        else if (opcionSeleccionada >= 0 && opcionSeleccionada <= 9)
        {
            opcionValida = true;
        }

    } while (opcionValida == false);

    return opcionSeleccionada;
}

void MostrarMenu()
{
    Console.WriteLine("TECH SHOP - Funcionalidades");
    Console.WriteLine(" 1. Registrar un producto");
    Console.WriteLine(" 2. Mostrar el catálogo completo");
    Console.WriteLine(" 3. Buscar un producto por código");
    Console.WriteLine(" 4. Actualizar el stock (sumar o restar)");
    Console.WriteLine(" 5. Ordenar el catálogo por precio (Burbuja)");
    Console.WriteLine(" 6. Insertar un producto en una posición específica");
    Console.WriteLine(" 7. Eliminar un producto por código");
    Console.WriteLine(" 8. Ordenar el catálogo por nombre (Alfabético)");
    Console.WriteLine(" 9. Demostración: parámetro por valor vs. por referencia");
    Console.WriteLine(" 0. Salir del programa");
}

// { }

Main();