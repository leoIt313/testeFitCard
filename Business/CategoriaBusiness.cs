using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Model;

namespace Business
{
    public class CategoriaBusiness : DefaultBusiness
    {
        public List<CategoriaModel> BuscarCategorias()
        {
            return this.GetList<CategoriaModel>(GetContext).ToList();
        }
    }
}
