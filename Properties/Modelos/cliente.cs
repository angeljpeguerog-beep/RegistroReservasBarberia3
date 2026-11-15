
using System.ComponentModel.DataAnnotations;

namespace SistemaBarberiaPOO.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; } = "";

        [Required]
        [MaxLength(20)]
        public string Telefono { get; set; } = "";

        [Required]
        [MaxLength(100)]
        public string Servicio { get; set; } = "";

        [Required]
        [MaxLength(100)]
        public string Barbero { get; set; } = "";

        
        public Cliente()
        {
        }

        
        public Cliente(string nombre, string telefono,
                       string servicio, string barbero)
        {
            Nombre = nombre;
            Telefono = telefono;
            Servicio = servicio;
            Barbero = barbero;
        }

        public void MostrarInformacion()
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine("ID: " + Id);
            Console.WriteLine("Nombre: " + Nombre);
            Console.WriteLine("Telefono: " + Telefono);
            Console.WriteLine("Servicio: " + Servicio);
            Console.WriteLine("Barbero: " + Barbero);
            Console.WriteLine("--------------------------------");
        }
    }
}
