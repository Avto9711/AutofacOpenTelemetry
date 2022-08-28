using Autofac.Extensions.DependencyInjection;
using AutoFacOpenTelemetry;

var builder = Host.CreateDefaultBuilder(args)
    .UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureWebHostDefaults(webHostBuilder => {
        webHostBuilder
            .UseStartup<Startup>();
    })
    .Build();


builder.Run();
