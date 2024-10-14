using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PadronProveedoresAPI.Models.Entities
{
    public class GenRepresentanteModel
    {
        [Key]
        [Column("IdRepresentante")]
        public int IdRepresentante { get; set; }

        [Column("IdProveedorDatos")]
        public int IdProveedorDatos { get; set; }
        [ForeignKey("IdProveedorDatos")]

        [Column("Tipo")]
        [Required(ErrorMessage = "El tipo de representante es requerido")]
        [StringLength(20)]
        [EnumDataType(typeof(TipoRepresentante))]
        public required string Tipo { get; set; }

        [Column("Representante")]
        [Required(ErrorMessage = "El representante es requerido")]
        [StringLength(200)]
        public required string Representante { get; set; }

        [Column("Nota")]
        [StringLength(1200)]
        public string? Nota { get; set; }

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

    public enum TipoRepresentante
    {
        Legal,
        Ventas
    }
}
