using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PadronProveedoresAPI.Models.Entities
{
    public class CatColoniasModel
    {
        [Key]
        [Column("IdColonia")]
        public int IdColonia { get; set; }

        [Column("Colonia")]
        [Required(ErrorMessage = "La colonia es requerida")]
        [StringLength(100)]
        public required string Colonia { get; set; }

        [Column("IdMunicipio")]
        [ForeignKey("IdMunicipio")]
        public int IdMunicipio { get; set; }
    }
}
