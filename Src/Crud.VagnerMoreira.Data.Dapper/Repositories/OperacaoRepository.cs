using Dapper;
using System.Collections.Generic;
using Crud.VagnerMoreira.Domain.Interfaces.Repositories;
using Crud.VagnerMoreira.Domain.Models;

namespace Crud.VagnerMoreira.Data.Dapper.Repositories
{
    public class OperacaoRepository : BaseRepository, IOperacaoRepository
    {
        public OperacaoRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public int Adicionar(Lancamento request)
        {
            string sql = "" +
                         " INSERT INTO " +
                         " tb_Lancamento (ContaOrigem, ContaDestino, Valor) " +
                         " VALUES  (@ContaOrigem, @ContaDestino,@Valor);" +
                         " SELECT SCOPE_IDENTITY();";

            var id = _unitOfWork.Connection.ExecuteScalar<int>(sql, request);
            return id;

        }

        public int AtualizarConta(ContaCorrente request)
        {
            string sql = "" +
                         " UPDATE " +
                         " tb_ContaCorrente SET Saldo = @Saldo " +
                         " WHERE NumeroConta = @NumeroConta" +
                         " SELECT SCOPE_IDENTITY();";

            var id = _unitOfWork.Connection.ExecuteScalar<int>(sql, request);
            return id;

        }

        public ContaCorrente Obter(ContaCorrente request)
        {
            string sql = "SELECT *  FROM tb_ContaCorrente WHERE NumeroConta = @NumeroConta";
            ContaCorrente response = _unitOfWork.Connection.QueryFirst<ContaCorrente>(sql, request);
            return response;
        }
    }
}
