using AutoSklad.Data.GlobalSklad;
using AutoSklad.Data.LocalStore;
using Microsoft.EntityFrameworkCore;

namespace AutoSklad.Data
{
    public class AutoSkladContext : DbContext
    {
        public AutoSkladContext(DbContextOptions<AutoSkladContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<LocalStoreDto> LocalStores { get; set; }
        public DbSet<GlobalSkladDto> Sklads { get; set; }
    }
}