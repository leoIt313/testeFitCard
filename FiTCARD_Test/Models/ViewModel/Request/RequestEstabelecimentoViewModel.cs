using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FiTCARD_Test.Models.ViewModel.Request
{
    public class RequestEstabelecimentoViewModel
    {
        private string pesquisa;

        public long IdEstabelecimento { get; set; }
        public string Nome { get; set; }
        [DisplayName("Nome Fantasia")]
        public string NomeFantasia { get; set; }
        public string CNPJ { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public long IdCategoria { get; set; }

        public string Pesquisa
        {
            get
            {
                if (!string.IsNullOrEmpty(pesquisa))
                {
                    pesquisa = pesquisa.Replace("_", string.Empty).Replace("/", string.Empty).Replace(".", string.Empty).Replace("-", string.Empty);
                }

                return pesquisa;
            }
            set
            {
                pesquisa = value;
            }
        }
        public List<SelectListItem> Categorias { get; set; }

    }
}