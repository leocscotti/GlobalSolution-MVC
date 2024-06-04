using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GlobalSolution_MVC.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        [Column("ID_Usuario")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "O nome do usuário é obrigatório.")]
        [MaxLength(100)]
        [Column("Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O email do usuário é obrigatório.")]
        [EmailAddress(ErrorMessage = "O email inserido não é válido.")]
        [MaxLength(100)]
        [Column("Email")]
        public string Email { get; set; }

      
    }
}
