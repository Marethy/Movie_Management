using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities;

namespace WebApplication1.Entities
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Movie - MovieGenre (Many-to-Many)
            modelBuilder.Entity<MovieGenre>()
                .HasKey(mg => new { mg.MovieID, mg.GenreID }); // Composite key
            modelBuilder.Entity<MovieGenre>()
                .HasOne(mg => mg.Movie)
                .WithMany(m => m.MovieGenres)
                .HasForeignKey(mg => mg.MovieID);
            modelBuilder.Entity<MovieGenre>()
                .HasOne(mg => mg.Genre)
                .WithMany(g => g.MovieGenres)
                .HasForeignKey(mg => mg.GenreID);

            // Movie - ShowTime (One-to-Many)
            modelBuilder.Entity<ShowTime>()
                .HasOne(st => st.Movie)
                .WithMany(m => m.ShowTimes)
                .HasForeignKey(st => st.MovieID);

            // Room - ShowTime (One-to-Many)
            modelBuilder.Entity<ShowTime>()
                .HasOne(st => st.Room)
                .WithMany(r => r.ShowTimes)
                .HasForeignKey(st => st.RoomID);

            // Room - Seat (One-to-Many)
            modelBuilder.Entity<Seat>()
                .HasOne(s => s.Room)
                .WithMany(r => r.Seats)
                .HasForeignKey(s => s.RoomID);

            // ShowTime - Ticket (One-to-Many)
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.ShowTime)
                .WithMany(st => st.Tickets)
                .HasForeignKey(t => t.ShowTimeID);

            // Seat - Ticket (One-to-Many)
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Seat)
                .WithMany(s => s.Tickets)
                .HasForeignKey(t => t.SeatID);

            // Order - Ticket (One-to-Many)
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Order)
                .WithMany(o => o.Tickets)
                .HasForeignKey(t => t.OrderID);

            // Order - OrderProduct (One-to-Many)
            modelBuilder.Entity<OrderProduct>()
                .HasKey(op => new { op.OrderID, op.ProductID }); // Composite key
            modelBuilder.Entity<OrderProduct>()
                .HasOne(op => op.Order)
                .WithMany(o => o.OrderProducts)
                .HasForeignKey(op => op.OrderID);
            modelBuilder.Entity<OrderProduct>()
                .HasOne(op => op.Product)
                .WithMany(p => p.OrderProducts)
                .HasForeignKey(op => op.ProductID);
        }
        public DbSet<WebApplication1.Entities.Movie> Movie { get; set; } = default!;
      
    }
}
