using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GlobalSolution_MVC.Models
{
    [Table("tb_localizacao")]
    public class Localizacao
    {
        [Key]
        [Column("ID_Localizacao")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LocalizacaoId { get; set; }

        [Required(ErrorMessage = "A latitude é obrigatória.")]
        [MaxLength(100)]
        [Column("latitude")]
        public string Latitude { get; set; }

        [Required(ErrorMessage = "A longitude é obrigatória.")]
        [MaxLength(100)]
        [Column("longitude")]
        public string Longitude { get; set; }

        [MaxLength(100)]
        [Column("ds_localizacao")]
        public string Descricao { get; set; }


    }
}
