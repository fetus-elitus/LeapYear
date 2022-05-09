using Data.Repository;
using Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Services;

namespace Services.Injection;

public static class InjectClass
{
    public static IServiceCollection AddProjectService(this IServiceCollection services)
    {
        services.AddTransient<IPersonService, PersonService>();
        services.AddTransient<IPersonRepository, PersonRepository>();
        return services;
    }
}
