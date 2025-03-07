using Microsoft.Extensions.Options;
using PadronProveedoresAPI.Data.Repository;
using PadronProveedoresAPI.Data.Repository.Entities;
using PadronProveedoresAPI.Data.Repository.Project;
using PadronProveedoresAPI.MiddleWare.Logs;
using PadronProveedoresAPI.Services.ConfiguracionReportes;
using PadronProveedoresAPI.Services.Entities;
using PadronProveedoresAPI.Services.Project;
using PadronProveedoresAPI.Settings;
using PadronProveedoresAPI.Utilities;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace PadronProveedoresAPI
{
    public static class ServiceConfig
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration) {

            //Project 
            services.AddScoped<ProveedorService>();
            services.AddScoped<ProveedorRepository>();

            //TypeSense
            services.Configure<TypeSenseSettings>(configuration.GetSection("TypeSenseSettings"));
            services.AddScoped<ProveedorTypeSenseMapping>();
            services.AddScoped<TypeSenseService>(sp =>
            {
                var pRepository = sp.GetRequiredService<ProveedorService>();
                var typeSenseSettings = sp.GetRequiredService<IOptions<TypeSenseSettings>>().Value;
                var logger = sp.GetRequiredService<CustomLogger>();

                Debug.WriteLine("typeSenseSettings : " + typeSenseSettings);
                Debug.WriteLine("VALOR URL : " + typeSenseSettings.ServerUrl);
                Debug.WriteLine("VALOR KEY : " + typeSenseSettings.ApiKey);

                return new TypeSenseService(typeSenseSettings.ServerUrl, typeSenseSettings.ApiKey, pRepository, logger);
            });



            // Entities

            services.AddScoped<GenericRepository>();

            services.AddScoped<GenProveedorRepository>();
            services.AddScoped<GenProveedorService>();

            services.AddScoped<GenProveedorDatosRepository>();
            services.AddScoped<GenProveedorDatosService>();

            services.AddScoped<CatGiroComercialRepository>();
            services.AddScoped<CatGiroComercialService>();

            services.AddScoped<CatEstratificacionService>();

            services.AddScoped<CatGeneroService>();

            services.AddScoped<CatTipoContactoService>();

            services.AddScoped<CatTipoDocumentoService>();

            services.AddScoped<CatTipoEntidadService>();

            services.AddScoped<CatMatrizArticulosFraccionesService>();

            services.AddScoped<CatTipoProveedorService>();

            services.AddScoped<GenContactoRepository>();
            services.AddScoped<GenContactoService>();

            services.AddScoped<GenContactosHistoricoRepository>();
            services.AddScoped<GenContactosHistoricoService>();

            services.AddScoped<GenRepresentanteRepository>();
            services.AddScoped<GenRepresentanteService>();

            services.AddScoped<GenDomicilioHistoricoRepository>();
            services.AddScoped<GenDomicilioHistoricoService>();

            services.AddScoped<GenDomicilioRepository>();
            services.AddScoped<GenDomicilioService>();

            services.AddScoped<GenProveedorGiroComercialRepository>();
            services.AddScoped<GenProveedorGiroComercialService>();

            services.AddScoped<GenProveedorBloqueadoRepository>();
            services.AddScoped<GenProveedorBloqueadoService>();

            services.AddScoped<GenDocumentosRepository>();
            services.AddScoped<GenDocumentosService>();


            // Configuracion de Reportes 
            services.AddScoped<CatReportesFirmantesService>();
            services.AddScoped<CatReportesLogosService>();
            services.AddScoped<CatReportesLeyendasService>();
            services.AddScoped<GenReporte_FirmantesService>();



            // Direcciones Cat 

            services.AddScoped<CatEstatusProveedorBloqueadoService>();

            services.AddScoped<CatEstadosRepository>();
            services.AddScoped<CatEstadosService>();

            services.AddScoped<CatMunicipiosRepository>();
            services.AddScoped<CatMunicipiosService>();

            services.AddScoped<CatColoniasRepository>();
            services.AddScoped<CatColoniasService>();

            services.AddScoped<CatCodigosPostalesRepository>();
            services.AddScoped<CatCodigosPostalesService>();
        } 
    }
}
