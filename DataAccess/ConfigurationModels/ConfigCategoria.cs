using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ConfigurationModels
{
    public class ConfigCategoria: EntityTypeConfiguration<Models.Model.CategoriaModel>
    {
        public ConfigCategoria()
        {
            ToTable("Categoria").HasKey(x => x.IdCategoria);
            Property(x => x.Descricao).IsRequired();
          
        }
    }
}
