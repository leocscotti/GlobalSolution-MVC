using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GlobalSolution_MVC.Models
{
    [Table("Denuncias")]
    public class Denuncia
    {
        [Key]
        [Column("ID_Denuncia")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DenunciaId { get; set; }

        [Required(ErrorMessage = "O tipo de poluição é obrigatório.")]
        [MaxLength(50)]
        [Column("Tipo_Poluicao")]
        public string TipoPoluicao { get; set; } 

        [Required(ErrorMessage = "A data e hora da denúncia são obrigatórias.")]
        [Column("Data_Hora")]
        public DateTime DataHora { get; set; }

        [MaxLength(500)]
        [Column("Descricao")]
        public string Descricao { get; set; }

        [Column("Status")]
        public string Status { get; set; }

        [ForeignKey("UsuarioId")]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        
        [ForeignKey("LocalizacaoId")]
        public int LocalizacaoId { get; set; }
        public Localizacao Localizacao { get; set; }


        public ICollection<Comentario> Comentarios { get; set; }

        // Relacionamento N..N com autoridades ambientais responsáveis pela análise
        public ICollection<AutoridadeAmbientalDenuncia> Autoridades { get; set; }
    }
}
