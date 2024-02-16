using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjetoBancoDados.Models
{
    [Table("teste")]
    public class teste
    {
        [Column("testeId")]
        [Display(Name = "Código do Lugar da Visita")]
        public int testeId { get; set; }

        [Column("NomeTeste")]
        [Display(Name = "Nome do Lugar")]

        public string NomeTeste { get; set; } = string.Empty;

    }
}
