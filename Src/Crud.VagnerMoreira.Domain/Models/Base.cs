using System;
using System.Collections.Generic;

namespace Crud.VagnerMoreira.Domain.Models
{
    public abstract class Base
    {
        public int Id { get; set; }

        public int IdUsuarioCadastro { get; set; }

        public int? IdUsuarioAlteracao { get; set; }

        public int? IdUsuarioExclusao { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime? DataAlteracao { get; set; }

        public DateTime? DataExclusao { get; set; }

        public List<Erro> Erros { get; set; }
    }
}
