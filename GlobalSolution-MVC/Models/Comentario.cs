using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GlobalSolution_MVC.Models
{
    [Table("Comentarios")]
    public class Comentario
    {
        [Key]
        [Column("ID_Comentario")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ComentarioId { get; set; }

        [Required(ErrorMessage = "O conteúdo do comentário é obrigatório.")]
        [MaxLength(500)]
        [Column("Conteudo")]
        public string Conteudo { get; set; }

        [Required(ErrorMessage = "A data e hora do comentário são obrigatórias.")]
        [Column("Data_Hora")]
        public DateTime DataHora { get; set; }

        
        [ForeignKey("DenunciaId")]
        public int DenunciaId { get; set; }
        public Denuncia Denuncia { get; set; }
    }
}
