using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ConfigurationModels
{
    public class ConfigEstabelecimento : EntityTypeConfiguration<Models.Model.EstabelecimentoModel>
    {
        public ConfigEstabelecimento()
        {
            ToTable("Estabelecimento").HasKey(x => x.IdEstabelecimento);
            Property(x => x.Nome).IsRequired();
            Property(x => x.NomeFantasia).IsOptional();
            Property(x => x.CNPJ).IsRequired();
            Property(x => x.Email).IsOptional();
            Property(x => x.Telefone).IsOptional();
            Property(x => x.Status).IsRequired();
            HasRequired(x => x.Categoria).WithMany(x=>x.Estabelecimento).HasForeignKey(x=>x.IdCategoria);

        }
    }
}
