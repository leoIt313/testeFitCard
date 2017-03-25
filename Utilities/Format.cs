using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public static class Format
    {

        public static string SetCnpj(string cnpj)
        {
            return string.IsNullOrEmpty(cnpj) ? cnpj : cnpj.Replace("_", string.Empty).Replace("/", string.Empty).Replace(".", string.Empty).Replace("-", string.Empty);
        }

        public static string GetCpnj(string cnpj)
        {
            return string.IsNullOrEmpty(cnpj) ? cnpj : string.Format("{0}.{1}.{2}/{3}-{4}", cnpj.Substring(0, 2), cnpj.Substring(2, 3), cnpj.Substring(5, 3), cnpj.Substring(8, 4), cnpj.Substring(12, 2)); ;
        }

        public static string GetTelefone(string telefone)
        {
            return string.IsNullOrEmpty(telefone) ? telefone : string.Format("({0}) {1}-{2}", telefone.Substring(0, 2), telefone.Substring(2, 5), telefone.Substring(7, 4));
        }

        public static string SetTelefone(string telefone)
        {
            return string.IsNullOrEmpty(telefone) ? telefone : telefone.Replace("(", string.Empty).Replace(")", string.Empty).Replace("-", string.Empty).Replace(" ", string.Empty);
        }
    }
}
