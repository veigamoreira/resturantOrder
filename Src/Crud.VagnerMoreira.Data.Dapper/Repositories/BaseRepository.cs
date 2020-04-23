using System;
using Crud.VagnerMoreira.Domain.Interfaces.Repositories;

namespace Crud.VagnerMoreira.Data.Dapper.Repositories
{
    public abstract class BaseRepository : IDisposable
    {
        protected readonly string _connectionString;
        protected readonly IUnitOfWork _unitOfWork;

        public BaseRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Dispose()
        {
            if (_unitOfWork != null) _unitOfWork.Connection.Dispose();
        }
    }
}