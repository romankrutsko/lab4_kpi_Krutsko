using AutoSklad.Core.GlobalSklad;
using AutoSklad.Core.LocalStore;
using AutoSklad.Data;
using AutoSklad.Data.GlobalSklad;
using AutoSklad.Data.LocalStore;
using AutoSklad.Orchestrators.GlobalSklad;
using AutoSklad.Orchestrators.GlobalSklad.Contract;
using AutoSklad.Orchestrators.LocalStore;
using AutoSklad.Orchestrators.LocalStore.Contract;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace AutoSklad.Onion
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var conntectioneString = Configuration.GetConnectionString("AutoSkladDB");
            services.AddDbContext<AutoSkladContext>(options => options.UseNpgsql(conntectioneString));
            ;


            services.AddAutoMapper(typeof(DaoLocalStoreProfile), typeof(DaoGlobalSkladProfile),
                typeof(LocalStoreOrchProfile),
                typeof(GlobalSkladOrchProfile));

            services.AddScoped<ILocalStoreService, LocalStoreService>();
            services.AddScoped<ILocalStoreRepository, LocalStoreRepository>();

            services.AddScoped<ISkladService, GlobalSkladService>();
            services.AddScoped<ISkladRepository, GlobalSkladRepository>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "AutoSklad.Onion", Version = "v1"});
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AutoSklad.Onion v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}