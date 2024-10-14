using Microsoft.EntityFrameworkCore;
using PadronProveedoresAPI.Models.Entities;

namespace PadronProveedoresAPI.Data.Repository.Entities
{
    public class GenContactoRepository
    {
        private readonly StoreContext _context;

        public GenContactoRepository(StoreContext context)
        {
            _context = context;
        }

        public IEnumerable<GenContactoModel> ObtenerContactos()
        {
            return _context.GenContactoModel
                .FromSqlRaw("EXEC sp_ObtenerContactos")
                .ToList();
        }

        public GenContactoModel ObtenerContactoPorId(int idContacto)
        {
            return _context.GenContactoModel
                .FromSqlRaw("EXEC sp_ObtenerContactoPorId @IdContacto = {0}", idContacto)
                .FirstOrDefault();
        }

        public void CrearContacto(GenContactoModel contacto)
        {
            _context.Database.ExecuteSqlRaw("EXEC sp_CrearContacto " +
                "@IdProveedorDatos = {0}, " +
                "@Tipo = {1}, " +
                "@Contactos = {2}, " +
                "@Nota = {3}, " +
                "@IdUsuarioAlta = {4}",
                contacto.IdProveedorDatos,
                contacto.Tipo,
                contacto.Contactos,
                contacto.Nota,
                contacto.IdUsuarioAlta);
        }

        public void ActualizarContacto(GenContactoModel contacto)
        {
            _context.Database.ExecuteSqlRaw("EXEC sp_ActualizarContacto " +
                "@IdContacto = {0}, " +
                "@IdProveedorDatos = {1}, " +
                "@Tipo = {2}, " +
                "@Contactos = {3}, " +
                "@Nota = {4}, " +
                "@IdUsuarioModificacion = {5}, " +
                "@Activo = {6}",
                contacto.IdContacto,
                contacto.IdProveedorDatos,
                contacto.Tipo,
                contacto.Contactos,
                contacto.Nota,
                contacto.IdUsuarioModificacion,
                contacto.Activo);
        }

        public void EliminarContactoLogico(int idContacto, int idUsuarioModificacion)
        {
            _context.Database.ExecuteSqlRaw("EXEC sp_EliminarContactoLogico " +
                "@IdContacto = {0}, " +
                "@IdUsuarioModificacion = {1}",
                idContacto,
                idUsuarioModificacion);
        }

        public void EliminarContactoFisico(int idContacto)
        {
            _context.Database.ExecuteSqlRaw("EXEC sp_EliminarContactoFisico " +
                "@IdContacto = {0}",
                idContacto);
        }
    }
}
