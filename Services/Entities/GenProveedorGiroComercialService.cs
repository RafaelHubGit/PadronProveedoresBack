using PadronProveedoresAPI.Data.Repository.Entities;
using PadronProveedoresAPI.Models.Entities;

namespace PadronProveedoresAPI.Services.Entities
{
    public class GenProveedorGiroComercialService
    {
        private readonly GenProveedorGiroComercialRepository _repository;

        public GenProveedorGiroComercialService(GenProveedorGiroComercialRepository repository)
        {
            _repository = repository;
        }

        //public IEnumerable<GenProveedorGiroComercialModel> ObtenerProveedoresGiroComercial()
        //{
        //    return _repository.ObtenerProveedoresGiroComercial();
        //}

        //public GenProveedorGiroComercialModel ObtenerProveedorGiroComercialPorId(int idProveedorGiroComercial)
        //{
        //    return _repository.ObtenerProveedorGiroComercialPorId(idProveedorGiroComercial);
        //}

        //public void CrearProveedorGiroComercial(GenProveedorGiroComercialModel proveedorGiroComercial)
        //{
        //    _repository.CrearProveedorGiroComercial(proveedorGiroComercial);
        //}

        //public void ActualizarProveedorGiroComercial(GenProveedorGiroComercialModel proveedorGiroComercial)
        //{
        //    _repository.ActualizarProveedorGiroComercial(proveedorGiroComercial);
        //}

        //public void EliminarProveedorGiroComercialLogico(int idProveedorGiroComercial, int idUsuarioModificacion)
        //{
        //    _repository.EliminarProveedorGiroComercialLogico(idProveedorGiroComercial, idUsuarioModificacion);
        //}

        //public void EliminarProveedorGiroComercialFisico(int idProveedorGiroComercial)
        //{
        //    _repository.EliminarProveedorGiroComercialFisico(idProveedorGiroComercial);
        //}
    }
}
