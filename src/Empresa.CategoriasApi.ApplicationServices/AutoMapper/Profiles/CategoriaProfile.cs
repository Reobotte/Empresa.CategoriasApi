using AutoMapper;
using Empresa.CategoriasApi.ApplicationServices.ValueObjects;
using Empresa.CategoriasApi.Domains.CQRS.Commands.CategoriaCommands;
using Empresa.CategoriasApi.Domains.Entities.Interfaces;

namespace Empresa.CategoriasApi.ApplicationServices.AutoMapper.Profiles
{
    public class CategoriaProfile : Profile
    {
        public CategoriaProfile()
        {
            CreateMap<CategoriaVo, IncluirCategoriaCommand>().ReverseMap();
            CreateMap<CategoriaIdVo, IncluirCategoriaCommand>().ReverseMap();
            CreateMap<CategoriaIdVo, AlterarCategoriaCommand>().ReverseMap();
            CreateMap<CategoriaIdVo, ExcluirCategoriaCommand>().ReverseMap();

            CreateMap<CategoriaIdVo, ICategoria>().ReverseMap();
            CreateMap<CategoriaIdVo, CategoriaVo>().ReverseMap();
        }
    }
}
