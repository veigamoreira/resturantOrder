using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using Crud.VagnerMoreira.Application.Interfaces;
using Crud.VagnerMoreira.Application.ViewModels;
using Crud.VagnerMoreira.Domain.Interfaces.Repositories;
using Crud.VagnerMoreira.Domain.Interfaces.Services;
using Crud.VagnerMoreira.Domain.Models;

namespace Crud.VagnerMoreira.Application.AppServices
{
    public class OperacaoAppService : IOperacaoAppService
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioService _UsuarioService;
        private readonly IUnitOfWork _unitOfWork;

        public OperacaoAppService(IMapper mapper, IUsuarioService UsuarioService, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _UsuarioService = UsuarioService;
            _unitOfWork = unitOfWork;
        }

        public UsuarioAdicionarResponse Adicionar(OperacaoRequest request)
        {
            // Criei o UnitOfWork para mostrar um controle de transação com o dapper quando for preciso
            using (_unitOfWork)
            {
                // Inicia a transação
                _unitOfWork.BeginTransaction();

                // Faz o mapeamento para a model e chama a service
                ContaCorrente requestModel = _mapper.Map<ContaCorrente>(request);
                ContaCorrente responseModel = _UsuarioService.Adicionar(requestModel);

                // Commit ou RollBack
                if (responseModel.Erros != null && responseModel.Erros.Any())
                {
                    _unitOfWork.RollBack();
                }
                else
                {
                    _unitOfWork.CommitTransaction();
                }

                // Mapemento do response e retorna para a api
                UsuarioAdicionarResponse response = _mapper.Map<UsuarioAdicionarResponse>(responseModel);
                return response;
            }
        }

    }
}
