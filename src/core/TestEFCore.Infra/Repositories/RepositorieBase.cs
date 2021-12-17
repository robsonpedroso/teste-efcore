using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEFCore.Domain.Contracts.Repositories;
using TestEFCore.Domain.Entities;
using TestEFCore.Infra.Provider;

namespace TestEFCore.Infra.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private IDbConnection _dbConnection;
        private DbContext _dbContext;
        public RepositoryBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected DbContext Context
        {
            get
            {
                if (_dbContext == null)
                    _dbContext = _unitOfWork.GetContext() as DbContext;

                return _dbContext;
            }
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }

        public async Task<bool> Insert(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(entity)} entity must not be null");
            }

            try
            {
                await Context.Set<TEntity>().AddAsync(entity);
                Save();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be saved: {ex.Message}");
            }
        }

        public async Task<bool> Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(entity)} entity must not be null");
            }

            try
            {
                Context.Set<TEntity>().Update(entity);
                Save();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be updated: {ex.Message}");
            }
        }

        public async Task<bool> Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException($"{nameof(id)} entity must not be null");
            }

            try
            {
                var entity = await Context.Set<TEntity>().FindAsync(id);
                Context.Set<TEntity>().Remove(entity);
                Save();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(id)} could not be deleted: {ex.Message}");
            }
        }

        public async Task<TEntity> Find(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException($"{nameof(id)} entity must not be null");
            }

            try
            {
                return await Context.Set<TEntity>().FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(id)} could not be deleted: {ex.Message}");
            }
        }



        public async Task<bool> Save()
        {
            await Context.SaveChangesAsync();
            return true;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
