using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjetoBancoDados.Models
{
    [Table("Artista")]
    public class Artista
    {
        [Column("ArtistaId")]
        [Display(Name = "Código do Artista")]

        public int ArtistaId { get; set; }

        [Column("NomeArtista")]
        [Display(Name = "Nome do Artista")]

        public string NomeArtista { get; set; } = string.Empty;

        [Column("NacionalidadeArtista")]
        [Display(Name = "Nacionalidade do Artista")]

        public string NacionalidadeArtista { get; set; } = string.Empty;

        [Column("DataNascimentoFalecimento")]
        [Display(Name = "Data de Nascimento e Falecimento do Artista")]

        public DateTime DataNascimentoFalecimento { get; set; }
    }
}
