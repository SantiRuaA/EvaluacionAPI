using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace EvaluacionAPI.Entities
{
    public class Empleado
    {
        public int Id { get; set; }
        [Required]

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Telefono1 { get; set;}

        public string Telefono2 { get; set; }

        public string Correo { get; set; }
        public List<Cliente> Clientes { get; set; }
    }
}
