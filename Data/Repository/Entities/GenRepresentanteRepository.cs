using Microsoft.EntityFrameworkCore;
using PadronProveedoresAPI.Models.Entities;

namespace PadronProveedoresAPI.Data.Repository.Entities
{
    public class GenRepresentanteRepository
    {
        private readonly StoreContext _context;

        public GenRepresentanteRepository(StoreContext context)
        {
            _context = context;
        }

        public IEnumerable<GenRepresentanteModel> ObtenerRepresentantes()
        {
            return _context.GenRepresentanteModel
                .FromSqlRaw("EXEC sp_ObtenerRepresentantes")
                .ToList();
        }

        public GenRepresentanteModel ObtenerRepresentantePorId(int idRepresentante)
        {
            return _context.GenRepresentanteModel
                .FromSqlRaw("EXEC sp_ObtenerRepresentantePorId @IdRepresentante = {0}", idRepresentante)
                .FirstOrDefault();
        }

        public void CrearRepresentante(GenRepresentanteModel representante)
        {
            _context.Database.ExecuteSqlRaw("EXEC sp_CrearRepresentante " +
                "@IdProveedorDatos = {0}, " +
                "@Tipo = {1}, " +
                "@Representante = {2}, " +
                "@Nota = {3}, " +
                "@IdUsuarioAlta = {4}",
                representante.IdProveedorDatos,
                representante.Tipo,
                representante.Representante,
                representante.Nota,
                representante.IdUsuarioAlta);
        }

        public void ActualizarRepresentante(GenRepresentanteModel representante)
        {
            _context.Database.ExecuteSqlRaw("EXEC sp_ActualizarRepresentante " +
                "@IdRepresentante = {0}, " +
                "@IdProveedorDatos = {1}, " +
                "@Tipo = {2}, " +
                "@Representante = {3}, " +
                "@Nota = {4}, " +
                "@IdUsuarioModificacion = {5}, " +
                "@Activo = {6}",
                representante.IdRepresentante,
                representante.IdProveedorDatos,
                representante.Tipo,
                representante.Representante,
                representante.Nota,
                representante.IdUsuarioModificacion,
                representante.Activo);
        }

        public void EliminarRepresentanteLogico(int idRepresentante, int idUsuarioModificacion)
        {
            _context.Database.ExecuteSqlRaw("EXEC sp_EliminarRepresentanteLogico " +
                "@IdRepresentante = {0}, " +
                "@IdUsuarioModificacion = {1}",
                idRepresentante,
                idUsuarioModificacion);
        }

        public void EliminarRepresentanteFisico(int idRepresentante)
        {
            _context.Database.ExecuteSqlRaw("EXEC sp_EliminarRepresentanteFisico " +
                "@IdRepresentante = {0}",
                idRepresentante);
        }
    }
}
