using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PadronProveedoresAPI.Models.Entities
{
    public class CatGeneroModel
    {
        [Key]
        [Column("IdGenero")]
        public int IdGenero { get; set; }

        [Column("Genero")]
        [Required(ErrorMessage = "El género es requerido")]
        [StringLength(20)]
        public string? Genero { get; set; }

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
