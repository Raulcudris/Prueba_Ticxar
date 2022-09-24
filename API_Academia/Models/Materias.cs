using System.ComponentModel.DataAnnotations;

namespace API_Academia.Models
{
    public class Materias
    {
        [Key]
        public int Materia_Id { get; set; }
        [Required(ErrorMessage = "Requerido")]
        public string Codigo { get; set; }
        [Required(ErrorMessage = "Requerido")]
        [StringLength(200)]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
