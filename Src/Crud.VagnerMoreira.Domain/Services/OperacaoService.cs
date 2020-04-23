using System.Collections.Generic;
using System.Linq;
using Crud.VagnerMoreira.Domain.Interfaces.Repositories;
using Crud.VagnerMoreira.Domain.Interfaces.Services;
using Crud.VagnerMoreira.Domain.Models;

using Crud.VagnerMoreira.Domain.Validacoes;

namespace Crud.VagnerMoreira.Domain.Services
{
    public class OperacaoService : IOperacaoService
    {
        private readonly OperacaoValidacao _OperacaoValidacao;
        private readonly IOperacaoRepository _OperacaoRepository;

        public OperacaoService(OperacaoValidacao operacaoValidacao, IOperacaoRepository operacaoRepository)
        {
            _OperacaoValidacao = operacaoValidacao;
            _OperacaoRepository = operacaoRepository;
        }

        public ContaCorrente Adicionar(Lancamento request)
        {
            // Crio o objeto de response
            ContaCorrente contaCorrenteOrigem = new ContaCorrente();
            ContaCorrente contaCorrenteDestino = new ContaCorrente();

            // Validação de regras de negócio
            _OperacaoValidacao.ValidarOperacao(request);
            if (_OperacaoValidacao.Erros.Any())
            {
                contaCorrenteOrigem.Erros = _OperacaoValidacao.Erros;
                return contaCorrenteOrigem;
            }

            // Chama o Repositoy
            contaCorrenteOrigem.NumeroConta = request.ContaOrigem;
            contaCorrenteDestino.NumeroConta = request.ContaDestino;

            var contaOrigem = _OperacaoRepository.Obter(contaCorrenteOrigem);
            var contaDestino = _OperacaoRepository.Obter(contaCorrenteDestino);


            _OperacaoValidacao.ValidarConta(contaOrigem);

            if (_OperacaoValidacao.Erros.Any())
            {
                contaCorrenteOrigem.Erros = _OperacaoValidacao.Erros;
                return contaCorrenteOrigem;
            }

            _OperacaoValidacao.ValidarSaldoConta(request.Valor, contaOrigem.Saldo);

            if (_OperacaoValidacao.Erros.Any())
            {
                contaCorrenteOrigem.Erros = _OperacaoValidacao.Erros;
                return contaCorrenteOrigem;
            }


            //Efetivando a transacao
            _OperacaoRepository.Adicionar(request);

            contaCorrenteDestino.Saldo = contaCorrenteDestino.Saldo + request.Valor;
            contaCorrenteOrigem.Saldo = contaCorrenteOrigem.Saldo - request.Valor;

            //debito e crédito
            _OperacaoRepository.AtualizarConta(contaCorrenteDestino);
            _OperacaoRepository.AtualizarConta(contaCorrenteOrigem);


            // Retorna
            return contaCorrenteOrigem;
        }

       
    }
}
