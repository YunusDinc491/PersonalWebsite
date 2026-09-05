using Microsoft.EntityFrameworkCore;
using PersonalWebsite.Models;

namespace PersonalWebsite.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}


        public DbSet<Proje> Proje { get; set; }
        public DbSet<Iletisim> Iletisim { get; set; }
        public DbSet<BeniIseAl> BeniIseAl { get; set; }

    }
}
