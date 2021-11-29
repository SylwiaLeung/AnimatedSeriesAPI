using AnimatedSeriesAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace AnimatedSeriesAPI.Data
{
    public class SeriesDbContext : DbContext
    {
        public SeriesDbContext(DbContextOptions<SeriesDbContext> options)
            : base(options)
        {
        }

        public DbSet<Season> Seasons { get; set; }
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<Serie> Series { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Cast> Casts { get; set; }
        public DbSet<Lector> Lectors { get; set; }
        public DbSet<CastLector> CastLectors { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CastLector>()
                .HasKey(cl => cl.Id);
            modelBuilder.Entity<CastLector>()
                .HasOne(cl => cl.Cast)
                .WithMany(c => c.CastLectors)
                .HasForeignKey(bc => bc.CastId);    
            modelBuilder.Entity<CastLector>()
                .HasOne(cl => cl.Lector)
                .WithMany(l => l.CastLectors)
                .HasForeignKey(cl => cl.LectorId);
        }
    }
}