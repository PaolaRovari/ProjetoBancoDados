using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjetoBancoDados.Models
{
    [Table("Visitante")]
    public class Visitante
    {
        [Column("VisitanteId")]
        [Display(Name = "Código da Visitante")]

        public int VisitanteId { get; set; }

        [Column("NomeVisitante")]
        [Display(Name = "Nome do Visitante")]

        public string NomeVisitante { get; set; } = string.Empty;

        [Column("EmailVisitante")]
        [Display(Name = "Email do Visitante")]

        public string EmailVisitante { get; set; } = string.Empty;

        [Column("TelefoneVisitante")]
        [Display(Name = "Telefone do Visitante")]

        public string TelefoneVisitante { get; set; } = string.Empty;

        [ForeignKey("VisitaId")]
        public int VisitaId { get;}
        public Visita? Visita { get; set; }
    }
}

