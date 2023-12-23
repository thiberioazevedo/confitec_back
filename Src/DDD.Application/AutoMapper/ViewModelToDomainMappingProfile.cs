using AutoMapper;
using DDD.Application.ViewModels;
using DDD.Domain.Commands;
using DDD.Domain.Models;

namespace DDD.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<UsuarioViewModel, RegisterNewUsuarioCommand>()
                .ConstructUsing(c => new RegisterNewUsuarioCommand(c.Nome, c.Sobrenome, c.Email, c.DataNascimento, c.EscolaridadeId));
            CreateMap<UsuarioViewModel, UpdateUsuarioCommand>()
                .ConstructUsing(c => new UpdateUsuarioCommand(c.Id ?? 0, c.Nome, c.Sobrenome, c.Email, c.DataNascimento, c.EscolaridadeId));

            CreateMap<EscolaridadeViewModel, Escolaridade>();

            CreateMap<AnexoViewModel, AddAnexoCommand>()
                .ConstructUsing(c => new AddAnexoCommand(c.Nome, c.Formato, c.Arquivo));
        }
    }
}
