using Autofac;
using HelperMath.DataAccess.DataContext;
using HelperMath.Web.ServiceCollection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace HelperMath.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public Startup(IHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsetings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            this.Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                    .AddNewtonsoftJson(options =>
                        options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver()
                    )
                    .AddJsonOptions(o =>
                    {
                        o.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                    });

            services.AddEntityFrameworkNpgsql().AddDbContext<DataContext>(options =>
            {
                options.UseLazyLoadingProxies()
                       .UseNpgsql(Configuration.GetConnectionString("DefaultConnection"), 
                                    assembly => assembly.MigrationsAssembly("HelperMath.DataAccess.Migrations"));
            });

            services.AddTransient<IDataContext, DataContext>();
            services.AddTelegramBotClient(Configuration);
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            Domain.Program.Start(builder);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
