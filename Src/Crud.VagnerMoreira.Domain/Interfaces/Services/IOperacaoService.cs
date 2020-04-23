using System.Collections.Generic;
using Crud.VagnerMoreira.Domain.Models;

namespace Crud.VagnerMoreira.Domain.Interfaces.Services
{
    public interface IOperacaoService
    {
        ContaCorrente Adicionar(Lancamento request);
    }
}
