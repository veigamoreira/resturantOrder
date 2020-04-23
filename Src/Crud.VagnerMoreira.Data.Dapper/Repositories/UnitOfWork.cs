using System;
using System.Data;
using Crud.VagnerMoreira.Domain.Interfaces.Repositories;

namespace Crud.VagnerMoreira.Data.Dapper.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool disposed = false;

        public IDbConnection Connection { get; } = null;

        public IDbTransaction Transaction { get; private set; } = null;

        public UnitOfWork(IDbConnection connection)
        {
            Connection = connection;
            Connection.Open();
        }

        public void BeginTransaction()
        {
            if (Transaction == null)
            {
                Transaction = Connection.BeginTransaction(IsolationLevel.ReadCommitted);
            }
        }

        public void CommitTransaction()
        {
            if (Transaction != null)
            {
                Transaction.Commit();
            }
        }

        public void RollBack()
        {
            if (Transaction != null)
            {
                Transaction.Rollback();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed && disposing && Transaction != null)
            {
                Transaction.Dispose();

                Connection.Close();
                Connection.Dispose();
            }
            disposed = true;
        }
    }
}
