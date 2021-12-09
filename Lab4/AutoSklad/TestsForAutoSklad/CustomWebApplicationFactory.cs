using System;
using System.Linq;
using AutoMapper;
using AutoSklad.Data;
using AutoSklad.Data.GlobalSklad;
using AutoSklad.Data.LocalStore;
using AutoSklad.Onion;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace TestsForAutoSklad
{
    public class CustomWebApplicationFactory :  WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                RemoveLibraryDbContextRegistration(services);

                var serviceProvider = GetInMemoryServiceProvider();

                services.AddDbContextPool<AutoSkladContext>(options =>
                {
                    options.UseInMemoryDatabase(Guid.Empty.ToString());
                    options.UseInternalServiceProvider(serviceProvider);
                });

                using (var scope = services.BuildServiceProvider().CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<AutoSkladContext>();

                    UnitTestHelper.SeedData(context);
                }
            });
        }
        private static ServiceProvider GetInMemoryServiceProvider()
        {
            return new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();
        }
        private static void RemoveLibraryDbContextRegistration(IServiceCollection services)
        {
            var descriptor = services.SingleOrDefault(
                d => d.ServiceType ==
                     typeof(DbContextOptions<AutoSkladContext>));

            if (descriptor != null)
            {
                services.Remove(descriptor);
            }
        }
    }
    public class UnitTestHelper
    {
        public static DbContextOptions<AutoSkladContext> GetUnitTestDbOptions()
        {
            var options = new DbContextOptionsBuilder<AutoSkladContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            using (var context = new AutoSkladContext(options))
            {
                SeedData(context);
            }
            return options;
        }

        public static void SeedData(AutoSkladContext context)
        {
            context.Sklads.Add(new GlobalSkladDto()
            {
                Id = 1, Count = 1233143, Description = "fafsfqfewq", Location = "ewrweqrwdf", NameOfThing = "effqwfa",
            });
            context.LocalStores.Add(new LocalStoreDto()
            {
                Id = 1, Location = "ghfhaoirg[", Naming = "32ewknlfk;fro32", SkladId = 1, Count = 1231
            });
            context.SaveChanges();
        }

        public static Mapper CreateMapperProfile()
        {
            var myProfile = new DaoGlobalSkladProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));

            return new Mapper(configuration);
        }
    }
}