using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PadronProveedoresAPI.Models.Entities
{
    public class CatEstratificacionModel
    {
        [Key]
        [Column("IdEstratificacion")]
        public int IdEstratificacion { get; set; }

        [Column("Estratificacion")]
        [Required(ErrorMessage = "La estratificación es requerida")]
        [StringLength(100)]
        public string? Estratificacion { get; set; }

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
