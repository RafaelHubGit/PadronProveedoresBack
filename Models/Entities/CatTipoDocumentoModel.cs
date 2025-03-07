using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PadronProveedoresAPI.Models.Entities
{
    public class CatTipoDocumentoModel
    {
        [Key]
        [Column("IdTipoDocumento")]
        public int IdTipoDocumento { get; set; }

        [Column("Nombre")]
        [Required(ErrorMessage = "El nombre del documento es requerido")]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Column("Descripcion")]
        [StringLength(250)]
        public string? Descripcion { get; set; }

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
