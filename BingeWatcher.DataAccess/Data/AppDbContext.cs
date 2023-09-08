using BingeWatcher.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BingeWatcher.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Anime> Animes { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<AnimeGenres> AnimeGenres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Anime>().HasData(
                new Anime { Id = 1, Title = "Anime 1", Main_Picture = "mainpic1.jpg", Status = "finished", Number_Of_Episodes = 1, Rating = "G", GenreId = 1 },
                new Anime { Id = 2, Title = "Anime 2", Main_Picture = "mainpic2.jpg", Status = "finished", Number_Of_Episodes = 1, Rating = "G", GenreId = 1 },
                new Anime { Id = 3, Title = "Anime 3", Main_Picture = "mainpic3.jpg", Status = "finished", Number_Of_Episodes = 1, Rating = "G", GenreId = 1 }
            );

            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = 1, Name = "Action"},
                new Genre { Id = 2, Name = "Adventure"},
                new Genre { Id = 3, Name = "Terror"}
            );

            modelBuilder.Entity<AnimeGenres>().HasData(
                new AnimeGenres { Id = 1, AnimeId = 1, GenreId = 1 },
                new AnimeGenres { Id = 2, AnimeId = 1, GenreId = 2 },
                new AnimeGenres { Id = 3, AnimeId = 2, GenreId = 3 }
            );

        }
    }
}
