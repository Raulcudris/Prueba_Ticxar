using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_Academia.Models
{
    [Table("Notas")]
    public class Notas
    {

        [Key]
        public int Nota_Id { get; set; }
        public int Materia_Id { get; set; }
        public int Profesor_Id { get; set; }
        public int Estudiante_Id { get; set; }        
      
        public double Calificacion { get; set; }
      
        public string Descripcion { get; set; }


    }
}
