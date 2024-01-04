using NTTBlog.Core.Entites;
using NTTBlog.DataAccessLayer.Repositories.Abstract;
using NTTBlog.DataAccessLayer.Repositories.Concretes;
using NTTDATA.DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTTBlog.DataAccessLayer.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UygulamaDbContext _dbContext;
        public UnitOfWork(UygulamaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async ValueTask DisposeAsync()
        {
            await _dbContext.DisposeAsync();
        }

        public IRepository<T> GetRepository<T>() where T : BaseEntity
        {
            return new Repository<T>(_dbContext);
        }

        public int Save()
        {
            return _dbContext.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
