using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Altairis.TrailingSlashMiddleware;

public class TrailingSlashMiddleware(RequestDelegate next, IOptions<TrailingSlashMiddlewareOptions> options) {

    public async Task Invoke(HttpContext context) {
        // Do not do anything if the request is for the root
        if (context.Request.Path.Value != "/") {

            // Add or remove trailing slash
            var newPath = options.Value.Mode switch {
                TrailingSlashMiddlewareMode.Remove => context.Request.Path.Value!.EndsWith("/") ? context.Request.Path.Value[..^1] : null,
                TrailingSlashMiddlewareMode.Add => context.Request.Path.Value!.EndsWith("/") ? null : context.Request.Path.Value + "/",
                _ => throw new InvalidOperationException("Invalid mode.")
            };

            // Redirect if necessary
            if (newPath != null) {
                context.Response.Redirect(newPath, options.Value.PermanentRedirect, options.Value.PreserveMethod);
                return;
            }
        }

        // Call next middleware
        await next(context);
    }

}
