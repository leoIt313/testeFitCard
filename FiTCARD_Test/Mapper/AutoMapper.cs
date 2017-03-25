using FiTCARD_Test.Models.ViewModel.Request;
using FiTCARD_Test.Models.ViewModel.Response;
using AutoMapper;
using Models.Model;

namespace FiTCARD_Test.Mapper
{
    public class AutoMapper
    {
        public static IMapper Mapper { get; set; }

        public static void RegisterMappings()
        {
            var config = new MapperConfiguration(cfg =>
            {
                #region ViewModelToModel
                cfg.CreateMap<RequestEstabelecimentoViewModel, EstabelecimentoModel>();
                #endregion

                #region ModelToViewModel
                cfg.CreateMap<EstabelecimentoModel, ResponseCadastrarEstabelecimentoViewModel>();
                cfg.CreateMap<EstabelecimentoModel, ResponseAlterarEstabelecimentoViewModel>();
                cfg.CreateMap<EstabelecimentoModel, ResponseExcluirEstabelecimentoViewModel>();
                cfg.CreateMap<EstabelecimentoModel, ResponseSelecionarEstabelecimentoViewModel>().ForMember(dest => dest.DescricaoCategoria, opts => opts.MapFrom(src => src.Categoria.Descricao)).
                                                                                                            ForMember(dest => dest.IdCategoria, opts => opts.MapFrom(src => src.Categoria.IdCategoria)); ;
                #endregion

            });

            Mapper = config.CreateMapper();
        }
    }
}