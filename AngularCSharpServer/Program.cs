using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.StaticFiles; // Добавлено
using System.IO;

var host = new WebHostBuilder()
    .UseKestrel()
    .UseContentRoot(Directory.GetCurrentDirectory())
    .UseUrls("http://localhost:5000")
    .Configure(app =>
    {
        // Раздача статики Angular
        app.UseStaticFiles(new StaticFileOptions
        {
            FileProvider = new PhysicalFileProvider(
                Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")),
        });

        // API-эндпоинт
        app.Map("/api/hello", (IApplicationBuilder api) =>
        {
            api.Run(async context =>
            {
                await context.Response.WriteAsync("Hello from C# API!");
            });
        });

        // Все остальные запросы → index.html
        app.Run(async context =>
        {
            await context.Response.SendFileAsync(
                Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "index.html"));
        });
    })
    .Build();

host.Run();