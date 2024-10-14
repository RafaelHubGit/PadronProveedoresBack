using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PadronProveedoresAPI.Models.Entities
{
    public class GenProveedorDatosModel
    {
        [Key]
        [Column("IdProveedorDatos")]
        public int IdProveedorDatos { get; set; }

        [Column("IdProveedor")]
        public int IdProveedor { get; set; }
        [ForeignKey("IdProveedor")]

        [Column("NumeroProveedor")]
        public int NumeroProveedor { get; set; }

        [Column("NumeroRefrendo")]
        public short? NumeroRefrendo { get; set; }

        [Column("FechaRefrendo")]
        public DateTime? FechaRefrendo { get; set; }

        [Column("TipoProveedor")]
        [StringLength(50)]
        public required string TipoProveedor { get; set; }

        [Column("Observaciones")]
        [StringLength(1000)]
        public string? Observaciones { get; set; }

        [Column("SitioWeb")]
        [StringLength(255)]
        public string? SitioWeb { get; set; }

        [Column("EsRepse")]
        public bool? EsRepse { get; set; }

        [Column("FechaRepse")]
        public DateTime? FechaRepse { get; set; }

        [Column("TieneDocumentos")]
        public bool TieneDocumentos { get; set; }

        [Column("FechaRegistro")]
        public DateTime? FechaRegistro { get; set; }

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
