using CourseShop.Application.ApplicationUser;
using CourseShop.Application.Course.Commands.CreateCourse;
using CourseShop.Application.DTOs;
using CourseShop.Application.Mappings;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;


namespace CourseShop.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateCourseCommand)); // rejestracja mediatora i komend, wszytskich, nie musimy rejestrowac ich z osobna

            services.AddAutoMapper(typeof(CourseMapper), typeof(CategoryMapper), typeof(DifficultyLevelMapper));
            services.AddValidatorsFromAssemblyContaining<CreateCourseCommandValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
            services.AddScoped<IUserContext, UserContext>();
        }
    }
}
