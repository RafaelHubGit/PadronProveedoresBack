using Microsoft.EntityFrameworkCore;
using PadronProveedoresAPI.Models.Entities;

namespace PadronProveedoresAPI.Data.Repository.Entities
{
    public class GenContactosHistoricoRepository
    {
        private readonly StoreContext _context;

        public GenContactosHistoricoRepository(StoreContext context)
        {
            _context = context;
        }

        public IEnumerable<GenContactosHistoricoModel> ObtenerContactosHistorico()
        {
            return _context.GenContactosHistoricoModel
                .FromSqlRaw("EXEC sp_ObtenerContactosHistorico")
                .ToList();
        }

        public GenContactosHistoricoModel ObtenerContactoHistoricoPorId(int idContactoHistorico)
        {
            return _context.GenContactosHistoricoModel
                .FromSqlRaw("EXEC sp_ObtenerContactoHistoricoPorId @IdContactoHistorico = {0}", idContactoHistorico)
                .FirstOrDefault();
        }

        public IEnumerable<GenContactosHistoricoModel> ObtenerContactosHistoricoPorProveedorDatos(int idProveedorDatos)
        {
            return _context.GenContactosHistoricoModel
                .FromSqlRaw("EXEC sp_ObtenerContactosHistoricoPorProveedorDatos @IdProveedorDatos = {0}", idProveedorDatos)
                .ToList();
        }

        public void CrearContactoHistorico(GenContactosHistoricoModel contactoHistorico)
        {
            _context.Database.ExecuteSqlRaw("EXEC sp_CrearContactoHistorico " +
                "@IdProveedorDatos = {0}, " +
                "@Tipo = {1}, " +
                "@Contactos = {2}",
                contactoHistorico.IdProveedorDatos,
                contactoHistorico.Tipo,
                contactoHistorico.Contactos);
        }

        public void ActualizarContactoHistorico(GenContactosHistoricoModel contactoHistorico)
        {
            _context.Database.ExecuteSqlRaw("EXEC sp_ActualizarContactoHistorico " +
                "@IdContactoHistorico = {0}, " +
                "@IdProveedorDatos = {1}, " +
                "@Tipo = {2}, " +
                "@Contactos = {3}",
                contactoHistorico.IdContactoHistorico,
                contactoHistorico.IdProveedorDatos,
                contactoHistorico.Tipo,
                contactoHistorico.Contactos);
        }

        public void EliminarContactoHistorico(int idContactoHistorico)
        {
            _context.Database.ExecuteSqlRaw("EXEC sp_EliminarContactoHistorico " +
                "@IdContactoHistorico = {0}",
                idContactoHistorico);
        }
    }
}
