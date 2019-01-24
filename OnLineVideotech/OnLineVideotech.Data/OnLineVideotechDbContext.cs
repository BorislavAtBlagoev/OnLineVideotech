using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnLineVideotech.Data.Models;

namespace OnLineVideotech.Data
{
    public class OnLineVideotechDbContext : IdentityDbContext<User>
    {
        public OnLineVideotechDbContext(DbContextOptions<OnLineVideotechDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<GenreMovie>()
                .HasKey(x => new { x.GenreId, x.MovieId});

            builder
                .Entity<GenreMovie>()
                .HasOne(gm => gm.Genre)
                .WithMany(m => m.Movies)
                .HasForeignKey(gm => gm.GenreId);

            builder
                .Entity<GenreMovie>()
                .HasOne(gm => gm.Movie)
                .WithMany(g => g.Genres)
                .HasForeignKey(gm => gm.MovieId);


            base.OnModelCreating(builder);       
        }
    }
}