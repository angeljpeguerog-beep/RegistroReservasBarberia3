
using SistemaBarberiaPOO.Data;
using SistemaBarberiaPOO.Models;
using System;
using System.Linq;

namespace SistemaBarberiaPOO.Services
{
    public class GestionBarberia
    {
        private readonly BarberiaContext db;

        
        public GestionBarberia(BarberiaContext contexto)
        {
            db = contexto;
        }

        
        public void AddCliente()
        {
            Console.Clear();
            Console.WriteLine("===== AGREGAR CLIENTE =====");

            Console.Write("Nombre: ");
            string nombre = LeerTexto();

            Console.Write("Telefono: ");
            string telefono = LeerTexto();

            Console.Write("Servicio: ");
            string servicio = LeerTexto();

            Console.Write("Nombre del barbero: ");
            string barbero = LeerTexto();

            Cliente nuevo = new Cliente(
                nombre,
                telefono,
                servicio,
                barbero
            );

            db.Clientes.Add(nuevo);
            db.SaveChanges();

            Console.WriteLine("\nCliente registrado correctamente.");
            Console.WriteLine("ID asignado: " + nuevo.Id);

            Pausar();
        }

        
        public void ViewClientes()
        {
            Console.Clear();
            Console.WriteLine("===== LISTADO DE CLIENTES =====");

            var lista = db.Clientes.ToList();

            if (lista.Count == 0)
            {
                Console.WriteLine("No hay clientes registrados.");
            }
            else
            {
                foreach (Cliente cliente in lista)
                {
                    cliente.MostrarInformacion();
                }

                Console.WriteLine("Total de clientes: " + lista.Count);
            }

            Pausar();
        }

        
        public void SearchCliente()
        {
            Console.Clear();

            Console.WriteLine("===== BUSCAR CLIENTE =====");
            Console.WriteLine("1. Buscar por ID");
            Console.WriteLine("2. Buscar por nombre");
            Console.WriteLine("3. Buscar por telefono");
            Console.WriteLine("4. Buscar por servicio");
            Console.WriteLine("5. Buscar por barbero");
            Console.Write("Seleccione una opcion: ");

            if (!int.TryParse(Console.ReadLine(), out int opcion))
            {
                Console.WriteLine("Opcion invalida.");
                Pausar();
                return;
            }

            IQueryable<Cliente> consulta = db.Clientes;

            switch (opcion)
            {
                case 1:
                    Console.Write("Digite el ID: ");

                    if (!int.TryParse(Console.ReadLine(), out int id))
                    {
                        Console.WriteLine("ID invalido.");
                        Pausar();
                        return;
                    }

                    consulta = consulta.Where(c => c.Id == id);
                    break;

                case 2:
                    Console.Write("Digite el nombre: ");
                    string nombre = LeerTexto();

                    consulta = consulta.Where(c =>
                        c.Nombre.Contains(nombre));
                    break;

                case 3:
                    Console.Write("Digite el telefono: ");
                    string telefono = LeerTexto();

                    consulta = consulta.Where(c =>
                        c.Telefono.Contains(telefono));
                    break;

                case 4:
                    Console.Write("Digite el servicio: ");
                    string servicio = LeerTexto();

                    consulta = consulta.Where(c =>
                        c.Servicio.Contains(servicio));
                    break;

                case 5:
                    Console.Write("Digite el barbero: ");
                    string barbero = LeerTexto();

                    consulta = consulta.Where(c =>
                        c.Barbero.Contains(barbero));
                    break;

                default:
                    Console.WriteLine("Criterio no valido.");
                    Pausar();
                    return;
            }

            var resultados = consulta.ToList();

            if (resultados.Count > 0)
            {
                Console.WriteLine("\nClientes encontrados:");

                foreach (Cliente cliente in resultados)
                {
                    cliente.MostrarInformacion();
                }
            }
            else
            {
                Console.WriteLine("No se encontraron resultados.");
            }

            Pausar();
        }

        
        public void EditCliente()
        {
            Console.Clear();
            Console.WriteLine("===== MODIFICAR CLIENTE =====");

            Console.Write("Digite el ID: ");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID invalido.");
                Pausar();
                return;
            }

            Cliente cliente = db.Clientes.FirstOrDefault(
                c => c.Id == id
            );

            if (cliente == null)
            {
                Console.WriteLine("Cliente no encontrado.");
                Pausar();
                return;
            }

            Console.WriteLine("\nDatos actuales:");
            cliente.MostrarInformacion();

            Console.Write("Nuevo nombre: ");
            cliente.Nombre = LeerTexto();

            Console.Write("Nuevo telefono: ");
            cliente.Telefono = LeerTexto();

            Console.Write("Nuevo servicio: ");
            cliente.Servicio = LeerTexto();

            Console.Write("Nuevo barbero: ");
            cliente.Barbero = LeerTexto();

            db.SaveChanges();

            Console.WriteLine("\nCliente actualizado correctamente.");

            Pausar();
        }

        
        public void DeleteCliente()
        {
            Console.Clear();
            Console.WriteLine("===== ELIMINAR CLIENTE =====");

            Console.Write("Digite el ID: ");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID invalido.");
                Pausar();
                return;
            }

            Cliente cliente = db.Clientes.FirstOrDefault(
                c => c.Id == id
            );

            if (cliente == null)
            {
                Console.WriteLine("Cliente no encontrado.");
                Pausar();
                return;
            }

            cliente.MostrarInformacion();

            Console.WriteLine("1. Si, eliminar");
            Console.WriteLine("2. No, cancelar");
            Console.Write("Seleccione: ");

            if (!int.TryParse(Console.ReadLine(), out int opcion))
            {
                Console.WriteLine("Opcion invalida.");
                Pausar();
                return;
            }

            if (opcion == 1)
            {
                db.Clientes.Remove(cliente);
                db.SaveChanges();

                Console.WriteLine("Cliente eliminado correctamente.");
            }
            else
            {
                Console.WriteLine("Operacion cancelada.");
            }

            Pausar();
        }

        
        private string LeerTexto()
        {
            string texto;

            do
            {
                texto = (Console.ReadLine() ?? "").Trim();

                if (string.IsNullOrWhiteSpace(texto))
                {
                    Console.Write("Campo obligatorio. Intente nuevamente: ");
                }

            } while (string.IsNullOrWhiteSpace(texto));

            return texto;
        }

        
        private void Pausar()
        {
            Console.WriteLine("\nPresione ENTER para continuar...");
            Console.ReadLine();
        }
    }
}
