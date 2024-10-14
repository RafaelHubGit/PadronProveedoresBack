using Newtonsoft.Json;
using PadronProveedoresAPI.Models.Project;
using static PadronProveedoresAPI.Models.Project.ProveedorModel;

namespace PadronProveedoresAPI.Utilities
{
    public class ProveedorTypeSenseMapping
    {

        public List<string> MappingSchemaTypeSense(List<ProveedorModel.Proveedor> proveedores)
        {
            var proveedoresTP = proveedores.Select(p => ProveedorToSchemaTS(p)).ToList();

            return proveedoresTP;
        }

        public string ProveedorToSchemaTS(ProveedorModel.Proveedor proveedor)
        {
            var TSMapped = new ProveedorTypeSenseSchema
            {
                idProveedor = proveedor.IdProveedor,
                rfc = proveedor.Rfc,
                razonSocial = proveedor.RazonSocial,
                fechaAlta = proveedor.FechaAlta.ToString("yyyy-MM-dd"),
                activo = proveedor.Activo,
                numeroProveedor = proveedor.NumeroProveedor,
                datosProveedores = new DatosProveedoresTypeSenseSchema
                {
                    numeroRefrendo = proveedor.DatosProveedores?.Select(dp => dp.NumeroRefrendo).ToArray(),
                    tipoProveedor = proveedor.DatosProveedores?.Select(dp => dp.TipoProveedor).ToArray(),
                    observaciones = proveedor.DatosProveedores?.Select(dp => dp.Observaciones).ToArray(),
                    esRepse = proveedor.DatosProveedores?.FirstOrDefault()?.EsRepse,
                    tieneDocumentos = proveedor.DatosProveedores?.FirstOrDefault()?.TieneDocumentos,
                    domicilio = new DomicilioTypeSenseSchema
                    {
                        calle = proveedor.DatosProveedores?.FirstOrDefault()?.Domicilio?.Calle,
                        estado = proveedor.DatosProveedores?.FirstOrDefault()?.Domicilio?.Estado,
                        municipio = proveedor.DatosProveedores?.FirstOrDefault()?.Domicilio?.Municipio,
                        colonia = proveedor.DatosProveedores?.FirstOrDefault()?.Domicilio?.Colonia,
                        codigoPostal = proveedor.DatosProveedores?.FirstOrDefault()?.Domicilio?.CodigoPostal,
                        direccionInternacional = proveedor.DatosProveedores?.FirstOrDefault()?.Domicilio?.DireccionInternacional
                    },
                    representantes = new RepresentanteTypeSenseSchema
                    {
                        representante = proveedor.DatosProveedores?.SelectMany(dp => dp.Representantes).Select(r => r.Representante).ToArray()
                    },
                    contacto = new ContactoTypeSenseSchema
                    {
                        contactos = proveedor.DatosProveedores?.SelectMany(dp => dp.Contactos).Select(c => c.Contactos).ToArray()
                    },
                    girosComerciales = new GirosComercialesTypeSenseSchema
                    {
                        giroComercial = proveedor.DatosProveedores?.SelectMany(dp => dp.GirosComerciales).Select(g => g.GiroComercial).ToArray()
                    },
                    documentos = new DocumentosTypeSenseSchema
                    {
                        nombreDocumento = proveedor.DatosProveedores?.SelectMany(dp => dp.Documentos).Select(d => d.NombreDocumento).ToArray()
                    },
                    inactivo = new InactivoTypeSenseSchema
                    {
                        observacion = proveedor.DatosProveedores?.SelectMany(dp => dp.Inactivos).Select(i => i.Observacion).FirstOrDefault(),
                        fechaInicio = proveedor.DatosProveedores?.SelectMany(dp => dp.Inactivos).Select(i => i.FechaInicio).FirstOrDefault().ToString("yyyy-MM-dd"),
                        fechaFin = proveedor.DatosProveedores?.SelectMany(dp => dp.Inactivos).Select(i => i.FechaFin).FirstOrDefault().ToString("yyyy-MM-dd"),
                        fechaDiarioOficialFederacion = proveedor.DatosProveedores?.SelectMany(dp => dp.Inactivos).Select(i => i.FechaDiarioOficialFederacion).FirstOrDefault().ToString("yyyy-MM-dd")
                    }
                }
            };

            var TSMappedJson = JsonConvert.SerializeObject(TSMapped);
            return TSMappedJson;
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
            public bool? esRepse { get; set; }
            public bool? tieneDocumentos { get; set; }
            public DomicilioTypeSenseSchema? domicilio { get; set; }
            public RepresentanteTypeSenseSchema? representantes { get; set; }
            public ContactoTypeSenseSchema? contacto { get; set; }
            public GirosComercialesTypeSenseSchema? girosComerciales { get; set; }
            public DocumentosTypeSenseSchema? documentos { get; set; }
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
    }
}
