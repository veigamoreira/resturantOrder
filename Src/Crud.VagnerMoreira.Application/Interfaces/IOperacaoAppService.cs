using System.Collections.Generic;
using Crud.VagnerMoreira.Application.ViewModels;

namespace Crud.VagnerMoreira.Application.Interfaces
{
    public interface IOperacaoAppService
    {
        OrderResponse Order(string request);
    }
}
