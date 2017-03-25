using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FiTCARD_Test.Models.ViewModel.Response
{
    public class ResponseSelecionarEstabelecimentoViewModel
    {
        public long IdEstabelecimento { get; set; }
        public string Nome { get; set; }
        public string NomeFantasia { get; set; }
        public string CNPJ { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string DescricaoCategoria { get; set; }
        public long IdCategoria { get; set; }

    }
}