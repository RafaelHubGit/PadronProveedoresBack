using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PadronProveedoresAPI.Models.Entities
{
    public class GenContactoModel
    {
        [Key]
        [Column("IdContacto")]
        public int IdContacto { get; set; }

        [Column("IdProveedorDatos")]
        public int IdProveedorDatos { get; set; }
        [ForeignKey("IdProveedorDatos")]

        [Column("Tipo")]
        [Required(ErrorMessage = "El tipo de contacto es requerido")]
        [StringLength(20)]
        [EnumDataType(typeof(TipoContacto))]
        public required string Tipo { get; set; }

        [Column("Contactos")]
        [Required(ErrorMessage = "El contacto es requerido")]
        [StringLength(1200)]
        public required string Contactos { get; set; }

        [Column("Nota")]
        [StringLength(800)]
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

    public enum TipoContacto
    {
        Telefono,
        Mail,
        Fax,
        Celular,
        Extension
    }
}
