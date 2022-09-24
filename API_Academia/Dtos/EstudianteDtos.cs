using System;

namespace API_Academia.Models
{
    public class EstudianteDtos
    {
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
