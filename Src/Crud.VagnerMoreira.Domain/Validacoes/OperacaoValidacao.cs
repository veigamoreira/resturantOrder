using System.Collections.Generic;
using Crud.VagnerMoreira.Domain.Models;

namespace Crud.VagnerMoreira.Domain.Validacoes
{
    public class OperacaoValidacao
    {
        public List<Erro> Erros { get; private set; }

        private void LimpaErros()
        {
            Erros = new List<Erro>(0);
        }

        private void ValidarId(int valor)
        {
            if (valor <= 0)
            {
                Erros.Add(new Erro
                {
                    Codigo = 400,
                    Descricao = "Id é obrigatório"
                });
            }
        }

        private void ValidarContaDestino(string valor)
        {
            if (string.IsNullOrEmpty(valor))
            {
                Erros.Add(new Erro
                {
                    Codigo = 400,
                    Descricao = "Conta Destino é obrigatório"
                });
            }
        }

        private void ValidarContaOrigem(string valor)
        {
            if (string.IsNullOrEmpty(valor))
            {
                Erros.Add(new Erro
                {
                    Codigo = 400,
                    Descricao = "Conta origem é obrigatório"
                });
            }
        }

        private void ValidarEmail(string valor)
        {
            if (string.IsNullOrEmpty(valor))
            {
                Erros.Add(new Erro
                {
                    Codigo = 400,
                    Descricao = "E-mail é obrigatório"
                });
            }
        }

        private void ValidarDataNascimento(string valor)
        {
            if (string.IsNullOrEmpty(valor))
            {
                Erros.Add(new Erro
                {
                    Codigo = 400,
                    Descricao = "Data de nascimento é obrigatório"
                });
            }
        }


        private void ValidarValor(decimal valor)
        {
            if ((valor == 0))
            {
                Erros.Add(new Erro
                {
                    Codigo = 400,
                    Descricao = "Valor é obrigatório"
                });
            }
        }


        private void ValidarSaldo(decimal valor, decimal saldo)
        {
            if ((valor > saldo))
            {
                Erros.Add(new Erro
                {
                    Codigo = 400,
                    Descricao = "Saldo Insuficiente"
                });
            }
        }


        public void ValidarConta(ContaCorrente conta)
        {
            if (conta == null)
            {
                Erros.Add(new Erro
                {
                    Codigo = 400,
                    Descricao = "Conta inválida"
                });
            }
        }

        public void ValidarOperacao(Lancamento request)
        {
            LimpaErros();
            ValidarContaDestino(request.ContaDestino);
            ValidarContaOrigem(request.ContaOrigem);
            ValidarValor(request.Valor);
        }

        public void ValidarSaldoConta(decimal valor, decimal saldo)
        {
            ValidarSaldo(valor, saldo);
        }
    }
}
