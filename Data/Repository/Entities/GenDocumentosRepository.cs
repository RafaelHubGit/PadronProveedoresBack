using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PadronProveedoresAPI.Models.Entities;

namespace PadronProveedoresAPI.Data.Repository.Entities
{
    public class GenDocumentosRepository : Controller
    {
        private readonly StoreContext _context;

        public GenDocumentosRepository(StoreContext context)
        {
            _context = context;
        }

        public IEnumerable<GenDocumentosModel> ObtenerDocumentos()
        {
            return _context.GenDocumentosModel
                .FromSqlRaw("EXEC sp_ObtenerDocumentos")
                .ToList();
        }

        public GenDocumentosModel ObtenerDocumentoPorId(int idDocumentos)
        {
            return _context.GenDocumentosModel
                .FromSqlRaw("EXEC sp_ObtenerDocumentoPorId @IdDocumentos = {0}", idDocumentos)
                .FirstOrDefault();
        }

        public IEnumerable<GenDocumentosModel> ObtenerDocumentosPorProveedorDatos(int idProveedorDatos)
        {
            return _context.GenDocumentosModel
                .FromSqlRaw("EXEC sp_ObtenerDocumentosPorProveedorDatos @IdProveedorDatos = {0}", idProveedorDatos)
                .ToList();
        }

        public void CrearDocumento(GenDocumentosModel documento)
        {
            _context.Database.ExecuteSqlRaw("EXEC sp_CrearDocumento " +
                "@IdProveedorDatos = {0}, " +
                "@NombreDocumento = {1}, " +
                "@TipoDocumento = {2}, " +
                "@FechaCarga = {3}, " +
                "@IdUsuarioAlta = {4}",
                documento.IdProveedorDatos,
                documento.NombreDocumento,
                documento.Tipo,
                documento.FechaCarga,
                documento.IdUsuarioAlta);
        }

        public void ActualizarDocumento(GenDocumentosModel documento)
        {
            _context.Database.ExecuteSqlRaw("EXEC sp_ActualizarDocumento " +
                "@IdDocumentos = {0}, " +
                "@IdProveedorDatos = {1}, " +
                "@NombreDocumento = {2}, " +
                "@TipoDocumento = {3}, " +
                "@FechaCarga = {4}, " +
                "@IdUsuarioModificacion = {5}, " +
                "@Activo = {6}",
                documento.IdDocumentos,
                documento.IdProveedorDatos,
                documento.NombreDocumento,
                documento.Tipo,
                documento.FechaCarga,
                documento.IdUsuarioModificacion,
                documento.Activo);
        }

        public void EliminarDocumentoLogico(int idDocumentos, int idUsuarioModificacion)
        {
            _context.Database.ExecuteSqlRaw("EXEC sp_EliminarDocumentoLogico " +
                "@IdDocumentos = {0}, " +
                "@IdUsuarioModificacion = {1}",
                idDocumentos,
                idUsuarioModificacion);
        }

        public void EliminarDocumentoFisico(int idDocumentos)
        {
            _context.Database.ExecuteSqlRaw("EXEC sp_EliminarDocumentoFisico " +
                "@IdDocumentos = {0}",
                idDocumentos);
        }
    }
}
