using Microsoft.EntityFrameworkCore;
using NTTBlog.Core.Entites;
using NTTBlog.DataAccessLayer.Repositories.Abstract;
using NTTDATA.DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NTTBlog.DataAccessLayer.Repositories.Concretes
{
    public class Repository<T> : IRepository<T> where T : BaseEntity 

    {
        private readonly UygulamaDbContext _dbContext;
        
        public Repository(UygulamaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        private DbSet<T> Table { get => _dbContext.Set<T>(); }

        public async Task<List<T>> GetAllAsync(Expression<Func<T,bool>> predicate = null, params Expression<Func<T, object>>[] includeProp)
        {
            IQueryable<T> query = Table;
            if(predicate != null)
            {
                query = query.Where(predicate);
            }
            if (includeProp.Any())
            {
                foreach(var item in includeProp)
                {
                    query = query.Include(item);
                }
            }
            return await query.ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await Table.AddAsync(entity);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate , params Expression<Func<T, object>>[] includeProp)
        {
            IQueryable<T> query = Table;
            query = query.Where(predicate);
            if (includeProp.Any())
            {
                foreach (var item in includeProp)
                {
                    query = query.Include(item);
                }
            }

            return await query.SingleOrDefaultAsync(); // FirstOrDefault sadece 1 deger alir 

        }

        public async Task<T> GetByGuidAsync(Guid id)
        {
            return await Table.FindAsync(id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            await Task.Run(()=>Table.Update(entity));
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            await Task.Run(() => Table.Remove(entity));
            
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await Table.AnyAsync(predicate);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate = null)
        {
            return await Table.CountAsync(predicate);
        }
    }
}
