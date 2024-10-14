using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PadronProveedoresAPI.Models.Entities
{
    public class GenProveedorBloqueadoModel
    {
        [Key]
        [Column("IdProveedorBloqueado")]
        public int IdProveedorBloqueado { get; set; }

        [Column("IdProveedor")]
        public int IdProveedor { get; set; }
        [ForeignKey("IdProveedor")]

        [Column("Observacion")]
        [StringLength(2000)]
        public string? Observacion { get; set; }

        [Column("FechaInicio")]
        public DateTime FechaInicio { get; set; }

        [Column("FechaFin")]
        public DateTime FechaFin { get; set; }

        [Column("FechaDiarioOficialFederacion")]
        public DateTime? FechaDiarioOficialFederacion { get; set; }

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
