using PadronProveedoresAPI.Data.Repository.Entities;
using PadronProveedoresAPI.Data.Repository.Project;
using PadronProveedoresAPI.Services.Entities;
using PadronProveedoresAPI.Services.Project;
using System.Runtime.CompilerServices;

namespace PadronProveedoresAPI
{
    public static class ServiceConfig
    {
        public static void AddServices(this IServiceCollection services ) {

            //Project 
            services.AddScoped<ProveedorRepository>();
            services.AddScoped<ProveedorService>();


            // Entities
            services.AddScoped<GenProveedorRepository>();
            services.AddScoped<GenProveedorService>();

            services.AddScoped<GenProveedorDatosRepository>();
            services.AddScoped<GenProveedorDatosService>();

            services.AddScoped<CatGiroComercialRepository>();
            services.AddScoped<CatGiroComercialService>();

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



            // Direcciones Cat 
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
