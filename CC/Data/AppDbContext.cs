using CC.Model;
using Microsoft.EntityFrameworkCore;


namespace CC.Data
{
        public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

            public DbSet<Record> Records { get; set; }
        }
    }
