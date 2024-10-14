using Microsoft.EntityFrameworkCore;
using PadronProveedoresAPI.Models.Entities;

namespace PadronProveedoresAPI.Data.Repository.Entities
{
    public class GenDomicilioHistoricoRepository
    {
        private readonly StoreContext _context;

        public GenDomicilioHistoricoRepository(StoreContext context)
        {
            _context = context;
        }

        public IEnumerable<GenDomicilioHistoricoModel> ObtenerDomiciliosHistorico()
        {
            return _context.GenDomicilioHistoricoModel
                .FromSqlRaw("EXEC sp_ObtenerDomiciliosHistorico")
                .ToList();
        }

        public GenDomicilioHistoricoModel ObtenerDomicilioHistoricoPorId(int idDomicilioHistorico)
        {
            return _context.GenDomicilioHistoricoModel
                .FromSqlRaw("EXEC sp_ObtenerDomicilioHistoricoPorId @IdDomicilioHistorico = {0}", idDomicilioHistorico)
                .FirstOrDefault();
        }

        public IEnumerable<GenDomicilioHistoricoModel> ObtenerDomiciliosHistoricoPorProveedorDatos(int idProveedorDatos)
        {
            return _context.GenDomicilioHistoricoModel
                .FromSqlRaw("EXEC sp_ObtenerDomiciliosHistoricoPorProveedorDatos @IdProveedorDatos = {0}", idProveedorDatos)
                .ToList();
        }

        public void CrearDomicilioHistorico(GenDomicilioHistoricoModel domicilioHistorico)
        {
            _context.Database.ExecuteSqlRaw("EXEC sp_CrearDomicilioHistorico " +
                "@IdProveedorDatos = {0}, " +
                "@Domicilio = {1}",
                domicilioHistorico.IdProveedorDatos,
                domicilioHistorico.Domicilio);
        }

        public void ActualizarDomicilioHistorico(GenDomicilioHistoricoModel domicilioHistorico)
        {
            _context.Database.ExecuteSqlRaw("EXEC sp_ActualizarDomicilioHistorico " +
                "@IdDomicilioHistorico = {0}, " +
                "@IdProveedorDatos = {1}, " +
                "@Domicilio = {2}",
                domicilioHistorico.IdDomicilioHistorico,
                domicilioHistorico.IdProveedorDatos,
                domicilioHistorico.Domicilio);
        }

        public void EliminarDomicilioHistorico(int idDomicilioHistorico)
        {
            _context.Database.ExecuteSqlRaw("EXEC sp_EliminarDomicilioHistorico " +
                "@IdDomicilioHistorico = {0}",
                idDomicilioHistorico);
        }
    }
}
