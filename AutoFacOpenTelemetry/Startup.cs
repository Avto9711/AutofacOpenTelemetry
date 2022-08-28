using Autofac;
using Autofac.Extensions.DependencyInjection;
using OpenTelemetry.Metrics;

namespace AutoFacOpenTelemetry
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {

            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; private set; }

        public ILifetimeScope AutofacContainer { get; private set; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOpenTelemetryMetrics(builder =>
            {
                builder.AddMeter("just.to.test");
                builder.AddPrometheusExporter();
            });
            services.AddOptions();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {

        }

        public void Configure(
          IApplicationBuilder app,
          ILoggerFactory loggerFactory)
        {
            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            //app.UseAuthorization();
            app.UseOpenTelemetryPrometheusScrapingEndpoint();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
