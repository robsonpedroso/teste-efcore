using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEFCore.Domain.Contracts.Repositories;

namespace TestEFCore.Infra.Provider
{

    public class EFUnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly StoreDBContext context;

        private IUnitOfWorkTransaction transaction;
        private DbConnection dbConnection;

        public EFUnitOfWork(StoreDBContext context)
        {
            this.context = context;
        }

        public IUnitOfWork Open()
        {
            dbConnection = context.Database.GetDbConnection();
            dbConnection.Open();
            return this;
        }


        public IUnitOfWorkTransaction BeginTransaction()
        {
            if (dbConnection == null || dbConnection.State != System.Data.ConnectionState.Open)
            {
                Open();
            }
            else
            {
                if (transaction != null)
                    transaction.Dispose();
            }

            transaction = new EFTransaction(dbConnection);

            return transaction;
        }

        public object GetContext()
        {
            return context;
        }

        public void Dispose()
        {
            transaction?.Dispose();

            dbConnection?.Dispose();

            GC.SuppressFinalize(this);
        }
    }
}
