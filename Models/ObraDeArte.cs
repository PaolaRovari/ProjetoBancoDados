using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjetoBancoDados.Models
{
    [Table("ObraDeArte")]
    public class ObraDeArte
    {
        [Column("ObraDeArteId")]
        [Display(Name = "Código da Obra De Arte")]

        public int ObraDeArteId { get; set; }

        [Column("NomeObra")]
        [Display(Name = "Nome da Obra")]

        public string NomeObra { get; set; } = string.Empty;

        [Column("DataCriacaoObra")]
        [Display(Name = "Data de Criação")]

        public DateTime DataCriacaoObra { get; set; }

        [Column("TecnicaObra")]
        [Display(Name = "Técnica da Obra")]

        public string TecnicaObra { get; set; } = string.Empty;

        [Column("ValorObra")]
        [Display(Name = "Valor")]

        public string ValorObra { get; set; } = string.Empty;

        [ForeignKey("ArtistaId")]
        public int ArtistaId { get; set; }
        public Artista? Artista { get; set; }

        [ForeignKey("LugarId")]
        public int LugarId { get; set; }
        public Lugar? Lugar { get; set; }

        [NotMapped]
        public List<LugarVisita>? LugarVisita { get; set; }
    }
}
