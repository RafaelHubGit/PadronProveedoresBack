using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PadronProveedoresAPI.Models.Entities
{
    public class CatEstatusProveedorBloqueadoModel
    {
        [Key]
        [Column("IdEstatusProveedorBloqueado")]
        public int IdEstatusProveedorBloqueado { get; set; }

        [Column("Estatus")]
        [Required(ErrorMessage = "El estatus es requerido")]
        [StringLength(15)]
        public string? Estatus { get; set; }

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
