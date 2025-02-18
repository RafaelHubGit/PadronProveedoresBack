using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PadronProveedoresAPI.Models.Entities
{
    public class CatTipoContactoModel
    {
        [Key]
        [Column("IdTipoContacto")]
        public int IdTipoContacto { get; set; }

        [Column("TipoContacto")]
        [Required(ErrorMessage = "El tipo de contacto es requerido")]
        [StringLength(50)]
        public string? TipoContacto { get; set; }

        [Column("IdUsuarioAlta")]
        public int IdUsuarioAlta { get; set; }

        [Column("FechaAlta")]
        public DateTime FechaAlta { get; set; }

        [Column("IdUsuarioModificacion")]
        public int? IdUsuarioModificacion { get; set; }

        [Column("FechaModificacion")]
        public DateTime? FechaModificacion { get; set; }

        [Column("Activo")]
        public bool Activo { get; set; }
    }
}
