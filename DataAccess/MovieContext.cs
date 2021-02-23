using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class MovieContext : DbContext
    {
        public virtual DbSet<Movie> Movies { get; set; }

        public virtual DbSet<Rate> Rates { get; set; }

        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>(entity => entity.HasKey(p => p.Id));
            modelBuilder.Entity<Movie>().HasData(Seed.Get());

            modelBuilder.Entity<Rate>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.HasOne(p => p.Movie).WithMany(p => p.Rates);
            });
        }
    }
}
