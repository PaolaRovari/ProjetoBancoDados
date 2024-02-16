using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoBancoDados.Models
{
    [Table("Lugar")]
    public class Lugar
    {
        [Column("LugarId")]
        [Display(Name = "Código do Lugar")]

        public int LugarId { get; set; }

        [Column("NomeLugar")]
        [Display(Name = "Nome do Lugar")]

        public string NomeLugar { get; set; } = string.Empty;

        [Column("HorarioFuncionamento")]
        [Display(Name = "Horário de Funcionamento")]

        public string HorarioFuncionamento { get; set; } = string.Empty;
    }
}
