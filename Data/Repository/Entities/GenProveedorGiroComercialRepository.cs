using Microsoft.EntityFrameworkCore;
using PadronProveedoresAPI.Models.Entities;

namespace PadronProveedoresAPI.Data.Repository.Entities
{
    public class GenProveedorGiroComercialRepository
    {
        private readonly StoreContext _context;

        public GenProveedorGiroComercialRepository(StoreContext context)
        {
            _context = context;
        }

        //public IEnumerable<GenProveedorGiroComercialModel> ObtenerProveedoresGiroComercial()
        //{
        //    return _context.GenProveedor_GiroComercialModel
        //        .FromSqlRaw("EXEC sp_ObtenerProveedoresGiroComercial")
        //    .ToList();
        //}

        //public GenProveedorGiroComercialModel ObtenerProveedorGiroComercialPorId(int idProveedorGiroComercial)
        //{
        //    return _context.GenProveedor_GiroComercialModel
        //        .FromSqlRaw("EXEC sp_ObtenerProveedorGiroComercialPorId @IdProveedor_GiroComercial = {0}", idProveedorGiroComercial)
        //    .FirstOrDefault();
        //}

        //public void CrearProveedorGiroComercial(GenProveedorGiroComercialModel proveedorGiroComercial)
        //{
        //    _context.Database.ExecuteSqlRaw("EXEC sp_CrearProveedorGiroComercial " +
        //        "@IdProveedorDatos = {0}, " +
        //        "@IdGiroComercial = {1}, " +
        //        "@IdUsuarioAlta = {2}",
        //        proveedorGiroComercial.IdProveedorDatos,
        //        proveedorGiroComercial.IdGiroComercial,
        //    proveedorGiroComercial.IdUsuarioAlta);
        //}

        //public void ActualizarProveedorGiroComercial(GenProveedorGiroComercialModel proveedorGiroComercial)
        //{
        //    _context.Database.ExecuteSqlRaw("EXEC sp_ActualizarProveedorGiroComercial " +
        //        "@IdProveedor_GiroComercial = {0}, " +
        //        "@IdProveedorDatos = {1}, " +
        //        "@IdGiroComercial = {2}, " +
        //        "@IdUsuarioModificacion = {3}, " +
        //        "@Activo = {4}",
        //        proveedorGiroComercial.IdProveedor_GiroComercial,
        //        proveedorGiroComercial.IdProveedorDatos,
        //        proveedorGiroComercial.IdGiroComercial,
        //        proveedorGiroComercial.IdUsuarioModificacion,
        //        proveedorGiroComercial.Activo);
        //}

        //public void EliminarProveedorGiroComercialLogico(int idProveedorGiroComercial, int idUsuarioModificacion)
        //{
        //    _context.Database.ExecuteSqlRaw("EXEC sp_EliminarProveedorGiroComercialLogico " +
        //        "@IdProveedor_GiroComercial = {0}, " +
        //        "@IdUsuarioModificacion = {1}",
        //        idProveedorGiroComercial,
        //        idUsuarioModificacion);
        //}

        //public void EliminarProveedorGiroComercialFisico(int idProveedorGiroComercial)
        //{
        //    _context.Database.ExecuteSqlRaw("EXEC sp_EliminarProveedorGiroComercialFisico " +
        //        "@IdProveedor_GiroComercial = {0}",
        //        idProveedorGiroComercial);
        //}
    }
}
