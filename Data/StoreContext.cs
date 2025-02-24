using Microsoft.EntityFrameworkCore;
using PadronProveedoresAPI.Models.Entities;
using PadronProveedoresAPI.Models.Project;

namespace PadronProveedoresAPI.Data
{
    public class StoreContext : DbContext
    {

        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {

        }


        //Project
        //public DbSet<ProveedorStringModel> proveedorStringModel { get; set; }



        // Entities
        public DbSet<GenProveedorModel> GenProveedorModel { get; set; }
        public DbSet<GenProveedorDatosModel> GenProveedorDatosModel { get; set; }
        //public DbSet<Models.GenProveedor_GiroComercialModel> GenProveedor_GiroComercialModel { get; set; }
        public DbSet<GenRepresentanteModel> GenRepresentanteModel { get; set; }
        public DbSet<GenContactoModel> GenContactoModel { get; set; }
        public DbSet<GenDomicilioModel> GenDomicilioModel { get; set; }
        public DbSet<GenProveedorBloqueadoModel> GenProveedorBloqueadoModel { get; set; }
        public DbSet<GenDocumentosModel> GenDocumentosModel { get; set; }

        // Catalogos
        public DbSet<CatEstatusProveedorBloqueadoModel> CatEstatusProveedorBloqueadoModel { get; set; }
        public DbSet<CatGiroComercialModel> CatGiroComercialModel { get; set; }
        public DbSet<CatEstratificacionModel> CatEstratificacionModel { get; set; }
        public DbSet<CatGeneroModel> CatGeneroModel { get; set; }
        public DbSet<CatMatrizArticulosFraccionesModel> CatMatrizArticulosFraccionesModel { get; set; }
        public DbSet<CatTipoContactoModel> CatTipoContactoModel { get; set; }
        public DbSet<CatTipoEntidadModel> CatTipoEntidadModel { get; set; }
        public DbSet<CatTipoProveedorModel> CatTipoProveedorModel { get; set; }

        //Historico 
        public DbSet<GenDomicilioHistoricoModel> GenDomicilioHistoricoModel { get; set; }
        public DbSet<GenContactosHistoricoModel> GenContactosHistoricoModel { get; set; }

        // Direcciones Catalogos
        public DbSet<CatEstadosModel> CatEstadosModel { get; set; }
        public DbSet<CatMunicipiosModel> CatMunicipiosModel { get; set; }
        public DbSet<CatColoniasModel> CatColoniasModel { get; set; }
        public DbSet<CatCodigosPostalesModel> CatCodigosPostalesModel { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ProveedorDatosProveedorViewModel>()
            //    .HasNoKey();

            // Configuración para otras entidades...
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(LoggerFactory.Create(builder => { builder.AddConsole(); }))
                .EnableSensitiveDataLogging(); // Habilita el registro de datos sensibles
        }
    }
}
