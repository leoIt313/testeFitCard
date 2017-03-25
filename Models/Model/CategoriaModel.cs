using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Model
{
    public class CategoriaModel
    {
        public long IdCategoria { get; set; }
        //[Supermercado, Restaurante, Borracharia, Posto, Oficina];
        public string Descricao { get; set; }

        public long IdEstabelecimento { get; set; }

        public virtual List<EstabelecimentoModel> Estabelecimento { get; set; }

    }
}
