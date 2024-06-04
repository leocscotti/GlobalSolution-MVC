using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GlobalSolution_MVC.Models
{
    [Table("AutoridadeAmbientalDenuncia")]
    public class AutoridadeAmbientalDenuncia
    {
        [Key]
        [Column("ID_AutoridadeDenuncia")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AutoridadeDenunciaId { get; set; }

        [ForeignKey("DenunciaId")]
        public int DenunciaId { get; set; }
        public Denuncia Denuncia { get; set; }

        [ForeignKey("AutoridadeId")]
        public int AutoridadeId { get; set; }
        public AutoridadeAmbiental Autoridade { get; set; }
    }
}
