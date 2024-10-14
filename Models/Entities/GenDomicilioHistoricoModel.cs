using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PadronProveedoresAPI.Models.Entities
{
    public class GenDomicilioHistoricoModel
    {
        [Key]
        [Column("IdDomicilioHistorico")]
        public int IdDomicilioHistorico { get; set; }

        [Column("IdProveedorDatos")]
        public int IdProveedorDatos { get; set; }
        [ForeignKey("IdProveedorDatos")]

        [Column("Domicilio")]
        [Required(ErrorMessage = "El domicilio es requerido")]
        [StringLength(1500)]
        public required string Domicilio { get; set; }
    }
}
