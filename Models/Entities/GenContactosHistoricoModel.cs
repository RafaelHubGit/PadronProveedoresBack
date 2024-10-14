using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PadronProveedoresAPI.Models.Entities
{
    public class GenContactosHistoricoModel
    {
        [Key]
        [Column("IdContactoHistorico")]
        public int IdContactoHistorico { get; set; }

        [Column("IdProveedorDatos")]
        public int IdProveedorDatos { get; set; }
        [ForeignKey("IdProveedorDatos")]

        [Column("Tipo")]
        [Required(ErrorMessage = "El tipo de contacto es requerido")]
        [StringLength(20)]
        [EnumDataType(typeof(TipoContactoHistorico))]
        public required string Tipo { get; set; }

        [Column("Contactos")]
        [Required(ErrorMessage = "El contacto es requerido")]
        [StringLength(1500)]
        public required string Contactos { get; set; }
    }

    public enum TipoContactoHistorico
    {
        Telefono,
        Mail,
        Fax,
        Celular
    }
}
