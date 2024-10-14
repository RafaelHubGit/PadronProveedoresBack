using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PadronProveedoresAPI.Models.Entities
{
    public class CatGiroComercialModel
    {
        [Key]
        [Column("IdGiroComercial")]
        public int IdGiroComercial { get; set; }

        [Column("GiroComercial")]
        [Required(ErrorMessage = "El giro comercial es requerido")]
        [StringLength(255)]
        public string? GiroComercial { get; set; }

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
