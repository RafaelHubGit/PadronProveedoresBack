using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PadronProveedoresAPI.Models.Entities
{
    public class CatMunicipiosModel
    {
        [Key]
        [Column("IdMunicipio")]
        public int IdMunicipio { get; set; }

        [Column("Municipio")]
        [Required(ErrorMessage = "El municipio es requerido")]
        [StringLength(100)]
        public required string Municipio { get; set; }

        [Column("IdEstado")]
        [ForeignKey("IdEstado")]
        public int IdEstado { get; set; }
    }
}
