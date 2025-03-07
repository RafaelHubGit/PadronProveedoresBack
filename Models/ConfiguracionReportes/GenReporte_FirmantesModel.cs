using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PadronProveedoresAPI.Models.ConfiguracionReportes
{
    public class GenReporte_FirmantesModel
    {
        [Key]
        [Column("idReporteFirmantes")]
        public int IdReporteFirmantes { get; set; }

        [Column("idReportesFirmantes")]
        public int IdReportesFirmantes { get; set; }

        [Column("identificadorReporte")]
        [Required(ErrorMessage = "El identificador del reporte es requerido")]
        [StringLength(255)]
        public string? IdentificadorReporte { get; set; }

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
