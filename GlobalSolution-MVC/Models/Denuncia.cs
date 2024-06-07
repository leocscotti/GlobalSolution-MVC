using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GlobalSolution_MVC.Models
{
    [Table("tb_denuncia")]
    public class Denuncia
    {
        [Key]
        [Column("ID_Denuncia")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DenunciaId { get; set; }

        [Required(ErrorMessage = "A data e hora da denúncia são obrigatórias.")]
        [Column("data_ocorrencia")]
        public DateTime DataHora { get; set; }

        [MaxLength(500)]
        [Column("ds_denuncia")]
        public string Descricao { get; set; }

        [MaxLength(1)]
        [Column("st_denuncia")]
        public string Status { get; set; }

        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }

        public int LocalizacaoId { get; set; }
        public Localizacao? Localizacao { get; set; }

        public int AutoridadeAmbientalId { get; set; }
        public AutoridadeAmbiental? AutoridadeAmbiental { get; set; }

        public int NotificacaoId { get; set; }
        public Notificacao? Notificacao { get; set; }

        public ICollection<Comentario> Comentarios { get; set; }

        // Relacionamento N..N com autoridades ambientais responsáveis pela análise
        public ICollection<AutoridadeAmbientalDenuncia> Autoridades { get; set; }
    }

}
