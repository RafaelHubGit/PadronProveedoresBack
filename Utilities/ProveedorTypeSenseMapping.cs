using System.Diagnostics;
using System.Text.Json;

//using Newtonsoft.Json;
using PadronProveedoresAPI.Models.Project;
using static PadronProveedoresAPI.Models.Project.ProveedorModel;

namespace PadronProveedoresAPI.Utilities
{
    public class ProveedorTypeSenseMapping
    {
        //Recibe una lista de proveedores y los transforma a TypeSense Model
        public List<ProveedorTypeSenseSchema> MappingSchemaTypeSense(List<Proveedor> proveedores)
        {
            var proveedoresTP = proveedores.Select(p => ProveedorToSchemaTS(p)).ToList();

            return proveedoresTP;
        }

        //Recibe un proveedor y lo transforma a TypeSense Model
        public ProveedorTypeSenseSchema ProveedorToSchemaTS(Proveedor proveedor)
        {
            var TSMapped = new ProveedorTypeSenseSchema();
            try
            {

                TSMapped.idProveedor = proveedor.IdProveedor;
                TSMapped.rfc = proveedor.Rfc;
                TSMapped.razonSocial = proveedor.RazonSocial;
                TSMapped.fechaAlta = proveedor.FechaAlta.ToString("yyyy-MM-dd");
                TSMapped.activo = proveedor.Activo;
                TSMapped.numeroProveedor = proveedor.NumeroProveedor ?? string.Empty;

                TSMapped.datosProveedores = new DatosProveedoresTypeSenseSchema();

                TSMapped.datosProveedores.numeroRefrendo = (proveedor.DatosProveedores?.Select(dp => dp.NumeroRefrendo?.ToString()).ToArray()) ?? Array.Empty<string>();
                TSMapped.datosProveedores.tipoProveedor = proveedor.DatosProveedores?
                    .Select(dp => dp.TipoProveedor)
                    .Distinct()
                    .Select(TipoProveedorDescripcion)
                    .ToArray() ?? Array.Empty<string>();
                TSMapped.datosProveedores.observaciones = proveedor.DatosProveedores?
                    .Select(dp => dp.Observaciones)
                    .Distinct()
                    .ToArray() ?? Array.Empty<string>();
                TSMapped.datosProveedores.esRepse = proveedor.DatosProveedores?
                    .Select(dp => dp.EsRepse)
                    .Distinct()
                    .ToArray() ?? Array.Empty<bool>();
                TSMapped.datosProveedores.tieneDocumentos = proveedor.DatosProveedores?
                    .Select( dp => dp.TieneDocumentos )
                    .Distinct()
                    .ToArray() ?? Array.Empty<bool>();

                TSMapped.datosProveedores.domicilio = new DomicilioTypeSenseSchema();

                TSMapped.datosProveedores.domicilio.calle = proveedor.DatosProveedores?.FirstOrDefault()?.Domicilio?.FirstOrDefault()?.Calle;
                TSMapped.datosProveedores.domicilio.estado = proveedor.DatosProveedores?.FirstOrDefault()?.Domicilio?.FirstOrDefault()?.Estado;
                TSMapped.datosProveedores.domicilio.municipio = proveedor.DatosProveedores?.FirstOrDefault()?.Domicilio?.FirstOrDefault()?.Municipio;
                TSMapped.datosProveedores.domicilio.colonia = proveedor.DatosProveedores?.FirstOrDefault()?.Domicilio?.FirstOrDefault()?.Colonia;
                TSMapped.datosProveedores.domicilio.codigoPostal = proveedor.DatosProveedores?.FirstOrDefault()?.Domicilio?.FirstOrDefault()?.CodigoPostal;
                TSMapped.datosProveedores.domicilio.direccionInternacional = proveedor.DatosProveedores?.FirstOrDefault()?.Domicilio?.FirstOrDefault()?.DireccionInternacional;

                //TSMapped.datosProveedores.representantes = new RepresentanteTypeSenseSchema();
                //TSMapped.datosProveedores.contacto = new ContactoTypeSenseSchema();
                //TSMapped.datosProveedores.girosComerciales = new GirosComercialesTypeSenseSchema();
                //TSMapped.datosProveedores.documentos = new DocumentosTypeSenseSchema();
                TSMapped.datosProveedores.inactivo = new InactivoTypeSenseSchema();

                TSMapped.datosProveedores.representantes = proveedor.DatosProveedores?
                        .Where(dp => dp.Representantes != null)
                        .SelectMany(dp => dp.Representantes)
                        .Select(r => r.Representante)
                        .Distinct()
                        .ToArray() ?? Array.Empty<string>();

                TSMapped.datosProveedores.contacto = proveedor.DatosProveedores?
                        .Where(dp => dp.Contactos != null)
                        .SelectMany(dp => dp.Contactos)
                        .Select(c => c.Contactos)
                        .Distinct()
                        .ToArray() ?? Array.Empty<string>();

                TSMapped.datosProveedores.girosComerciales = proveedor.DatosProveedores?
                        .Where(dp => dp.GirosComerciales != null)
                        .SelectMany(dp => dp.GirosComerciales)
                        .Select(gc => gc.GiroComercial)
                        .Distinct()
                        .ToArray() ?? Array.Empty<string>();

                TSMapped.datosProveedores.documentos = proveedor.DatosProveedores?
                        .Where(dp => dp.Documentos != null)
                        .SelectMany(dp => dp.Documentos)
                        .Select(d => d.NombreDocumento)
                        .Distinct()
                        .ToArray() ?? Array.Empty<string>();

                var inactivos = proveedor.DatosProveedores?
                        .Where( dp => dp.Inactivos != null )
                        .SelectMany( dp => dp.Inactivos )
                        .FirstOrDefault();

                TSMapped.datosProveedores.inactivo = new InactivoTypeSenseSchema
                {
                    observacion = inactivos?.Observacion ?? string.Empty,
                    fechaInicio = inactivos?.FechaInicio.ToString("yyyy-MM-dd") ?? string.Empty,
                    fechaFin = inactivos?.FechaFin.ToString("yyyy-MM-dd") ?? string.Empty,
                    fechaDiarioOficialFederacion = inactivos?.FechaDiarioOficialFederacion.ToString("yyyy-MM-dd") ?? string.Empty
                };


                //var TSMappedJson = JsonSerializer.Serialize(TSMapped);
                return TSMapped;
            }
            catch (NullReferenceException ex)
            {
                Debug.WriteLine($"Error de referencia nula: {ex.Message}");
                throw new Exception("Error de referencia nula", ex);
            }
        }

