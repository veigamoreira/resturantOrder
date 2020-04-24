using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public string Order(string order)
        {
            string retorno = string.Empty;
            var orderArray = order.Split(",");
            if (orderArray.Any())
            {
                //GetMorning Order
                if (orderArray[0].ToLower().Trim() == "morning")
                {
                    return GetMorningOrder(orderArray);
                }              
                //GetNight Order
                else if (orderArray[0].ToLower().Trim() == "night")
                {
                    return GetNigthOrder(orderArray);
                }
                // Nothing on first array position
                else
                    return retorno;
            }

            return string.Empty;
        }
        private string GetMorningOrder(string[] orderArray)
        {
            StringBuilder retorno = new StringBuilder();
            int[] dishesMorning = { (int)DysheType.entrée, (int)DysheType.side, (int)DysheType.drink };

            if (orderArray.Any())
            {

                if (orderArray[1] != null)
                {
                    bool controlDrink = false;
                    var disheSequence = orderArray.Where(t => t.ToString() != "morning");
                    foreach (var item in disheSequence)
                    {
                        if (!string.IsNullOrEmpty(item))
                        {
                            //Checking order aplly to the Dishes Avaliable
                            if (dishesMorning.ToList().Contains(int.Parse(item)))
                            {
                                //Count the Coffes
                                if (int.Parse(item) == (int)DysheType.drink)
                                {
                                    if (!controlDrink)
                                    {
                                        int qty = disheSequence.Where(t => t.ToString().Trim() == "3").Count();
                                        if (int.Parse(item) == (int)DysheType.drink && qty > 1)
                                            retorno.Append(Enum.GetName(typeof(DysheMorning), int.Parse(item)).ToString() + " x" + qty + ",");
                                        else
                                            retorno.Append(Enum.GetName(typeof(DysheMorning), int.Parse(item)).ToString() + ",");

                                        controlDrink = true;
                                    }
                                }
                                else
                                    retorno.Append(Enum.GetName(typeof(DysheMorning), int.Parse(item)).ToString() + ",");
                            }
                            else
                            {
                                retorno.Append("Error, ");
                            }
                        }
                    }
                }
                else
                {
                    retorno.Append("Error, ");
                }
            }

            return retorno.ToString();
        }

        private string GetNigthOrder(string[] orderArray)
        {
            StringBuilder retorno = new StringBuilder();
            int[] dishesNight = { (int)DysheType.entrée, (int)DysheType.side, (int)DysheType.drink, (int)DysheType.dessert };

            if (orderArray.Any())
            {
                if (orderArray[1] != null)
                {
                    bool controlDrink = false;
                    var disheSequence = orderArray.Where(t => t.ToString() != "night");
                    foreach (var item in disheSequence)
                    {
                        if (!string.IsNullOrEmpty(item))
                        {
                            //Checking order aplly to the Dishes Avaliable
                            if (dishesNight.ToList().Contains(int.Parse(item)))
                            {
                                if (int.Parse(item) == (int)DysheType.side)
                                {
                                    //Count the Potatos
                                    if (!controlDrink)
                                    {
                                        int qty = disheSequence.Where(t => t.ToString().Trim() == "2").Count();
                                        if (int.Parse(item) == (int)DysheType.drink && qty > 1)
                                            retorno.Append(Enum.GetName(typeof(DysheNight), int.Parse(item)).ToString() + " x" + qty + ",");
                                        else
                                            retorno.Append(Enum.GetName(typeof(DysheNight), int.Parse(item)).ToString() + ",");

                                        controlDrink = true;
                                    }
                                }
                                else
                                    retorno.Append(Enum.GetName(typeof(DysheNight), int.Parse(item)).ToString() + ",");
                            }
                            else
                            {
                                retorno.Append("Error, ");
                            }
                        }
                    }
                }
                else
                {
                    retorno.Append("Error, ");
                }
            }

            return retorno.ToString();

        }
    }
}