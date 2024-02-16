using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoBancoDados.Models
{
    [Table("Visita")]
    public class Visita
    {
        [Column("VisitaId")]
        [Display(Name = "Código da Visita")]

        public int VisitaId { get; set; }

        [Column("DataVisita")]
        [Display(Name = "Data da Visita")]

        public DateTime DataVisita { get; set; }
    }
}
