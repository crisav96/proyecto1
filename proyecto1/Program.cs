using System.Globalization;
class Program
{
    static int[] numeroPago = new int[10];
    static DateTime[] fecha = new DateTime[10];
    static TimeSpan[] hora = new TimeSpan[10];
    static string[] cedula = new string[10];
    static string[] nombre = new string[10];
    static string[] apellido1 = new string[10];
    static string[] apellido2 = new string[10];
    static int[] numeroCaja = new int[10];
    static int[] tipoServicio = new int[10];
    static string[] numeroFactura = new string[10];
    static decimal[] montoPagar = new decimal[10];
    static decimal[] montoComision = new decimal[10];
    static decimal[] montoDeducido = new decimal[10];
    static decimal[] montoPagaCliente = new decimal[10];
    static decimal[] vuelto = new decimal[10];
    static bool[] pagoEliminado = new bool[10];
    static int indice = 0;
    static void Main()
    {
        int opcion;
        do
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("                    Menú Principal");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("-------------------Tienda el milagro---------------  ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1. Inicializar Vectores");
            Console.WriteLine("2. Realizar Pagos");
            Console.WriteLine("3. Consultar Pagos");
            Console.WriteLine("4. Modificar Pagos");
            Console.WriteLine("5. Eliminar Pagos");
            Console.WriteLine("6. Submenú Reportes");
            Console.WriteLine("7. Salir"); ;
            Console.Write("Ingrese la opción deseada: ");
            if (int.TryParse(Console.ReadLine(), out opcion))
            {
                {
                    switch (opcion)
                    {
                        case 1:
                            InicializarVectores();
                            break;
                        case 2:
                            RealizarPagos();
                            break;
                        case 3:
                            ConsultarPagos();
                            break;
                        case 4:
                            ModificarPagos();
                            break;
                        case 5:
                            EliminarPagos();
                            break;
                        case 6:
                            SubmenuReportes();
                            break;
                        case 7:
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("Saliendo del programa. ¡Hasta pronto!");
                            break;

                        default:
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write("Opción no válida. Por favor, ingrese un número del 1 al 7.Precione ENTER para continuar");
                            Console.ReadKey();
                            break;
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Por favor, ingrese un número válido.Precione ENTER para continuar");
                Console.ReadKey();
            }
        } while (opcion != 7);
    }
    static void InicializarVectores()

    {
        for (int i = 0; i < 10; i++)
        {
            numeroPago[i] = -1; // Usar -1 para indicar que el pago no está registrado
            fecha[i] = DateTime.MinValue;
            hora[i] = TimeSpan.MinValue;
            cedula[i] = "";
            nombre[i] = "";
            apellido1[i] = "";
            apellido2[i] = "";
            numeroCaja[i] = 0;
            tipoServicio[i] = 0;
            numeroFactura[i] = "";
            montoPagar[i] = 0;
            montoComision[i] = 0;
            montoDeducido[i] = 0;
            montoPagaCliente[i] = 0;
            vuelto[i] = 0;
            pagoEliminado[i] = false; // Inicializar todos los pagos como no eliminados
        }
        indice = 0;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Vectores iniciados correctamente. Digite ENTER para continuar.");
        Console.ReadKey();
        Console.Clear();
    }
    static void RealizarPagos()
    {
        for (int i = 0; i < 10; i++)
            if (indice >= 10)
            {
                Console.WriteLine("Vectores Llenos");
                return;
            }

        Random rnd = new Random();

        while (true)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear(); // Limpiar la ventana  
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("                Ingrese los datos del pago          ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("-------------------Tienda el milagro---------------  ");

            numeroPago[indice] = indice + 1; // Auto numérico asignado por el sistema
            Console.WriteLine($"Ingresando datos para el pago número {numeroPago[indice]}");

                      //Ingresar Fecha
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Fecha (dd/mm/aaaa): ");
                string fechaInput = Console.ReadLine(); ;
                if (DateTime.TryParseExact(fechaInput, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fechaPago))
                {
                    fecha[indice] = fechaPago;
                    break;
                }
                else
                {

                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Formato de fecha incorrecto. Intente nuevamente.");
                    Console.WriteLine("Precione ENTER para continuar.");
                    Console.ReadKey();
                }
            } while (true);

            // Ingresar Hora
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Hora (hh:mm): ");
                string horaInput = Console.ReadLine();

                if (TimeSpan.TryParseExact(horaInput, "hh\\:mm", CultureInfo.InvariantCulture, out TimeSpan horaPago))
                {
                    hora[indice] = horaPago;
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Formato de hora incorrecto. Intente nuevamente.");
                    Console.WriteLine("Precione ENTER para continuar.");
                    Console.ReadKey();
                }
            } while (true);

            // Ingresar Cédula
            Console.Write("Cédula: ");
            cedula[indice] = Console.ReadLine();

            // Ingresar Nombre
            Console.Write("Nombre: ");
            nombre[indice] = Console.ReadLine();

            // Ingresar Apellido1
            Console.Write("Apellido1: ");
            apellido1[indice] = Console.ReadLine();

            // Ingresar Apellido2
            Console.Write("Apellido2: ");
            apellido2[indice] = Console.ReadLine();

            // Generar número de caja aleatorio entre 1 y 3
            numeroCaja[indice] = rnd.Next(1, 4);

            // Ingresar Tipo de Servicio
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Tipo de Servicio (1=Recibo de Luz, 2=Recibo de Teléfono, 3=Recibo de Agua): ");
                if (int.TryParse(Console.ReadLine(), out int tipo))
                {
                    if (tipo >= 1 && tipo <= 3)
                    {
                        tipoServicio[indice] = tipo;
                        break; 
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Tipo de Servicio no válido. Debe ser 1, 2 o 3.");
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Tipo de Servicio no válido. Debe ser 1, 2 o 3.");
                }

                Console.WriteLine("Presione ENTER para continuar.");
                Console.ReadKey();
            } while (true);

            // Ingresar Número de Factura
            Console.Write("Número de Factura: ");
            numeroFactura[indice] = Console.ReadLine();

            // Ingresar Monto a Pagar
            Console.Write("Monto a Pagar: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal montoPagarInput))
            {
                montoPagar[indice] = montoPagarInput;
            }
            else
            {
                Console.WriteLine("Formato de monto incorrecto. Intente nuevamente.");
                continue;
            }

            // Ingresar Monto de Comisión
            decimal montoComisionInput = 0;
            switch (tipoServicio[indice])
            {
                case 1: // Recibo de Luz
                    montoComisionInput = montoPagar[indice] * 0.04m; // 4% de comisión
                    break;
                case 2: // Recibo Telefónico
                    montoComisionInput = montoPagar[indice] * 0.055m; // 5.5% de comisión
                    break;
                case 3: // Recibo de Agua
                    montoComisionInput = montoPagar[indice] * 0.065m; // 6.5% de comisión
                    break;
                default:
                    Console.WriteLine("Tipo de Servicio no válido. No se puede calcular la comisión.");
                    continue;
            }

            // Asignar el monto de comisión al vector
            montoComision[indice] = montoComisionInput;

            // Calcular Monto Deducido (monto a pagar menos la comisión)
            montoDeducido[indice] = montoPagar[indice] - montoComision[indice];

            // Ingresar Monto Paga Cliente
            decimal montoPagaClienteInput;
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Monto Paga Cliente: ");
                if (decimal.TryParse(Console.ReadLine(), out montoPagaClienteInput))
                {
                    if (montoPagaClienteInput < montoPagar[indice])
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("El monto pagado por el cliente no puede ser menor al monto a pagar.");
                        continue;
                    }
                    montoPagaCliente[indice] = montoPagaClienteInput;
                    break; // Salir del bucle si el monto pagado por el cliente es válido
                }
                else
                {
                    Console.WriteLine("Formato de monto incorrecto. Intente nuevamente.");
                }
            } while (true);

