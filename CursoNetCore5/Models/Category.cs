using System.ComponentModel.DataAnnotations;

namespace CursoNetCore5.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(120)]
        [Display(Name = "Nombre categoría")]
        public string NombreCatergoria { get; set; }

        [Required]
        [MaxLength(2)]
        [Display(Name = "Tipo")]
        public string Tipo { get; set; }  //IN - Ingreso   |   EG - Egreso

        [Required]
        public bool Estado { get; set; }
    }
}
