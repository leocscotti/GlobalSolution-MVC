using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GlobalSolution_MVC.Models
{
    [Table("tb_residuo")]
    public class Residuo
    {
        [Key]
        [Column("ID_Residuo")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ResiduoId { get; set; }

        [Required(ErrorMessage = "A descrição do resíduo é obrigatória.")]
        [MaxLength(500)]
        [Column("ds_residuo")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O tipo do resíduo é obrigatório.")]
        [Column("tp_residuo")]
        public string Tipo { get; set; }
    }
}
