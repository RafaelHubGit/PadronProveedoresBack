using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PadronProveedoresAPI.Models.Entities
{
    public class CatMatrizArticulosFraccionesModel
    {
        [Key]
        [Column("IdMatrizArticulosFracciones")]
        public int IdMatrizArticulosFracciones { get; set; }

        [Column("Articulo")]
        [Required(ErrorMessage = "El artículo es requerido")]
        public int Articulo { get; set; }

        [Column("Fraccion")]
        [Required(ErrorMessage = "La fracción es requerida")]
        [StringLength(5)]
        public string? Fraccion { get; set; }

        [Column("Descripcion")]
        [StringLength(1000)]
        public string? Descripcion { get; set; }

        [Column("Nota")]
        [StringLength(1000)]
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
