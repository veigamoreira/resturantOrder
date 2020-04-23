namespace Crud.VagnerMoreira.Domain.Models
{
    public class Lancamento : Base
    {

        public string ContaOrigem { get; set; }

        public string ContaDestino { get; set; }

        public decimal Valor { get; set; }

    }
}
