using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NTTBlog.DataAccessLayer.Repositories.Abstract;
using NTTBlog.DataAccessLayer.Repositories.Concretes;
using NTTBlog.DataAccessLayer.UnitOfWorks;
using NTTDATA.DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTTBlog.DataAccessLayer.Extensions
{

    // Dependency Injection
    public static class DALExtensions
    {
        public static IServiceCollection LoadDALExtension(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            
            services.AddDbContext<UygulamaDbContext>(o => o.UseSqlServer(
                                  config.GetConnectionString("NTTDbContext")));
            return services;
        }

        
    }
}
