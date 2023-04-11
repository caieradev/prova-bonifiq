using System.Reflection;
using ProvaPub.Services;
using ProvaPub.Repositories;

namespace ProvaPub.Extensions;

public static class IServiceCollectionExtensions
{
    public static void RegisterIoCs(this IServiceCollection services)
    {
        Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(x => typeof(IRepository).IsAssignableFrom(x) && !x.IsAbstract)
            .ToList()
            .ForEach(x => services.AddTransient(x));

        Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(x => typeof(IService).IsAssignableFrom(x) && !x.IsAbstract)
                .ToList()
                .ForEach(x => services.AddScoped(x));
    }
}
