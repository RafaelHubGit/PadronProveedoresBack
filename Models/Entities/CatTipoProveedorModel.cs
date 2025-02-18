using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PadronProveedoresAPI.Models.Entities
{
    public class CatTipoProveedorModel
    {
        [Key]
        [Column("IdTipoProveedor")]
        public int IdTipoProveedor { get; set; }

        [Column("TipoProveedor")]
        [Required(ErrorMessage = "El tipo proveedor es requerido")]
        [StringLength(50)]
        public string TipoProveedor { get; set; }

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
