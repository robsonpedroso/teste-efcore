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
    public class EFTransaction : IUnitOfWorkTransaction
    {
        private readonly DbConnection dbConnection;

        private readonly DbTransaction transaction;

        public bool IsConnectionOpen { get { return dbConnection != null && dbConnection.State == System.Data.ConnectionState.Open; } }

        public EFTransaction(DbConnection session)
        {
            this.dbConnection = session;
            transaction = session.BeginTransaction();
        }

        public async Task RollbackAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                await transaction.RollbackAsync(cancellationToken);
            }
            catch
            {
                throw;
            }
            finally
            {
                transaction.Dispose();
                dbConnection.Dispose();
            }
        }

        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                await transaction.CommitAsync(cancellationToken);
            }
            catch
            {
                await transaction.RollbackAsync(cancellationToken);

                throw;
            }
            finally
            {
                transaction.Dispose();
            }
        }

        public void Dispose()
        {
            transaction?.Dispose();

            GC.SuppressFinalize(this);
        }
    }
}
