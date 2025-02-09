﻿using AutoMapper;
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
        private readonly IOperacaoService _operacaoService;
        private readonly IUnitOfWork _unitOfWork;

        public OperacaoAppService(IMapper mapper, IOperacaoService OperacaoService, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _operacaoService = OperacaoService;
            _unitOfWork = unitOfWork;
        }

        public OrderResponse Order(string request)
        {
            // Criei o UnitOfWork para mostrar um controle de transação com o dapper quando for preciso
            using (_unitOfWork)
            {
                // Inicia a transação
                //_unitOfWork.BeginTransaction();

                // Faz o mapeamento para a model e chama a service
                string order = request;
                var responseModel = _operacaoService.Order(order);

                if (responseModel.Erros != null && responseModel.Erros.Count > 0)
                {
                    OrderResponse response2 = new OrderResponse();
                    response2.Erros = new List<ErroViewModel>();
                    foreach (var item in responseModel.Erros)
                    {
                        response2.Erros.Add(new ErroViewModel { Descricao = item.Descricao, Codigo = item.Codigo });
                    }

                    return response2;
                }
                // Mapemento do response e retorna para a api
                OrderResponse response = new OrderResponse() { order = responseModel.OrderResponse.ToString() };
                return response;

            }
        }

    }
}
