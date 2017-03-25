
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using FiTCARD_Test.Models.ViewModel.Request;
using Models.Model;
using FiTCARD_Test.Models.ViewModel.Response;
using Business;

namespace FiTCARD_Test.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var viewModel = new RequestEstabelecimentoViewModel
            {
                Categorias = new CategoriaBusiness().BuscarCategorias().Select(a =>
                                                                                    new SelectListItem()
                                                                                    {
                                                                                        Text = a.Descricao,
                                                                                        Value = a.IdCategoria.ToString()

                                                                                    }).ToList()
            };
            return View(viewModel);
        }

        public object Cadastrar(RequestEstabelecimentoViewModel viewModel)
        {
            try
            {
                var model = Mapper.AutoMapper.Mapper.Map<RequestEstabelecimentoViewModel, EstabelecimentoModel>(viewModel);
                var result = Mapper.AutoMapper.Mapper.Map<EstabelecimentoModel, ResponseCadastrarEstabelecimentoViewModel>(new EstabelecimentoBusiness().CadastrarEstabelecimento(model));
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ArgumentException exception)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadGateway, exception.Message);
            }
            catch (Exception exception)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, exception.Message);
            }
        }

        public object Alterar(RequestEstabelecimentoViewModel viewModel)
        {
            try
            {
                var model = Mapper.AutoMapper.Mapper.Map<RequestEstabelecimentoViewModel, EstabelecimentoModel>(viewModel);
                var result = Mapper.AutoMapper.Mapper.Map<EstabelecimentoModel, ResponseAlterarEstabelecimentoViewModel>(new EstabelecimentoBusiness().AlterarEstabelecimento(model));
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ArgumentException exception)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadGateway, exception.Message);
            }
            catch (Exception exception)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, exception.Message);
            }
        }

        public object Excluir(RequestEstabelecimentoViewModel viewModel)
        {
            try
            {
                var model = Mapper.AutoMapper.Mapper.Map<RequestEstabelecimentoViewModel, EstabelecimentoModel>(viewModel);
                var result = Mapper.AutoMapper.Mapper.Map<EstabelecimentoModel, ResponseExcluirEstabelecimentoViewModel>(new EstabelecimentoBusiness().ExcluirEstabelecimento(model));
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ArgumentException exception)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadGateway, exception.Message);
            }
            catch (Exception exception)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, exception.Message);
            }
        }

        public PartialViewResult Selecionar(RequestEstabelecimentoViewModel viewModel)
        {
            var result = Mapper.AutoMapper.Mapper.Map<List<EstabelecimentoModel>, List<ResponseSelecionarEstabelecimentoViewModel>>(new EstabelecimentoBusiness().SelecionarEstabelecimento(viewModel.Pesquisa));
            return PartialView("Grid", result);
        }
    }
}