using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NTTBlog.DataAccessLayer.Repositories.Abstract;
using NTTBlog.DataAccessLayer.Repositories.Concretes;
using NTTBlog.DataAccessLayer.UnitOfWorks;
using NTTBlog.Service.Helpers.ImageHelper;
using NTTBlog.Service.Services.Abstraction;
using NTTBlog.Service.Services.Concrete;
using NTTBlog.Service.Validation;
using NTTDATA.DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NTTBlog.Service.Extension
{
    public static class DependecyInjection 
    {
        public static IServiceCollection LoadServiceLayerDI(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddScoped<IArticleService, ArticleService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IImageHelper, ImageHelper>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddAutoMapper(assembly);

            services
            .AddFluentValidationAutoValidation()
            .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
