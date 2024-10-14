using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PadronProveedoresAPI.Models.Entities
{
    public class CatCodigosPostalesModel
    {
        [Key]
        [Column("IdCodigoPostal")]
        public int IdCodigoPostal { get; set; }

        [Column("CodigoPostal")]
        [Required(ErrorMessage = "El código postal es requerido")]
        [StringLength(10)]
        public required string CodigoPostal { get; set; }

        [Column("IdColonia")]
        [ForeignKey("IdColonia")]
        public int IdColonia { get; set; }

    }
}
