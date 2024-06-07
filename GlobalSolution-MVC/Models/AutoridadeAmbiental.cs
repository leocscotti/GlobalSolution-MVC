using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GlobalSolution_MVC.Models
{
    [Table("tb_autoridade_ambiental")]
    public class AutoridadeAmbiental
    {
        [Key]
        [Column("ID_Autoridade")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AutoridadeAmbientalId { get; set; }

        [Required(ErrorMessage = "O nome da autoridade é obrigatório.")]
        [MaxLength(100)]
        [Column("nm_autoridade_ambiental")]
        public string Nome { get; set; }

        [MaxLength(100)]
        [Column("ds_autoridade_ambiental")]
        public string Descricao { get; set; }

        // Relacionamento N..N com denuncias a serem analisadas
        public ICollection<AutoridadeAmbientalDenuncia> Denuncias { get; set; }
    }
}
