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

        public DbSet<History> Histories { get; set; }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Price> Prices { get; set; }

        public DbSet<Genre> Genres { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<GenreMovie>()
                .HasKey(x => new { x.GenreId, x.MovieId });

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

            builder
                .Entity<HistoryMovie>()
                .HasKey(h => new { h.HistoryId, h.MovieId });

            builder
                .Entity<HistoryMovie>()
                .HasOne(hm => hm.Movie)
                .WithMany(m => m.Histories)
                .HasForeignKey(hm => hm.MovieId);

            builder
                .Entity<HistoryMovie>()
                .HasOne(hm => hm.History)
                .WithMany(h => h.Movies)
                .HasForeignKey(hm => hm.HistoryId);

            builder
                .Entity<HistoryCustomer>()
                .HasKey(hc => new { hc.HistoryId, hc.CustomerId });

            builder
                .Entity<HistoryCustomer>()
                .HasOne(hc => hc.Customer)
                .WithMany(h => h.Histories)
                .HasForeignKey(hc => hc.CustomerId);

            builder
                .Entity<HistoryCustomer>()
                .HasOne(hc => hc.History)
                .WithMany(c => c.Customers)
                .HasForeignKey(hc=> hc.HistoryId);

            base.OnModelCreating(builder);
        }
    }
}