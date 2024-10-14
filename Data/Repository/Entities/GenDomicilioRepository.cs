using Microsoft.EntityFrameworkCore;
using PadronProveedoresAPI.Models.Entities;

namespace PadronProveedoresAPI.Data.Repository.Entities
{
    public class GenDomicilioRepository
    {
        private readonly StoreContext _context;

        public GenDomicilioRepository(StoreContext context)
        {
            _context = context;
        }

        public IEnumerable<GenDomicilioModel> ObtenerDomicilios()
        {
            return _context.GenDomicilioModel
                .FromSqlRaw("EXEC sp_ObtenerDomicilios")
                .ToList();
        }

        public GenDomicilioModel ObtenerDomicilioPorId(int idDomicilio)
        {
            return _context.GenDomicilioModel
                .FromSqlRaw("EXEC sp_ObtenerDomicilioPorId @IdDomicilio = {0}", idDomicilio)
                .FirstOrDefault();
        }

        public void CrearDomicilio(GenDomicilioModel domicilio)
        {
            _context.Database.ExecuteSqlRaw("EXEC sp_CrearDomicilio " +
                "@IdProveedorDatos = {0}, " +
                "@Calle = {1}, " +
                "@IdEstado = {2}, " +
                "@IdMunicipio = {3}, " +
                "@IdColonia = {4}, " +
                "@IdCodigoPostal = {5}, " +
                "@DireccionInternacional = {6}, " +
                "@Nota = {7}, " +
                "@IdUsuarioAlta = {8}",
                domicilio.IdProveedorDatos,
                domicilio.Calle,
                domicilio.IdEstado,
                domicilio.IdMunicipio,
                domicilio.IdColonia,
                domicilio.IdCodigoPostal,
                domicilio.DireccionInternacional,
                domicilio.Nota,
                domicilio.IdUsuarioAlta);
        }

        public void ActualizarDomicilio(GenDomicilioModel domicilio)
        {
            _context.Database.ExecuteSqlRaw("EXEC sp_ActualizarDomicilio " +
                "@IdDomicilio = {0}, " +
                "@IdProveedorDatos = {1}, " +
                "@Calle = {2}, " +
                "@IdEstado = {3}, " +
                "@IdMunicipio = {4}, " +
                "@IdColonia = {5}, " +
                "@IdCodigoPostal = {6}, " +
                "@DireccionInternacional = {7}, " +
                "@Nota = {8}, " +
                "@IdUsuarioModificacion = {9}, " +
                "@Activo = {10}",
                domicilio.IdDomicilio,
                domicilio.IdProveedorDatos,
                domicilio.Calle,
                domicilio.IdEstado,
                domicilio.IdMunicipio,
                domicilio.IdColonia,
                domicilio.IdCodigoPostal,
                domicilio.DireccionInternacional,
                domicilio.Nota,
                domicilio.IdUsuarioModificacion,
                domicilio.Activo);
        }

        public void EliminarDomicilioLogico(int idDomicilio, int idUsuarioModificacion)
        {
            _context.Database.ExecuteSqlRaw("EXEC sp_EliminarDomicilioLogico " +
                "@IdDomicilio = {0}, " +
                "@IdUsuarioModificacion = {1}",
                idDomicilio,
                idUsuarioModificacion);
        }

        public void EliminarDomicilioFisico(int idDomicilio)
        {
            _context.Database.ExecuteSqlRaw("EXEC sp_EliminarDomicilioFisico " +
                "@IdDomicilio = {0}",
                idDomicilio);
        }
    }
}
