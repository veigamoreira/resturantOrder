namespace Crud.VagnerMoreira.Domain.Models
{
    public class Lancamento : Base
    {

        public string ContaOrigem { get; private set; }

        public string ContaDestino { get; private set; }

        public decimal Valor { get; private set; }

    }
}