            // Calcular Vuelto (monto a pagar - monto paga cliente)
            vuelto[indice] = montoPagaCliente[indice] - montoPagar[indice];

            // Incrementar el índice
            indice++;
            Console.Clear(); 

            for (int i = 0; i < indice; i++)
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.Clear();
                Console.WriteLine("                                        Datos del Pago                           ");
                Console.WriteLine("----------------------------------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine($"Número de Pago:       {numeroPago[i]}");
                Console.WriteLine($"Fecha y Hora:         {fecha[i]:yyyy-MM-dd}              Hora:          {hora[i]:hh\\:mm}");
                Console.WriteLine();
                Console.WriteLine($"Cédula:               {cedula[i]}                    Nombre:        {nombre[i]}");
                Console.WriteLine($"Apellido1:            {apellido1[i]}                      Apellido2:     {apellido2[i]}");
                Console.WriteLine();
                Console.WriteLine($"Número de Caja:       {numeroCaja[i]}");
                Console.WriteLine($"Tipo de Servicio:     {(tipoServicio[i])}             |1-Electricidad 2-Telefono 3-Agua|");
                Console.WriteLine();
                Console.WriteLine($"Número de Factura:    {numeroFactura[i]}                   Monto A Pagar:  {montoPagar[i]}");
                Console.WriteLine($"Comision autorizada : {montoComision[i]}                 Paga con:       {montoPagaCliente[i]}");
                Console.WriteLine($"Monto Deducido  :     {montoDeducido[i]}                Vuelto:         {vuelto[i]}");
                Console.WriteLine();
                Console.WriteLine();
            }

