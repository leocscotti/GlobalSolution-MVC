using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GlobalSolution_MVC.Models
{
    [Table("Localizacoes")]
    public class Localizacao
    {
        [Key]
        [Column("ID_Localizacao")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LocalizacaoId { get; set; }

        [Required(ErrorMessage = "O país é obrigatório.")]
        [MaxLength(100)]
        [Column("Pais")]
        public string Pais { get; set; }

        [Required(ErrorMessage = "A cidade é obrigatória.")]
        [MaxLength(100)]
        [Column("Cidade")]
        public string Cidade { get; set; }

        [MaxLength(100)]
        [Column("Estado")]
        public string Estado { get; set; }

        [MaxLength(100)]
        [Column("Rua")]
        public string Rua { get; set; }

        [MaxLength(20)]
        [Column("CEP")]
        public string CEP { get; set; }
    }
}
