
using System;
using Microsoft.EntityFrameworkCore;
using SistemaBarberiaPOO.Data;
using SistemaBarberiaPOO.Services;

namespace SistemaBarberiaPOO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                
                using BarberiaContext db = new BarberiaContext();

                
              

                
                GestionBarberia barberia = new GestionBarberia(db);

                bool running = true;

                while (running)
                {
                    Console.Clear();

                    Console.WriteLine("==================================");
                    Console.WriteLine("       SISTEMA DE BARBERIA");
                    Console.WriteLine("==================================");
                    Console.WriteLine("1. Agregar cliente");
                    Console.WriteLine("2. Ver clientes");
                    Console.WriteLine("3. Buscar cliente");
                    Console.WriteLine("4. Modificar cliente");
                    Console.WriteLine("5. Eliminar cliente");
                    Console.WriteLine("6. Salir");
                    Console.WriteLine("==================================");

                    Console.Write("Seleccione una opcion: ");

                    if (!int.TryParse(Console.ReadLine(), out int opcion))
                    {
                        Console.WriteLine("Introduzca un numero valido.");
                        Console.ReadLine();
                        continue;
                    }

                    try
                    {
                        switch (opcion)
                        {
                            case 1:
                                barberia.AddCliente();
                                break;

                            case 2:
                                barberia.ViewClientes();
                                break;

                            case 3:
                                barberia.SearchCliente();
                                break;

                            case 4:
                                barberia.EditCliente();
                                break;

                            case 5:
                                barberia.DeleteCliente();
                                break;

                            case 6:
                                Console.WriteLine("Gracias por utilizar Barberia System.");
                                running = false;
                                break;

                            default:
                                Console.WriteLine("Opcion no valida.");
                                Console.ReadLine();
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error en la operacion: " + ex.Message);
                        Console.WriteLine("Verifique los datos y la conexion.");
                        Console.ReadLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("No se pudo iniciar el sistema.");
                Console.WriteLine("Detalle: " + ex.Message);
                Console.WriteLine("Verifique SQL Server y la cadena de conexion.");
                Console.ReadLine();
            }
        }
    }
}

