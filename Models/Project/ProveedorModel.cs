using System.Text.Json.Serialization;

namespace PadronProveedoresAPI.Models.Project
{
    public class ProveedorModel
    {
        public class Proveedor
        {
            public int IdProveedor { get; set; }
            public string? Rfc { get; set; }
            public string? RazonSocial { get; set; }
            public DateTime FechaAlta { get; set; }
            public bool Activo { get; set; }

            //[JsonConverter(typeof(PadronProveedoresAPI.Utilities.Utilidades.StringConverter))]
            //public string? NumeroProveedor { get; set; }
            public List<DatosProveedor>? DatosProveedores { get; set; }
        }

        public class DatosProveedor
        {
            public int IdProveedorDatos { get; set; }

            [JsonConverter(typeof(PadronProveedoresAPI.Utilities.Utilidades.StringConverter))]
            public string? NumeroProveedor { get; set; }

            public string? Estratificacion { get; set; }
            public string? TipoEntidad { get; set;  }

            [JsonConverter(typeof(PadronProveedoresAPI.Utilities.Utilidades.StringConverter))]
            public string? NumeroRefrendo { get; set; }
            public DateTime? FechaRefrendo { get; set; }
            public string? TipoProveedor { get; set; }
            public string? Observaciones { get; set; }
            public string? SitioWeb { get; set; }
            public bool EsRepse { get; set; }
            public DateTime? FechaRepse { get; set; }
            public bool TieneDocumentos { get; set; }
            public DateTime FechaAlta { get; set; }
            public bool Activo { get; set; }
            public List<Domicilio>? Domicilio { get; set; }
            public List<Representantes>? Representantes { get; set; }
            public List<Contactos>? Contactos { get; set; }
            public List<GirosComerciales>? GirosComerciales { get; set; }
            public List<Inactivo>? Inactivos { get; set; }
            public List<Documento>? Documentos { get; set; }
        }

        public class Domicilio
        {
            public string? Calle { get; set; }
            public int? IdEstado { get; set; }
            public string? Estado { get; set; }
            public int? IdMunicipio { get; set; }
            public string? Municipio { get; set; }
            public int IdColonia { get; set; }
            public string? Colonia { get; set; }
            public int IdCodigoPostal { get; set; }
            public string? CodigoPostal { get; set; }
            public string? DireccionInternacional { get; set; }
            public string? Nota { get; set; }
        }

        public class Representantes
        {
            public string? Nombre { get; set; }
            public string? Tipo { get; set; }
            public string? Nota { get; set; }
            public bool Activo { get; set; }
        }

        public class Contactos
        {
            public string? Contacto { get; set; }
            public string? Nota { get; set; }
            public bool Activo { get; set; }
        }

        public class GirosComerciales
        {
            public string? GiroComercial { get; set; }
            public bool? Activo { get; set; }
        }

        public class Inactivo
        {
            public string? Observacion { get; set; }
            public DateTime FechaInicio { get; set; }
            public DateTime FechaFin { get; set; }
            public DateTime FechaDiarioOficialFederacion { get; set; }
        }

        public class Documento
        {
            public int IdDocumentos { get; set; }
            public string? NombreDocumento { get; set; }
            public string? Nota { get; set; }
        }

    }
}
