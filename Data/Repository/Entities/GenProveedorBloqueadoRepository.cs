using Microsoft.EntityFrameworkCore;
using PadronProveedoresAPI.Models.Entities;

namespace PadronProveedoresAPI.Data.Repository.Entities
{
    public class GenProveedorBloqueadoRepository
    {
        private readonly StoreContext _context;

        public GenProveedorBloqueadoRepository(StoreContext context)
        {
            _context = context;
        }

        public IEnumerable<GenProveedorBloqueadoModel> ObtenerProveedoresBloqueados()
        {
            return _context.GenProveedorBloqueadoModel
                .FromSqlRaw("EXEC sp_ObtenerProveedoresBloqueados")
                .ToList();
        }

        public GenProveedorBloqueadoModel ObtenerProveedorBloqueadoPorId(int idProveedorBloqueado)
        {
            return _context.GenProveedorBloqueadoModel
                .FromSqlRaw("EXEC sp_ObtenerProveedorBloqueadoPorId @IdProveedorBloqueado = {0}", idProveedorBloqueado)
                .FirstOrDefault();
        }

        public void CrearProveedorBloqueado(GenProveedorBloqueadoModel proveedorBloqueado)
        {
            _context.Database.ExecuteSqlRaw("EXEC sp_CrearProveedorBloqueado " +
                "@IdProveedor = {0}, " +
                "@Observacion = {1}, " +
                "@FechaInicio = {2}, " +
                "@FechaFin = {3}, " +
                "@FechaDiarioOficialFederacion = {4}, " +
                "@IdUsuarioAlta = {5}",
                proveedorBloqueado.IdProveedor,
                proveedorBloqueado.Observacion,
                proveedorBloqueado.FechaInicio,
                proveedorBloqueado.FechaFin,
                proveedorBloqueado.FechaDiarioOficialFederacion,
                proveedorBloqueado.IdUsuarioAlta);
        }

        public void ActualizarProveedorBloqueado(GenProveedorBloqueadoModel proveedorBloqueado)
        {
            _context.Database.ExecuteSqlRaw("EXEC sp_ActualizarProveedorBloqueado " +
                "@IdProveedorBloqueado = {0}, " +
                "@IdProveedor = {1}, " +
                "@Observacion = {2}, " +
                "@FechaInicio = {3}, " +
                "@FechaFin = {4}, " +
                "@FechaDiarioOficialFederacion = {5}, " +
                "@IdUsuarioModificacion = {6}, " +
                "@Activo = {7}",
                proveedorBloqueado.IdProveedorBloqueado,
                proveedorBloqueado.IdProveedor,
                proveedorBloqueado.Observacion,
                proveedorBloqueado.FechaInicio,
                proveedorBloqueado.FechaFin,
                proveedorBloqueado.FechaDiarioOficialFederacion,
                proveedorBloqueado.IdUsuarioModificacion,
                proveedorBloqueado.Activo);
        }

        public void EliminarProveedorBloqueadoLogico(int idProveedorBloqueado, int idUsuarioModificacion)
        {
            _context.Database.ExecuteSqlRaw("EXEC sp_EliminarProveedorBloqueadoLogico " +
                "@IdProveedorBloqueado = {0}, " +
                "@IdUsuarioModificacion = {1}",
                idProveedorBloqueado,
                idUsuarioModificacion);
        }

        public void EliminarProveedorBloqueadoFisico(int idProveedorBloqueado)
        {
            _context.Database.ExecuteSqlRaw("EXEC sp_EliminarProveedorBloqueadoFisico " +
                "@IdProveedorBloqueado = {0}",
                idProveedorBloqueado);
        }
    }
}
