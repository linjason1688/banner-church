using System.Reflection;
using App.Application.Common.Behaviours;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Yozian.DependencyInjectionPlus;

namespace App.Application
{
    /// <summary>
    /// </summary>
    public static class ApplicationRegister
    {
        /// <summary>
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static IServiceCollection AddApplication(this IServiceCollection @this)
        {
            @this.AddAutoMapper(Assembly.GetExecutingAssembly());
            @this.AddMediatR(Assembly.GetExecutingAssembly());
            @this.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            @this.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
            @this.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            // register current assembly only
            @this.RegisterServicesOfAssembly(Assembly.GetExecutingAssembly());

            return @this;
        }
    }
}
