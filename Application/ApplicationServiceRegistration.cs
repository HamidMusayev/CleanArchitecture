using System.Reflection;
using Application.Mappings;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // Register MediatR for CQRS (Automatically scans all handlers)
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

        // Register AutoMapper (for DTO mapping)
        services.AddAutoMapper(typeof(ProductsMappingProfile));

        // Register FluentValidation (for request validation)
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        // Register Validation Behavior for MediatR Pipeline
        //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        return services;
    }
}