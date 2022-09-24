using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_Academia.Models
{
    public class Profesor
    {
        [Key]

        public int Profesor_Id { get; set; } 
        public string Tipo_Identificacion { get; set; }
        public string Numero_Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Sexo { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public string Direccion { get; set; }
        public string Correo_Electronico { get; set; }
        public string Telefono { get; set; }

    }
}
