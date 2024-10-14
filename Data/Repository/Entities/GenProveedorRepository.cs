using Microsoft.EntityFrameworkCore;
using PadronProveedoresAPI.Models.Entities;

namespace PadronProveedoresAPI.Data.Repository.Entities
{
    public class GenProveedorRepository
    {

        private readonly StoreContext _context;

        public GenProveedorRepository(StoreContext context)
        {
            _context = context;
        }

        public IEnumerable<GenProveedorModel> ObtenerGenProveedor()
        {
            return _context.GenProveedorModel
                .FromSqlRaw("EXEC sp_ObtenerProveedores")
                .ToList();
        }

        public GenProveedorModel ObtenerProveedorPorId(int idProveedor)
        {
            return _context.GenProveedorModel
                .FromSqlRaw("EXEC sp_ObtenerProveedorPorId @IdProveedor = {0}", idProveedor)
                .FirstOrDefault();
        }

        public void CrearProveedor(GenProveedorModel proveedor)
        {
            _context.Database.ExecuteSqlRaw("EXEC sp_CrearProveedor @Rfc = {0}, @RazonSocial = {1}, @IdUsuarioAlta = {2}",
                proveedor.Rfc, proveedor.RazonSocial, proveedor.IdUsuarioAlta);
        }

        public void ActualizarProveedor(GenProveedorModel proveedor)
        {
            _context.Database.ExecuteSqlRaw("EXEC sp_ActualizarProveedor @IdProveedor = {0}, @Rfc = {1}, @RazonSocial = {2}, @IdUsuarioModificacion = {3}, @Activo = {4}",
                proveedor.Id, proveedor.Rfc, proveedor.RazonSocial, proveedor.IdUsuarioModificacion, proveedor.Activo);
        }

        public void EliminarProveedorLogico(int idProveedor, int idUsuarioModificacion)
        {
            _context.Database.ExecuteSqlRaw("EXEC sp_EliminarProveedorLogico @IdProveedor = {0}, @IdUsuarioModificacion = {1}",
                idProveedor, idUsuarioModificacion);
        }

        public void EliminarProveedorFisico(int idProveedor)
        {
            _context.Database.ExecuteSqlRaw("EXEC sp_EliminarProveedorFisico @IdProveedor = {0}", idProveedor);
        }
    }
}
