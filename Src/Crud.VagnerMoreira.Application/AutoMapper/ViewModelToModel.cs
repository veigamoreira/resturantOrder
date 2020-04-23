using AutoMapper;
using Crud.VagnerMoreira.Application.ViewModels;
using Crud.VagnerMoreira.Domain.Models;

namespace Crud.VagnerMoreira.Application.AutoMapper
{
    public class ViewModelToModel : Profile
    {
        public ViewModelToModel()
        {
            CreateMap<OperacaoRequest, ContaCorrente>();
            CreateMap<UsuarioEditarRequest, ContaCorrente>();
            CreateMap<UsuarioDeletarRequest, ContaCorrente>();
            CreateMap<UsuarioObterRequest, ContaCorrente>();
            CreateMap<UsuarioListarRequest, ContaCorrente>();
        }
    }
}
