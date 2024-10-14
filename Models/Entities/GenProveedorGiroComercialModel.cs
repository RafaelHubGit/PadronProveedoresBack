using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PadronProveedoresAPI.Models.Entities
{
    public class GenProveedorGiroComercialModel
    {
        [Key]
        [Column("IdProveedor_GiroComercial")]
        public int IdProveedor_GiroComercial { get; set; }

        [Column("IdProveedorDatos")]
        public int IdProveedorDatos { get; set; }
        [ForeignKey("IdProveedorDatos")]

        [Column("IdGiroComercial")]
        public int IdGiroComercial { get; set; }
        [ForeignKey("IdGiroComercial")]

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
