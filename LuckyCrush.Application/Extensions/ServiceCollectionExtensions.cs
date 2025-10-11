using FluentValidation;
using FluentValidation.AspNetCore;
using LuckyCrush.Application.Users;
using Microsoft.Extensions.DependencyInjection;


namespace Template.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        var applicationAssembly = typeof(ServiceCollectionExtensions).Assembly;

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(applicationAssembly));
        services.AddHttpContextAccessor();

        services.AddValidatorsFromAssembly(applicationAssembly)
                .AddFluentValidationAutoValidation();

        services.AddAutoMapper(applicationAssembly);
        services.AddTransient<IUserContext, UserContext>();
    }
}