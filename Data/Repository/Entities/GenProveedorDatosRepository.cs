using Microsoft.EntityFrameworkCore;
using PadronProveedoresAPI.Models.Entities;

namespace PadronProveedoresAPI.Data.Repository.Entities
{
    public class GenProveedorDatosRepository
    {
        private readonly StoreContext _context;

        public GenProveedorDatosRepository(StoreContext context)
        {
            _context = context;
        }

        public IEnumerable<GenProveedorDatosModel> ObtenerProveedorDatos()
        {
            return _context.GenProveedorDatosModel
                .FromSqlRaw("EXEC sp_ObtenerProveedorDatos")
                .ToList();
        }

        public GenProveedorDatosModel ObtenerProveedorDatosPorId(int idProveedorDatos)
        {
            return _context.GenProveedorDatosModel
                .FromSqlRaw("EXEC sp_ObtenerProveedorDatosPorId @IdProveedorDatos = {0}", idProveedorDatos)
                .FirstOrDefault();
        }

        public void CrearProveedorDatos(GenProveedorDatosModel proveedorDatos)
        {
            _context.Database.ExecuteSqlRaw("EXEC sp_CrearProveedorDatos " +
                "@IdProveedor = {0}, " +
                "@NumeroProveedor = {1}, " +
                "@NumeroRefrendo = {2}, " +
                "@FechaRefrendo = {3}, " +
                "@TipoProveedor = {4}, " +
                "@Observaciones = {5}, " +
                "@SitioWeb = {6}, " +
                "@EsRepse = {7}, " +
                "@FechaRepse = {8}, " +
                "@TieneDocumentos = {9}, " +
                "@FechaRegistro = {10}, " +
                "@IdUsuarioAlta = {11}",
                proveedorDatos.IdProveedor,
                proveedorDatos.NumeroProveedor,
                proveedorDatos.NumeroRefrendo,
                proveedorDatos.FechaRefrendo,
                proveedorDatos.TipoProveedor,
                proveedorDatos.Observaciones,
                proveedorDatos.SitioWeb,
                proveedorDatos.EsRepse,
                proveedorDatos.FechaRepse,
                proveedorDatos.TieneDocumentos,
                proveedorDatos.FechaRegistro,
                proveedorDatos.IdUsuarioAlta);
        }

        public void ActualizarProveedorDatos(GenProveedorDatosModel proveedorDatos)
        {
            _context.Database.ExecuteSqlRaw("EXEC sp_ActualizarProveedorDatos " +
                "@IdProveedorDatos = {0}, " +
                "@IdProveedor = {1}, " +
                "@NumeroProveedor = {2}, " +
                "@NumeroRefrendo = {3}, " +
                "@FechaRefrendo = {4}, " +
                "@TipoProveedor = {5}, " +
                "@Observaciones = {6}, " +
                "@SitioWeb = {7}, " +
                "@EsRepse = {8}, " +
                "@FechaRepse = {9}, " +
                "@TieneDocumentos = {10}, " +
                "@FechaRegistro = {11}, " +
                "@IdUsuarioModificacion = {12}, " +
                "@Activo = {13}",
                proveedorDatos.IdProveedorDatos,
                proveedorDatos.IdProveedor,
                proveedorDatos.NumeroProveedor,
                proveedorDatos.NumeroRefrendo,
                proveedorDatos.FechaRefrendo,
                proveedorDatos.TipoProveedor,
                proveedorDatos.Observaciones,
                proveedorDatos.SitioWeb,
                proveedorDatos.EsRepse,
                proveedorDatos.FechaRepse,
                proveedorDatos.TieneDocumentos,
                proveedorDatos.FechaRegistro,
                proveedorDatos.IdUsuarioModificacion,
                proveedorDatos.Activo);
        }

        public void EliminarProveedorDatosLogico(int idProveedorDatos, int idUsuarioModificacion)
        {
            _context.Database.ExecuteSqlRaw("EXEC sp_EliminarProveedorDatosLogico " +
                "@IdProveedorDatos = {0}, " +
                "@IdUsuarioModificacion = {1}",
                idProveedorDatos,
                idUsuarioModificacion);
        }

        public void EliminarProveedorDatosFisico(int idProveedorDatos)
        {
            _context.Database.ExecuteSqlRaw("EXEC sp_EliminarProveedorDatosFisico " +
                "@IdProveedorDatos = {0}",
                idProveedorDatos);
        }
    }
}
