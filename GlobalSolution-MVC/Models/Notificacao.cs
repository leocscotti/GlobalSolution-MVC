using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GlobalSolution_MVC.Models
{
    [Table("tb_notificacao")]
    public class Notificacao
    {
        [Key]
        [Column("ID_Notificacao")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NotificacaoId { get; set; }

        [Required(ErrorMessage = "A descrição da notificação é obrigatória.")]
        [MaxLength(500)]
        [Column("ds_comentario")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O status da notificação é obrigatório.")]
        [MaxLength(1)]
        [Column("st_comentario")]
        public string Status { get; set; }

        [Required(ErrorMessage = "o tipo da notificação é obrigatório.")]
        [Column("tp_comentario")]
        public string Tipo { get; set; }

        public int ComentarioId { get; set; }
        public Comentario? Comentario { get; set; }
    }
}
