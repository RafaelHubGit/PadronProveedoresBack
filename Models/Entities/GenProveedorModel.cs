using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PadronProveedoresAPI.Models.Entities
{
    public class GenProveedorModel
    {
        [Key]
        [Column("IdProveedor")]
        public int Id { get; set; }

        [Column("Rfc")]
        [Required(ErrorMessage = "El RFC es requerido")]
        [StringLength(50)]
        public string? Rfc { get; set; }

        [Column("RazonSocial")]
        [Required(ErrorMessage = "La razón social es requerida")]
        [StringLength(255)]
        public string? RazonSocial { get; set; }

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
