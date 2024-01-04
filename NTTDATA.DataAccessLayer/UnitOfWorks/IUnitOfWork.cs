using NTTBlog.Core.Entites;
using NTTBlog.DataAccessLayer.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTTBlog.DataAccessLayer.UnitOfWorks
{
    public interface IUnitOfWork :IAsyncDisposable
    {
        IRepository<T> GetRepository<T>() where T : BaseEntity;

        Task<int> SaveAsync();
        int Save();
    }
}
