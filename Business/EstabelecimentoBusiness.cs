using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.Model;
using Utilities;

namespace Business
{
    public class EstabelecimentoBusiness : DefaultBusiness
    {
        public EstabelecimentoModel CadastrarEstabelecimento(EstabelecimentoModel model)
        {
            try
            {
                model.Status = true;
                model.CNPJ = Format.SetCnpj(model.CNPJ);
                model.Telefone = Format.SetTelefone(model.Telefone);

                if (model.IdCategoria == this.GetFirst<CategoriaModel>(GetContext, x => x.Descricao.ToUpper().Equals("SUPERMERCADO")).IdCategoria)
                {
                    if (string.IsNullOrEmpty(model.Telefone))
                    {
                        throw new ArgumentException("Para essa Categoria o Telefone deverá ser preenchido!");
                    }
                }

                Insert(GetContext, model);
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(ArgumentException))
                {
                    throw ex;
                }

                throw new Exception("Erro ao Cadastrar Estabelecimento");
            }

            return model;
        }

        public EstabelecimentoModel AlterarEstabelecimento(EstabelecimentoModel model)
        {
            try
            {
                var context = GetContext;
                model.Status = true;
                model.CNPJ = Format.SetCnpj(model.CNPJ);
                model.Telefone = Format.SetTelefone(model.Telefone);
                if (model.IdCategoria == this.GetFirst<CategoriaModel>(GetContext, x => x.Descricao.ToUpper().Equals("SUPERMERCADO")).IdCategoria)
                {
                    if (string.IsNullOrEmpty(model.Telefone))
                    {
                        throw new ArgumentException("Para essa Categoria o Telefone deverá ser preenchido!");
                    }
                }

                Update(context, model);
                return model;
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(ArgumentException))
                {
                    throw ex;
                }

                throw new Exception("Erro ao Alterar Estabelecimento");
            }
        }

        public EstabelecimentoModel ExcluirEstabelecimento(EstabelecimentoModel model)
        {
            try
            {
                var context = GetContext;

                var estabelecimento = GetFirstOrDefault<EstabelecimentoModel>(context, x => x.IdEstabelecimento == model.IdEstabelecimento);

                if (estabelecimento != null)
                {
                    estabelecimento.Status = false;

                    Update(context, estabelecimento);
                    return model;
                }

                throw new ArgumentException("Não foi possivel efetuar a exclusão, pois o estabelecimento já está excluido!");
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(ArgumentException))
                {
                    throw ex;
                }

                throw new Exception("Erro ao Excluir Estabelecimento");
            }
        }

        public List<EstabelecimentoModel> SelecionarEstabelecimento(string pesquisa)
        {
            var result = this.GetList<EstabelecimentoModel>(GetContext).Where(x => ((string.IsNullOrEmpty(pesquisa) || x.CNPJ.Contains(pesquisa)) && x.Status)).ToList();
            foreach (var item in result)
            {
                item.CNPJ = Format.GetCpnj(item.CNPJ);
                item.Telefone = Format.GetTelefone(item.Telefone);
            }

            return result;
        }
    }
}
