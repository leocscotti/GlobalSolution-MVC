using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GlobalSolution_MVC.Models
{
    [Table("AutoridadesAmbientais")]
    public class AutoridadeAmbiental
    {
        [Key]
        [Column("ID_Autoridade")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AutoridadeId { get; set; }

        [Required(ErrorMessage = "O nome da autoridade é obrigatório.")]
        [MaxLength(100)]
        [Column("Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O email da autoridade é obrigatório.")]
        [EmailAddress(ErrorMessage = "O email inserido não é válido.")]
        [MaxLength(100)]
        [Column("Email")]
        public string Email { get; set; }

        
    }
}
