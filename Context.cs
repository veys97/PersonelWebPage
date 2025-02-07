using Microsoft.EntityFrameworkCore;

namespace VeyselAlanWebPage.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<AdminUser> AdminUsers { get; set; }
        public DbSet<IndexPage> IndexPages { get; set; }
        public DbSet<Icons> Icons { get; set; }
        public DbSet<PortfolioItem> PortfolioItems { get; set; } // Hata düzeltilmiş hali
    }
}
