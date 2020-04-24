﻿using AutoMapper;
using Crud.VagnerMoreira.Application.ViewModels;
using Crud.VagnerMoreira.Domain.Models;

namespace Crud.VagnerMoreira.Application.AutoMapper
{
    public class ModelToViewModel : Profile
    {
        public ModelToViewModel()
        {
            CreateMap<Order, OrderResponse>();
            CreateMap<Erro, ErroViewModel>();
        }
    }
}
