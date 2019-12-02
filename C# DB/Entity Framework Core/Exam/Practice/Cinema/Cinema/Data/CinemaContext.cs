namespace Cinema.Data
{
    using Cinema.Data.Models;
    using Cinema.Data.Models.Enums;
    using Microsoft.EntityFrameworkCore;

    public class CinemaContext : DbContext
    {
        public CinemaContext()
        {
        }

        public CinemaContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Hall> Halls { get; set; }
        public DbSet<Projection> Projections { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Seat> Seats { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasKey(m => m.Id);
            });

            modelBuilder.Entity<Hall>().HasKey(x => x.Id);

            modelBuilder
                .Entity<Projection>(entity =>
                {
                    entity.HasKey(x => x.Id);

                    entity
                    .HasOne(p => p.Movie)
                    .WithMany(m => m.Projections)
                    .HasForeignKey(p => p.MovieId);

                    entity
                    .HasOne(p => p.Hall)
                    .WithMany(h => h.Projections)
                    .HasForeignKey(p => p.HallId);
                });

            modelBuilder.Entity<Customer>().HasKey(x => x.Id);

            modelBuilder
                .Entity<Ticket>(entity =>
                {
                    entity.HasKey(x => x.Id);

                    entity
                    .HasOne(t => t.Customer)
                    .WithMany(c => c.Tickets)
                    .HasForeignKey(t => t.CustomerId);

                    entity
                    .HasOne(t => t.Projection)
                    .WithMany(c => c.Tickets)
                    .HasForeignKey(t => t.ProjectionId);
                });

            modelBuilder.Entity<Seat>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity
                .HasOne(s => s.Hall)
                .WithMany(h => h.Seats)
                .HasForeignKey(s => s.HallId);
            });
        }
    }
}