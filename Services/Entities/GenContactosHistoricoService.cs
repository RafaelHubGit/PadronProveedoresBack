using PadronProveedoresAPI.Data.Repository.Entities;
using PadronProveedoresAPI.Models.Entities;

namespace PadronProveedoresAPI.Services.Entities
{
    public class GenContactosHistoricoService
    {
        private readonly GenContactosHistoricoRepository _repository;

        public GenContactosHistoricoService(GenContactosHistoricoRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<GenContactosHistoricoModel> ObtenerContactosHistorico()
        {
            return _repository.ObtenerContactosHistorico();
        }

        public GenContactosHistoricoModel ObtenerContactoHistoricoPorId(int idContactoHistorico)
        {
            return _repository.ObtenerContactoHistoricoPorId(idContactoHistorico);
        }

        public IEnumerable<GenContactosHistoricoModel> ObtenerContactosHistoricoPorProveedorDatos(int idProveedorDatos)
        {
            return _repository.ObtenerContactosHistoricoPorProveedorDatos(idProveedorDatos);
        }

        public void CrearContactoHistorico(GenContactosHistoricoModel contactoHistorico)
        {
            _repository.CrearContactoHistorico(contactoHistorico);
        }

        public void ActualizarContactoHistorico(GenContactosHistoricoModel contactoHistorico)
        {
            _repository.ActualizarContactoHistorico(contactoHistorico);
        }

        public void EliminarContactoHistorico(int idContactoHistorico)
        {
            _repository.EliminarContactoHistorico(idContactoHistorico);
        }
    }
}
