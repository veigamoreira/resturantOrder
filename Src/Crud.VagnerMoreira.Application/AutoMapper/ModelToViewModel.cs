using AutoMapper;
using Crud.VagnerMoreira.Application.ViewModels;
using Crud.VagnerMoreira.Domain.Models;

namespace Crud.VagnerMoreira.Application.AutoMapper
{
    public class ModelToViewModel : Profile
    {
        public ModelToViewModel()
        {
            CreateMap<ContaCorrente, UsuarioAdicionarResponse>();
            CreateMap<ContaCorrente, UsuarioEditarResponse>();
            CreateMap<ContaCorrente, UsuarioDeletarResponse>();
            CreateMap<ContaCorrente, UsuarioObterResponse>();
            CreateMap<ContaCorrente, UsuarioListarResponse>();
            CreateMap<Erro, ErroViewModel>();
        }
    }
}
