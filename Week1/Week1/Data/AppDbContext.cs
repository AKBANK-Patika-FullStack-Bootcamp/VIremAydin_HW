using Microsoft.EntityFrameworkCore;
using Week1.Model;

namespace Week1.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Book> demoInfo { get; set; }
    }
}
