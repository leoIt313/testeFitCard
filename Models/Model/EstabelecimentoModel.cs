using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Model
{
    public class EstabelecimentoModel
    {
        public long IdEstabelecimento { get; set; }
        public string Nome { get; set; }
        public string NomeFantasia { get; set; }
        public string CNPJ{ get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public bool Status { get; set; }
        public long IdCategoria { get; set; }
        public virtual CategoriaModel Categoria { get; set; }
    }
}
