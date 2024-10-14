using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PadronProveedoresAPI.Models.Entities
{
    public class GenDocumentosModel
    {
        [Key]
        [Column("IdDocumentos")]
        public int IdDocumentos { get; set; }

        [Column("IdProveedorDatos")]
        public int IdProveedorDatos { get; set; }
        [ForeignKey("IdProveedorDatos")]

        [Column("NombreDocumento")]
        [Required(ErrorMessage = "El nombre del documento es requerido")]
        [StringLength(100)]
        public required string NombreDocumento { get; set; }

        [Column("TipoDocumento")]
        [Required(ErrorMessage = "El tipo de documento es requerido")]
        [StringLength(50)]
        [EnumDataType(typeof(TipoDocumento))]
        public required string Tipo { get; set; }

        [Column("FechaCarga")]
        public DateTime FechaCarga { get; set; }

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

    public enum TipoDocumento
    {
        // Agrega los tipos de documentos relevantes
        Factura,
        Contrato,
        Certificado,
        Otro
    }
}
