using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_Academia.Models
{
    [Table("Estudiante")]
    public class Estudiante
    {
        [Key]
        public int Estudiante_Id { get; set; }

        [Required(ErrorMessage = "Requerido")]
        public string Tipo_Identificacion { get; set; }

        [Required(ErrorMessage = "Requerido")]
        public string Numero_Identificacion { get; set; }

        [Required(ErrorMessage = "Requerido")]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Requerido")]
        [StringLength(100)]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Requerido")]
        public string Sexo { get; set; }

        [Required(ErrorMessage = "Requerido")]
        public DateTime Fecha_Nacimiento { get; set; }
        public string Direccion { get; set; }
        public string Correo_Electronico { get; set; }
        public string Telefono { get; set; }
    }
}
