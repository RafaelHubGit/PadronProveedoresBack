using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PadronProveedoresAPI.Models.ConfiguracionReportes
{
    public class CatReportesFirmantesModel
    {
        [Key]
        [Column("idReportesFirmantes")]
        public int IdReportesFirmantes { get; set; }

        [Column("nombre")]
        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(255)]
        public string? Nombre { get; set; }

        [Column("cargo")]
        [Required(ErrorMessage = "El cargo es requerido")]
        [StringLength(255)]
        public string? Cargo { get; set; }

        [Column("prefijo")]
        [StringLength(50)]
        public string? Prefijo { get; set; }

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
