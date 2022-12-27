using Microsoft.EntityFrameworkCore;

namespace EFDemo.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<HeroModel> Heroes { get; set; }
        
    }
}
