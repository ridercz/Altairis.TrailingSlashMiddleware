using Altairis.TrailingSlashMiddleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// You can configure the middleware (the following is the default configuration)
builder.Services.AddTrailingSlashMiddleware(options => {
    options.Mode = TrailingSlashMiddlewareMode.Remove;
    options.PermanentRedirect = true;
    options.PreserveMethod = true;
});

// If you want to add slashes instead of removing them, change also the route options, so they are appended to generated URLs
//builder.Services.Configure<RouteOptions>(options => {
//    options.AppendTrailingSlash = true;
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

// For default configuration only the following line is needed
app.UseTrailingSlashMiddleware();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
