using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjetoBancoDados.Models
{
    [Table("LugarVisita")]
    public class LugarVisita
    {
        [Column("LugarVisitaId")]
        [Display(Name = "Código do Lugar da Visita")]
        public int LugarVisitaId { get; set; }

        [ForeignKey("VisitaId")]
        public int VisitaId { get; set; }
        public Visita? Visita { get; set; }

        [ForeignKey("LugarId")]
        public int LugarId { get; set; }
        public Lugar? Lugar { get; set; }

        [NotMapped]
        public List<ObraDeArte>? ObraDeArte { get; set; }
    }
}
