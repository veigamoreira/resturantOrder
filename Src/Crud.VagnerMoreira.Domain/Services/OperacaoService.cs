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

        public Order Order(string order)
        {
            try
            {

                string retorno = string.Empty;
                if (string.IsNullOrEmpty(order))
                {
                    _OperacaoValidacao.NotifyErro();
                    Order ret = new Order { Erros = _OperacaoValidacao.Erros };
                    return ret;
                }

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
                    {
                        _OperacaoValidacao.NotifyErro();
                        Order ret = new Order { Erros = _OperacaoValidacao.Erros };
                        return ret;

                    }
                }
                else
                {
                    _OperacaoValidacao.NotifyErro();
                    Order ret = new Order { Erros = _OperacaoValidacao.Erros };
                    return ret;
                }
            }
            catch (Exception)
            {
                throw;
            }


            return null;
        }

        private Order GetMorningOrder(string[] orderArray)
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

            return new Order() { OrderResponse = retorno.ToString() };
        }

        private Order GetNigthOrder(string[] orderArray)
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
            return new Order() { OrderResponse = retorno.ToString() };
        }
    }
}