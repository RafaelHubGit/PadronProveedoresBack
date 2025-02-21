using PadronProveedoresAPI.Utilities;

namespace PadronProveedoresAPI.Services.Project
{
    public class FieldDefinitions
    {
        public static readonly List<FieldDefinition> ProveedorFields = new List<FieldDefinition>
        {
            new FieldDefinition { name = "idProveedor", type = "int32", facet = false, optional = false, sort = true },
            new FieldDefinition { name = "rfc", type = "string", facet = true, optional = false, sort = true, infix= true },
            new FieldDefinition { name = "razonSocial", type = "string", facet = false, optional = false, sort = true, infix= true },
            new FieldDefinition { name = "fechaAlta", type = "string", facet = false, optional = false },
            new FieldDefinition { name = "activo", type = "bool", facet = true, optional = false, sort = true },
            new FieldDefinition { name = "numeroProveedor", type = "string", facet = true, optional = false, sort = true },

            new FieldDefinition { name = "numeroRefrendo", type = "string[]", facet = true, optional = true },
            new FieldDefinition { name = "tipoProveedor", type = "string[]", facet = true, optional = true },
            new FieldDefinition { name = "observaciones", type = "string[]", facet = false, optional = true, infix= true },
            new FieldDefinition { name = "esRepse", type = "bool[]", facet = true, optional = true },
            new FieldDefinition { name = "tieneDocumentos", type = "bool[]", facet = true, optional = true },

            new FieldDefinition { name = "Direccion", type = "string", facet = true, optional = true},
            new FieldDefinition { name = "DreccionInternacional", type = "string", facet = false, optional = true },

            new FieldDefinition { name = "representantes", type = "string[]", facet = true, optional = true },

            new FieldDefinition { name = "contactos", type = "string[]", facet = false, optional = true },

            new FieldDefinition { name = "girosComerciales", type = "string[]", facet = true, optional = true },

            new FieldDefinition { name = "documentos", type = "string[]", facet = true, optional = true },

            new FieldDefinition { name = "inactivoObservacion", type = "string", facet = false, optional = true },
            new FieldDefinition { name = "inactivoFechaInicio", type = "string", facet = false, optional = true },
            new FieldDefinition { name = "inactivoFechaFin", type = "string", facet = false, optional = true },
            new FieldDefinition { name = "inactivoFechaDOF", type = "string", facet = false, optional = true }
        };
    }
}
