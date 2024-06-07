using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GlobalSolution_MVC.Models
{
    [Table("tb_autoridade_ambiental_denuncia")]
    public class AutoridadeAmbientalDenuncia
    {
        [Key]
        [Column("ID_AutoridadeDenuncia")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AutoridadeDenunciaId { get; set; }


        public int DenunciaId { get; set; }
        public Denuncia? Denuncia { get; set; }


        public int AutoridadeAmbientalId { get; set; }
        public AutoridadeAmbiental? AutoridadeAmbiental { get; set; }


    }
}