        public class ProveedorTypeSenseSchema
        {
            public int idProveedor { get; set; }
            public string? rfc { get; set; }
            public string? razonSocial { get; set; }
            public string fechaAlta { get; set; }
            public bool activo { get; set; }
            public string numeroProveedor { get; set; }
            public DatosProveedoresTypeSenseSchema? datosProveedores { get; set; }
        }

        public class DatosProveedoresTypeSenseSchema
        {
            public string[]? numeroRefrendo { get; set; }
            public string[]? tipoProveedor { get; set; }
            public string[]? observaciones { get; set; }
            public bool[]? esRepse { get; set; }
            public bool[]? tieneDocumentos { get; set; }
            public DomicilioTypeSenseSchema? domicilio { get; set; }
            //public RepresentanteTypeSenseSchema? representantes { get; set; }
            public string[]? representantes { get; set; }
            //public ContactoTypeSenseSchema? contacto { get; set; }
            public string[]? contacto { get; set; }
            //public GirosComercialesTypeSenseSchema? girosComerciales { get; set; }
            public string[]? girosComerciales { get; set; }
            public string[]? documentos { get; set; }
            public InactivoTypeSenseSchema? inactivo { get; set; }
        }

        public class DomicilioTypeSenseSchema
        {
            public string? calle { get; set; }
            public string? estado { get; set; }
            public string? municipio { get; set; }
            public string? colonia { get; set; }
            public string? codigoPostal { get; set; }
            public string? direccionInternacional { get; set; }
        }

        public class RepresentanteTypeSenseSchema
        {
            public string[]? representante { get; set; }
        }

        public class ContactoTypeSenseSchema
        {
            public string[]? contactos { get; set; }
        }

        public class GirosComercialesTypeSenseSchema
        {
            public string[]? giroComercial { get; set; }
        }

        public class DocumentosTypeSenseSchema
        {
            public string[]? nombreDocumento { get; set; }
        }

        public class InactivoTypeSenseSchema
        {
            public string? observacion { get; set; }
            public string? fechaInicio { get; set; }
            public string? fechaFin { get; set; }
            public string? fechaDiarioOficialFederacion { get; set; }
        }

        private static string TipoProveedorDescripcion(string tipoProveedor)
        {
            switch (tipoProveedor.ToUpper())
            {
                case "C":
                    return "Compras";
                case "F":
                    return "FUNCION";
                case "I":
                    return "ILUSTRADO";
                default:
                    return tipoProveedor;
            }
        }
    }
}
