using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PadronProveedoresAPI.Models.ConfiguracionReportes
{
    public class CatReportesLogosModel
    {
        [Key]
        [Column("idReportesLogos")]
        public int IdReportesLogos { get; set; }

        [Column("nombre")]
        [StringLength(255)]
        public string? Nombre { get; set; }

        [Column("descripcion")]
        [StringLength(255)]
        public string? Descripcion { get; set; }

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