            // Verificar si se desea ingresar más pagos
            if (indice >= 10)
            {
                Console.WriteLine("Vectores Llenos");
                break;
            }

            Console.Write("¿Desea ingresar otro pago? (S/N): ");
            string respuesta = Console.ReadLine().ToUpper();
            if (respuesta != "S")
            {
                break;
            }
        }
    }
    static void ConsultarPagos()
    {
        Console.Write("Ingrese el número de pago que desea consultar: ");

        int numeroConsulta;
        if (int.TryParse(Console.ReadLine(), out numeroConsulta))
        {
            int indiceConsulta = Array.IndexOf(numeroPago, numeroConsulta);
            if (indiceConsulta != -1 && !pagoEliminado[indiceConsulta])
            {
                // Mostrar los datos del pago
                MostrarDetallesPago(indiceConsulta);
            }
            else
            {
                // Mostrar el mensaje de pago no encontrado
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.Clear();
                Console.WriteLine("**************Pago no se encuentra registrado o ha sido eliminado**************.");
                Console.WriteLine("Precione Enter para continuar.");
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ingrese solo números. Presione Enter para continuar");
        }
        Console.ReadLine();
    }
    static void MostrarDetallesPago(int indice)

    {
        Console.BackgroundColor = ConsoleColor.DarkBlue;
        Console.Clear();     

        Console.WriteLine("                                        Datos del Pago                           ");
        Console.WriteLine("----------------------------------------------------------------------------------");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"Número de Pago:       {numeroPago[indice]}");
        Console.WriteLine($"Fecha y Hora:         {fecha[indice]:yyyy-MM-dd}             Hora:          {hora[indice]:hh\\:mm}");
        Console.WriteLine();
        Console.WriteLine($"Cédula:               {cedula[indice]}                    Nombre:        {nombre[indice]}");
        Console.WriteLine($"Apellido1:            {apellido1[indice]}                   Apellido2:     {apellido2[indice]}");
        Console.WriteLine();
        Console.WriteLine($"Número de Caja:       {numeroCaja[indice]}");
        Console.WriteLine($"Tipo de Servicio:     {(tipoServicio[indice])}             |1-Electricidad 2-Telefono 3-Agua");
        Console.WriteLine();
        Console.WriteLine($"Número de Factura:    {numeroFactura[indice]}                   Monto A Pagar:  {montoPagar[indice]}");
        Console.WriteLine($"Comision autorizada : {montoComision[indice]}                 Paga con:       {montoPagaCliente[indice]}");
        Console.WriteLine($"Monto Deducido  :     {montoDeducido[indice]}                Vuelto:         {vuelto[indice]}");
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Digite ENTER para continuar.");
    }
    static void ModificarPagos()
    {
        Console.Write("Ingrese el número de pago que desea modificar: ");
        if (int.TryParse(Console.ReadLine(), out int numeroModificar))
        {
            int indice = Array.IndexOf(numeroPago, numeroModificar);
            if (indice != -1 && !pagoEliminado[indice])
            {
                Console.Clear();
                Console.WriteLine($"Datos actuales del pago número {numeroModificar}:");
                Console.WriteLine($"Fecha y Hora:-------------------{fecha[indice]} {hora[indice]}:");
                Console.WriteLine($"Cédula:------------------------{cedula[indice]}");
                Console.WriteLine($"Nombre:------------------------{nombre[indice]}");
                Console.WriteLine($"Primer Apellido:---------------{apellido1[indice]}");
                Console.WriteLine($"Segundo Apellido:--------------{apellido2[indice]}");
                Console.WriteLine($"Número de Caja:----------------{numeroCaja[indice]}");
                Console.WriteLine($"Tipo de Servicio:--------------{tipoServicio[indice]}");
                Console.WriteLine($"Número de Factura:-------------{numeroFactura[indice]}");
                Console.WriteLine($"Monto a Pagar:-----------------{montoPagar[indice]}");
                Console.WriteLine($"Monto Comisión:----------------{montoComision[indice]}");
                Console.WriteLine($"Monto Deducido:----------------{montoDeducido[indice]}");
                Console.WriteLine($"Monto Paga Cliente:------------{montoPagaCliente[indice]}");

                Console.WriteLine("--------------------------------------------------------");
                Console.WriteLine("Seleccione el dato que desea modificar:");
                Console.WriteLine("1. Fecha ");
                Console.WriteLine("2. Cédula");
                Console.WriteLine("3. Nombre");
                Console.WriteLine("4. Primer Apellido");
                Console.WriteLine("5. Segundo Apellido");
                Console.WriteLine("6. Número de Caja");
                Console.WriteLine("7. Tipo de Servicio");
                Console.WriteLine("8. Número de Factura");
                Console.WriteLine("9. Monto a Pagar");
                Console.WriteLine("Precione el numero a modificar o Enter para salir");

                if (int.TryParse(Console.ReadLine(), out int opcionModificar))
                {
                    switch (opcionModificar)
                    {
                        case 1:
                            Console.Write("Ingrese la nueva fecha (dd/MM/yyyy): ");
                            fecha[indice] = DateTime.Parse(Console.ReadLine());
                            break;
                        case 2:
                            Console.Write("Ingrese la nueva cédula: ");
                            cedula[indice] = Console.ReadLine();
                            break;
                        case 3:
                            Console.Write("Ingrese el nuevo nombre: ");
                            nombre[indice] = Console.ReadLine();
                            break;
                        case 4:
                            Console.Write("Ingrese el nuevo primer apellido: ");
                            apellido1[indice] = Console.ReadLine();
                            break;
                        case 5:
                            Console.Write("Ingrese el nuevo segundo apellido: ");
                            apellido2[indice] = Console.ReadLine();
                            break;
                        case 6:
                            Console.Write("Ingrese el nuevo número de caja (1-3): ");
                            numeroCaja[indice] = int.Parse(Console.ReadLine());
                            break;
                        case 7:
                            Console.Write("Ingrese el nuevo tipo de servicio (1=Luz, 2=Teléfono, 3=Agua): ");
                            tipoServicio[indice] = int.Parse(Console.ReadLine());
                            break;
                        case 8:
                            Console.Write("Ingrese el nuevo número de factura: ");
                            numeroFactura[indice] = Console.ReadLine();
                            break;
                        case 9:
                            Console.Write("Ingrese el nuevo monto a pagar: ");
                            montoPagar[indice] = decimal.Parse(Console.ReadLine());
                            switch (tipoServicio[indice])
                            {
                                case 1:
                                    montoComision[indice] = montoPagar[indice] * 0.04m;
                                    break;
                                case 2:
                                    montoComision[indice] = montoPagar[indice] * 0.055m;
                                    break;
                                case 3:
                                    montoComision[indice] = montoPagar[indice] * 0.065m;
                                    break;
                            }

                            // Calcular el monto deducido y validar el monto a pagar del cliente
                            montoDeducido[indice] = montoPagar[indice] - montoComision[indice];
                            do
                            {
                                Console.Write("Ingrese el nuevo monto que paga el cliente: ");
                                montoPagaCliente[indice] = decimal.Parse(Console.ReadLine());
                                if (montoPagaCliente[indice] < montoDeducido[indice])
                                {
                                    Console.WriteLine("Error: El nuevo monto a pagar del cliente no puede ser menor al monto deducido.");
                                }
                            } while (montoPagaCliente[indice] < montoDeducido[indice]);

                            // Calcular el nuevo vuelto
                            decimal vueltoNuevo = montoPagaCliente[indice] - montoDeducido[indice];
                            Console.WriteLine($"Modificación realizada con éxito. Nuevo vuelto: {vueltoNuevo}");
                            break;

                        default:
                            Console.WriteLine("Opción no válida.ENTER para continuar.");
                            Console.ReadKey();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Opción no válida.ENTER para continuar.");
                    Console.ReadKey();
                }
            }
            else if (indice == -1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Pago no se encuentra registrado.ENTER para continuar.");
                Console.ReadKey();
            }
            else if (pagoEliminado[indice])
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("El pago ha sido eliminado.ENTER para continuar.");
                Console.ReadKey();
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Número de pago no válido.ENTER para continuar.");
            Console.ReadKey();           
        }
    }
    static void EliminarPagos()
    {
        Console.Write("Ingrese el número de pago que desea eliminar: ");
        if (int.TryParse(Console.ReadLine(), out int numeroEliminar))
        {
            int indice = Array.IndexOf(numeroPago, numeroEliminar);
            if (indice != -1 && !pagoEliminado[indice])
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.Clear();
                Console.WriteLine("                                        Datos del Pago                           ");
                Console.WriteLine("----------------------------------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine($"Número de Pago:       {numeroPago[indice]}");
                Console.WriteLine($"Fecha y Hora:         {fecha[indice]:yyyy-MM-dd}             Hora:          {hora[indice]:hh\\:mm}");
                Console.WriteLine();
                Console.WriteLine($"Cédula:               {cedula[indice]}                    Nombre:        {nombre[indice]}");
                Console.WriteLine($"Apellido1:            {apellido1[indice]}                   Apellido2:     {apellido2[indice]}");
                Console.WriteLine();
                Console.WriteLine($"Número de Caja:       {numeroCaja[indice]}");
                Console.WriteLine($"Tipo de Servicio:     {(tipoServicio[indice])}             |1-Electricidad 2-Telefono 3-Agua");
                Console.WriteLine();
                Console.WriteLine($"Número de Factura:    {numeroFactura[indice]}                   Monto A Pagar:  {montoPagar[indice]}");
                Console.WriteLine($"Comision autorizada : {montoComision[indice]}                 Paga con:       {montoPagaCliente[indice]}");
                Console.WriteLine($"Monto Deducido  :     {montoDeducido[indice]}                Vuelto:         {vuelto[indice]}");
                Console.WriteLine();
                Console.Write("¿Está seguro de eliminar el dato? (S/N): ");

                char respuesta;
                if (char.TryParse(Console.ReadLine(), out respuesta))
                {
                    if (respuesta == 'S' || respuesta == 's')
                    {
                        pagoEliminado[indice] = true;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("La información fue eliminada con éxito.ENTER para continuar.");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("La información no fue eliminada.ENTER para continuar.");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Entrada no válida. La información no fue eliminada.ENTER para continuar.");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Pago no se encuentra registrado o ya fue eliminado.ENTER para continuar.");
                Console.ReadKey();
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Número de pago no válido.");
            Console.ReadKey();
        }
    }
    static void SubmenuReportes()
    {
        int opcionReporte;
        do
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("------------------Submenú Reportes------------------");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("1. Reporte Todos los Pagos");
            Console.WriteLine("2. Reporte Ver Pagos por Tipo de Servicios");
            Console.WriteLine("3. Reporte Ver Pagos por Código de Caja");
            Console.WriteLine("4. Ver Dinero Comisionado por servicios");
            Console.WriteLine("5. Volver al Menú Principal");
            Console.Write("Ingrese la opción: ");

            if (int.TryParse(Console.ReadLine(), out opcionReporte))
            {
                switch (opcionReporte)
                {
                    case 1:
                        ReporteTodosLosPagos();
                        break;
                    case 2:
                        ReportePagosPorTipoServicio();
                        break;
                    case 3:
                        ReportePagosPorCodigoCaja();
                        break;
                    case 4:
                        ReporteDineroComisionado();
                        break;
                    case 5:
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Opción no válida. Ingrese un número del 1 al 5.");
                        Console.ReadKey();
                        break;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Entrada no válida. Ingrese un número del 1 al 5.");
                Console.ReadLine();
            }
        } while (opcionReporte != 5);
    }
    static void ReporteTodosLosPagos()
    {
        bool hayPagosRealizados = false;
        Console.BackgroundColor = ConsoleColor.DarkBlue;
        Console.Clear();

        for (int i = 0; i < 10; i++)
        {
            if (!pagoEliminado[i] && (
                !string.IsNullOrEmpty(nombre[i]) ||
                !string.IsNullOrEmpty(apellido1[i]) ||
                !string.IsNullOrEmpty(apellido2[i]) ||
                !string.IsNullOrEmpty(cedula[i])))
            {
                hayPagosRealizados = true;
                MostrarInformacionPago(i);
            }
        }

        if (!hayPagosRealizados)
        {
            Console.WriteLine("No hay pagos realizados.");
        }
        Console.ReadLine();
    }
    static void ReportePagosPorTipoServicio()
    {
        Console.Write("Ingrese el tipo de servicio para el reporte (1=Luz, 2=Teléfono, 3=Agua): ");
        if (int.TryParse(Console.ReadLine(), out int tipoServicioReporte))
        {
            Console.WriteLine($"Reporte de Pagos por Tipo de Servicio {tipoServicioReporte}:");
            bool hayPagosRealizados = false;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Clear();

            for (int i = 0; i < 10; i++)
            {
                if (!pagoEliminado[i] && tipoServicio[i] == tipoServicioReporte)
                {
                    hayPagosRealizados = true;
                    MostrarInformacionPago(i);
                }
            }
            if (!hayPagosRealizados)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Clear();
                Console.WriteLine("****************No hay pagos realizados para el tipo de servicio seleccionado****************");
                Console.WriteLine("Presione Enter para continuar.");
            }
        }
        else
        {
            Console.WriteLine("Tipo de servicio ingresado no válido.");
        }
        Console.ReadLine();
    }
    static void ReportePagosPorCodigoCaja()
    {
        Console.Write("Ingrese el número de caja para el reporte (1-3): ");
        if (int.TryParse(Console.ReadLine(), out int codigoCajaReporte))
        {
            Console.WriteLine($"Reporte de Pagos por Código de Caja {codigoCajaReporte}:");
            bool hayPagosRealizados = false;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Clear();

            for (int i = 0; i < 10; i++)
            {
                if (!pagoEliminado[i] && numeroPago[i] == codigoCajaReporte)
                {
                    hayPagosRealizados = true;
                    MostrarInformacionPago(i);
                }
            }

            if (!hayPagosRealizados)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Clear();
                Console.WriteLine("***************No hay pagos realizados para el código de caja seleccionado***************");
                Console.WriteLine("Presione Enter para continuar.");
            }
        }
        else
        {
            Console.WriteLine("Número de caja ingresado no válido.");
            Console.ReadKey();
        }
        Console.ReadLine();
    }
    static void ReporteDineroComisionado()
    {
        Console.WriteLine("Resumen del Dinero Comisionado por Servicios:");
        decimal comisionLuz = 0;
        decimal comisionTelefono = 0;
        decimal comisionAgua = 0;
        int totalTransaccionesLuz = 0;
        int totalTransaccionesTelefono = 0;
        int totalTransaccionesAgua = 0;

        for (int i = 0; i < 10; i++)
        {
            if (!pagoEliminado[i])
            {
                switch (tipoServicio[i])
                {
                    case 1:
                        comisionLuz += montoComision[i];
                        totalTransaccionesLuz++;
                        break;
                    case 2:
                        comisionTelefono += montoComision[i];
                        totalTransaccionesTelefono++;
                        break;
                    case 3:
                        comisionAgua += montoComision[i];
                        totalTransaccionesAgua++;
                        break;
                }
            }
        }
        Console.BackgroundColor = ConsoleColor.DarkBlue;
        Console.Clear();
        Console.WriteLine($"Comisión por Recibo de Luz: {comisionLuz}, Transacciones: {totalTransaccionesLuz}");
        Console.WriteLine($"Comisión por Recibo de Teléfono: {comisionTelefono}, Transacciones: {totalTransaccionesTelefono}");
        Console.WriteLine($"Comisión por Recibo de Agua: {comisionAgua}, Transacciones: {totalTransaccionesAgua}");
        Console.WriteLine("Presione Enter para continuar");
        Console.ReadLine();
    }
    static void MostrarInformacionPago(int indice)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"Número de Pago:       {numeroPago[indice]}");
        Console.WriteLine($"Fecha y Hora:         {fecha[indice]:yyyy-MM-dd}             Hora:          {hora[indice]:hh\\:mm}");
        Console.WriteLine();
        Console.WriteLine($"Cédula:               {cedula[indice]}                    Nombre:        {nombre[indice]}");
        Console.WriteLine($"Apellido1:            {apellido1[indice]}                   Apellido2:     {apellido2[indice]}");
        Console.WriteLine($"Monto de recibo:      {montoPagar[indice]}");
        Console.WriteLine("-------------------------------------------------------------------------------------------");
        Console.WriteLine("Presione Enter para continuar");
    }
}
