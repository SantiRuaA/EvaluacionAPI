using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace EvaluacionAPI.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        [Required]

        public string NombreCliente { get; set; }

        public string ApellidoCliente { get; set; }

        public string Telefono1 { get; set; }

        public string Telefono2 { get; set; }

        public string CorreoCliente { get; set; }

    }
}
