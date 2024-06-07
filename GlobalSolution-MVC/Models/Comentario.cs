using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GlobalSolution_MVC.Models
{
    [Table("tb_comentario")]
    public class Comentario
    {
        [Key]
        [Column("ID_Comentario")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ComentarioId { get; set; }

        [Required(ErrorMessage = "A descrição do comentário é obrigatória.")]
        [MaxLength(500)]
        [Column("ds_comentario")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O tipo do comentário é obrigatório.")]
        [Column("tp_comentario")]
        public string Tipo { get; set; }
    }
}
