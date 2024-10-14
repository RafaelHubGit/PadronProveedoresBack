using PadronProveedoresAPI.Data.Repository.Entities;
using PadronProveedoresAPI.Models.Entities;

namespace PadronProveedoresAPI.Services.Entities
{
    public class GenDomicilioHistoricoService
    {
        private readonly GenDomicilioHistoricoRepository _repository;

        public GenDomicilioHistoricoService(GenDomicilioHistoricoRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<GenDomicilioHistoricoModel> ObtenerDomiciliosHistorico()
        {
            return _repository.ObtenerDomiciliosHistorico();
        }

        public GenDomicilioHistoricoModel ObtenerDomicilioHistoricoPorId(int idDomicilioHistorico)
        {
            return _repository.ObtenerDomicilioHistoricoPorId(idDomicilioHistorico);
        }

        public IEnumerable<GenDomicilioHistoricoModel> ObtenerDomiciliosHistoricoPorProveedorDatos(int idProveedorDatos)
        {
            return _repository.ObtenerDomiciliosHistoricoPorProveedorDatos(idProveedorDatos);
        }

        public void CrearDomicilioHistorico(GenDomicilioHistoricoModel domicilioHistorico)
        {
            _repository.CrearDomicilioHistorico(domicilioHistorico);
        }

        public void ActualizarDomicilioHistorico(GenDomicilioHistoricoModel domicilioHistorico)
        {
            _repository.ActualizarDomicilioHistorico(domicilioHistorico);
        }

        public void EliminarDomicilioHistorico(int idDomicilioHistorico)
        {
            _repository.EliminarDomicilioHistorico(idDomicilioHistorico);
        }
    }
}
