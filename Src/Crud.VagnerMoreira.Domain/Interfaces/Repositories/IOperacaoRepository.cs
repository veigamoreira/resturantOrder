using System.Collections.Generic;
using Crud.VagnerMoreira.Domain.Models;

namespace Crud.VagnerMoreira.Domain.Interfaces.Repositories
{
    public interface IOperacaoRepository
    {
        int Adicionar(Lancamento request);

        ContaCorrente Obter(ContaCorrente request);

        int AtualizarConta(ContaCorrente request);
    }
}
