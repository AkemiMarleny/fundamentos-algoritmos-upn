void Main()
{
    int opcionSeleccionada = SolicitarOpcion();
    switch (opcionSeleccionada)
    {
        case 0:
            SalirPrograma();
            break;
        case 1:
            RegistrarProducto();
            break;
        case 2:
            MostrarCatalogoProductos();
            break;
        case 3:
            BuscarProductoPorCodigo();
            break;
        case 4:
            ActualizarStockProducto();
            break;
        case 5:
            OrdenarCatalogoPrecio();
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
}

void DemostracionParametroValorReferencia() { }

void OrdernarCatalogoPorNombreAlfabetico() { }

void EliminarProductoPorCodigo() { }

void InsertarProductoEnPosicion() { }

void OrdenarCatalogoPrecio() { }

void ActualizarStockProducto() { }

void BuscarProductoPorCodigo() { }

void MostrarCatalogoProductos()
{
    // TODO 
}

void RegistrarProducto()
{
    // TODO
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