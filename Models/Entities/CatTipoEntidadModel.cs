using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PadronProveedoresAPI.Models.Entities
{
    public class CatTipoEntidadModel
    {
        [Key]
        [Column("IdTipoEntidad")]
        public int IdTipoEntidad { get; set; }

        [Column("TipoEntidad")]
        [Required(ErrorMessage = "El tipo de entidad es requerido")]
        [StringLength(20)]
        public string? TipoEntidad { get; set; }

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
