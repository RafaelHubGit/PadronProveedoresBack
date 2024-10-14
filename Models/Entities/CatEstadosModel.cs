using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PadronProveedoresAPI.Models.Entities
{
    public class CatEstadosModel
    {
        [Key]
        [Column("IdEstado")]
        public int IdEstado { get; set; }

        [Column("Estado")]
        [Required(ErrorMessage = "El estado es requerido")]
        [StringLength(100)]
        public required string Estado { get; set; }

        [Column("Activo")]
        public bool Activo { get; set; }
    }
}
