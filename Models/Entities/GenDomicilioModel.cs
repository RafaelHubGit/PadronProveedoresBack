using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace PadronProveedoresAPI.Models.Entities
{
    public class GenDomicilioModel
    {
        [Key]
        [Column("IdDomicilio")]
        public int IdDomicilio { get; set; }

        [Column("IdProveedorDatos")]
        public int IdProveedorDatos { get; set; }
        [ForeignKey("IdProveedorDatos")]

        [Column("Calle")]
        [Required(ErrorMessage = "La calle es requerida")]
        [StringLength(1500)]
        [DefaultValue("No especificado")]
        public required string Calle { get; set; }

        [Column("IdEstado")]
        public int IdEstado { get; set; }
        [ForeignKey("IdEstado")]

        [Column("IdMunicipio")]
        public int IdMunicipio { get; set; }
        [ForeignKey("IdMunicipio")]

        [Column("IdColonia")]
        public int IdColonia { get; set; }
        [ForeignKey("IdColonia")]

        [Column("IdCodigoPostal")]
        public int IdCodigoPostal { get; set; }
        [ForeignKey("IdCodigoPostal")]

        [Column("DireccionInternacional")]
        [StringLength(255)]
        public string? DireccionInternacional { get; set; }

        [Column("Nota")]
        [StringLength(255)]
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
}
