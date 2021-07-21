using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Bookworm.DAL.PostgreSQL.EF.WebApi
{
    using Bookworm.DAL.PostgreSQL.EF.Context;
    using Microsoft.EntityFrameworkCore;
    using System;

    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureContext(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }

        private void ConfigureContext(IServiceCollection services)
        {
            var connection = Configuration?.GetSection("DbConnectionOptions")?.GetSection("ConnectionString")?.Value;
            var schemaName = Configuration?.GetSection("DbConnectionOptions")?.GetSection("MigrationSchemaName")?.Value;

            services.AddDbContext<BookwormContext>(
                options => options.UseNpgsql(
                    connection ?? throw new ArgumentNullException(nameof(connection), " has a null connection string."),
                    c => c.MigrationsHistoryTable("__EFMigrationsHistory", schemaName)));
        }
    }
}
