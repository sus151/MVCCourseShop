using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseShop.Domain.Interfaces;
using CourseShop.Infrastructure.Persistence;
using CourseShop.Infrastructure.Respository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CourseShop.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CourseShopDbContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("CourseShop")));
            services.AddScoped<ICourseRespository, CourseRespository>();
            services.AddScoped<ICategoryRespository, CategoryRespository>();
            services.AddScoped<IDifficultyLevelRespository,  DifficultyLevelRespository>();
            services.AddScoped<INewsRespository, NewsRespository>();
            services.AddScoped<IPromotedItemRespository, PromotedItemRespository>();
            services.AddScoped<IHighlightedCategoryRespository, HighlightedCategoryRespository>();
            services.AddScoped<ICourseStepRespository, CourseStepRespository>();
            services.AddScoped<IUserRespository, UserRespository>();

            //Identity
            
        }
    }
}
