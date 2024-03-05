[![NuGet Status](https://img.shields.io/nuget/v/Altairis.TrailingSlashMiddleware.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Altairis.TrailingSlashMiddleware/)

# Altairis. Trailing Slash Middleware
ASP.NET Core Middleware for adding or removing trailing slashes to URLs.

## Usage

Add the middleware to your application in `Program.cs`:

```csharp
app.UseTrailingSlashMiddleware();
```

This will remove trailing slashes from all URLs; incoming requests with trailing slashes will be redirected to the same URL without the trailing slash using permanent redirect with preserving HTTP method and query string.

You can change this behavior by providing options (the following are defaults):

```csharp
builder.Services.AddTrailingSlashMiddleware(options => {
    options.Mode = TrailingSlashMiddlewareMode.Remove;
    options.PermanentRedirect = true;
    options.PreserveMethod = true;
});
```

[![Logo Altairis](NuGet-64x64.png)](https://www.altairis.cz/)

## Contributor Code of Conduct

This project adheres to No Code of Conduct. We are all adults. We accept anyone's contributions. Nothing else matters.

For more information please visit the [No Code of Conduct](https://github.com/domgetter/NCoC) homepage.