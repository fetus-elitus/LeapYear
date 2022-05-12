using Data.Repository;
using Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Services;

namespace Services.Injection;

public static class InjectClass
{
    public static IServiceCollection AddProjectService(this IServiceCollection services)
    {
        
        services.AddTransient<IPersonRepository, PersonRepository>();
        services.AddTransient<IUserRepository,  UserRepository>();
        services.AddTransient<IPersonUserService, PersonUserService>();

        return services;
    }
}
