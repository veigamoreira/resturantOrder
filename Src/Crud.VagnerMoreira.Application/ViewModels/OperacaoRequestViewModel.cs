namespace Crud.VagnerMoreira.Application.ViewModels
{
    public class OperacaoRequest : BaseRequest
    {
        public string ContaOrigem { get; set; }
        public string ContaDestino { get; set; }

        public decimal Valor { get; set; }
    }
}
