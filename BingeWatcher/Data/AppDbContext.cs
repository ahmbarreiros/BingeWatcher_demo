using BingeWatcher.Models;
using Microsoft.EntityFrameworkCore;

namespace BingeWatcher.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Anime> Animes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Anime>().HasData(
                new Anime { Id = 1, Title = "Dummy Title", Main_Picture = new object(), Media_Type = "tv", Status = "currently_airing", Number_Of_Episodes = 1}
            );
        }
    }
}
