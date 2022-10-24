using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CursoNetCore5.Models
{
    public class IncomeExpenses
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Categories { get; set; }

        [Required]
        [Display(Name = "Fecha")]
        public DateTime Fecha { get; set; }

        [Required]
        [Range(1,100000)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Display(Name = "Valor")]
        public double Valor { get; set; }
    }
}
