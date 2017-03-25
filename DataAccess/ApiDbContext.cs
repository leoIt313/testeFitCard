using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration.Configuration;
using Models.Model;

namespace DataAccess
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(string contextName) : base("name=" + contextName)
        {
            try
            {
                Database.SetInitializer(new ApiInitializer());
                Database.Initialize(force: true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DbSet<CategoriaModel> Categoria { get; set; }
        public DbSet<EstabelecimentoModel> Estabelecimento { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Conventions

            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            #endregion

            #region Configurations

            modelBuilder.Configurations.Add(new ConfigurationModels.ConfigEstabelecimento());
            modelBuilder.Configurations.Add(new ConfigurationModels.ConfigCategoria());

            #endregion
        }

    }

}
