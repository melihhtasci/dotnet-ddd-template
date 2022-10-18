
using API.Common;

namespace API;

public static class DependencyInjection
{
    public static IServiceCollection AddApi(this IServiceCollection services)
    {
        services.AddMapping();
        return services;
    }
}