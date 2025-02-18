using Microsoft.Data.SqlClient;
using PadronProveedoresAPI.Data.Repository;
using PadronProveedoresAPI.Data.Repository.Entities;
using PadronProveedoresAPI.Models.Entities;

namespace PadronProveedoresAPI.Services.Entities
{
    public class CatGiroComercialService
    {
        //private readonly CatGiroComercialRepository _repository;
        private readonly GenericRepository _repository;

        public CatGiroComercialService(GenericRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<CatGiroComercialModel> ObtenerGirosComerciales()
        {
            return _repository.EjecutarStoredProcedureLista<CatGiroComercialModel>("EXEC sp_ObtenerCatGiroComercial");

            //return _repository.ObtenerGirosComerciales();
        }

        public CatGiroComercialModel ObtenerGiroComercialPorId(int idGiroComercial)
        {
            return _repository.EjecutarStoredProcedureUnico<CatGiroComercialModel>(
                    "EXEC sp_ObtenerGiroComercialPorId @IdGiroComercial = {0}", idGiroComercial);
            //return _repository.ObtenerGiroComercialPorId(idGiroComercial);
        }

        public CatGiroComercialModel CrearGiroComercial(CatGiroComercialModel giroComercial)
        {
            return _repository.EjecutarStoredProcedureUnico<CatGiroComercialModel>(
                    "EXEC sp_CrearCatGiroComercial @GiroComercial = {0}, @IdUsuarioAlta = {1}",
                    giroComercial.GiroComercial, giroComercial.IdUsuarioAlta);
            //return _repository.CrearGiroComercial(giroComercial);
        }

        public CatGiroComercialModel ActualizarGiroComercial(CatGiroComercialModel giroComercial)
        {
            return _repository.EjecutarStoredProcedureUnico<CatGiroComercialModel>(
                    "EXEC sp_ActualizarCatGiroComercial @IdGiroComercial = {0}, @GiroComercial = {1}, @IdUsuarioModificacion = {2}, @Activo = {3}",
                    giroComercial.IdGiroComercial, giroComercial.GiroComercial, giroComercial.IdUsuarioModificacion, giroComercial.Activo);
            //return _repository.ActualizarGiroComercial(giroComercial);
        }

        public void EliminarGiroComercialLogico(int idGiroComercial, int idUsuario)
        {
            try
            {
                // Intenta ejecutar el procedimiento de eliminación
                _repository.EjecutarStoredProcedure("EXEC sp_EliminarCatGiroComercialLogico @IdGiroComercial = {0}, @IdUsuario = {1}", idGiroComercial, idUsuario);
            }
            catch (Exception ex)
            {
                // No se captura el error ya que esto nos ayuda a saber que no se puede eliminar
                throw new Exception("Ocurrió un error interno.", ex);
            }
        }

        public void EliminarGiroComercialFisico(int idGiroComercial)
        {
            _repository.EliminarStoredProcedure("EXEC sp_EliminarCatGiroComercialFisico @IdGiroComercial = {0}", idGiroComercial);

            //_repository.EliminarGiroComercialFisico(idGiroComercial);
        }
    }
}
