using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PadronProveedoresAPI.Models.ConfiguracionReportes
{
    public class CatReportesLeyendasModel
    {
        [Key]
        [Column("idReportesLeyendas")]
        public int IdReportesLeyendas { get; set; }

        [Column("leyenda")]
        [Required(ErrorMessage = "La leyenda es requerida")]
        [StringLength(255)]
        public string? Leyenda { get; set; }

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
