using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Text;
using Models;
using Models.Model;

namespace DataAccess
{
    public class ApiInitializer : CreateDatabaseIfNotExists<ApiDbContext>
    {
        protected override void Seed(ApiDbContext context)
        {
            base.Seed(context);

            context.Categoria.Add(new CategoriaModel
            {
                Descricao = "Supermercado"
            });

            context.Categoria.Add(new CategoriaModel
            {
                Descricao = "Restaurante"
            });

            context.Categoria.Add(new CategoriaModel
            {
                Descricao = "Borracharia"
            });

            context.Categoria.Add(new CategoriaModel
            {
                Descricao = "Posto"
            });

            context.Categoria.Add(new CategoriaModel
            {
                Descricao = "Oficina"
            });

            context.SaveChanges();
        }
    }
}
