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


        public void NotifyErro()
        {
            LimpaErros();

            Erros.Add(new Erro
            {
                Codigo = 400,
                Descricao = "Invalid Order Request"
            });
        }
    }


}

