using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Altairis.TrailingSlashMiddleware;

public static class TrailingSlashMiddlewareExtensions {

    public static IServiceCollection AddTrailingSlashMiddleware(this IServiceCollection services, Action<TrailingSlashMiddlewareOptions> configureOptions) {
        return services.Configure(configureOptions);

    }

    public static IApplicationBuilder UseTrailingSlashMiddleware(this IApplicationBuilder builder) {
        return builder.UseMiddleware<TrailingSlashMiddleware>();
    }

}