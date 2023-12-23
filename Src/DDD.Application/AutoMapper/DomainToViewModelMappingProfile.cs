using AutoMapper;
using DDD.Application.ViewModels;
using DDD.Domain.Models;

namespace DDD.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Usuario, UsuarioViewModel>();
            CreateMap<Escolaridade, EscolaridadeViewModel>();
            CreateMap<UsuarioHistoricoEscolar, UsuarioHistoricoEscolarViewModel>();
            CreateMap<Anexo, AnexoViewModel>();
        }
    }
}
