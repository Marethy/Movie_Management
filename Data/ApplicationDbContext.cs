using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models.Entities;

namespace WebApplication1.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole,string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ConfigureDataTypes(modelBuilder);
            ConfigureRelationships(modelBuilder);
            ConfigureIndexes(modelBuilder);
        }

        private void ConfigureDataTypes(ModelBuilder modelBuilder)
        {
            // Configure numeric properties
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Ticket>()
                .Property(t => t.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Order>()
                .Property(o => o.TotalAmount)
                .HasPrecision(18, 2);
        }

        private void ConfigureRelationships(ModelBuilder modelBuilder)
        {
            // Movie - MovieGenre (Many-to-Many)
            modelBuilder.Entity<MovieGenre>()
                .HasKey(mg => new { mg.MovieID, mg.GenreID });

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

            // ShowTime - Ticket (One-to-Many) with Restrict Delete to avoid cascading conflict
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.ShowTime)
                .WithMany(st => st.Tickets)
                .HasForeignKey(t => t.ShowTimeID)
                .OnDelete(DeleteBehavior.NoAction);  // Tránh cascade

            // Seat - Ticket (One-to-Many) with Restrict Delete
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Seat)
                .WithMany(s => s.Tickets)
                .HasForeignKey(t => t.SeatID)
                .OnDelete(DeleteBehavior.NoAction);  // Tránh cascade

            // Order - Ticket (One-to-Many) with Cascade Delete (giữ cascade delete tại đây nếu cần thiết)
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Order)
                .WithMany(o => o.Tickets)
                .HasForeignKey(t => t.OrderID)
                .OnDelete(DeleteBehavior.Cascade);  // Giữ Cascade ở đây nếu muốn xóa các ticket khi Order bị xóa

            // Order - OrderProduct (One-to-Many)
            modelBuilder.Entity<OrderProduct>()
                .HasKey(op => new { op.OrderID, op.ProductID });

            modelBuilder.Entity<OrderProduct>()
                .HasOne(op => op.Order)
                .WithMany(o => o.OrderProducts);

            modelBuilder.Entity<OrderProduct>()
                .HasOne(op => op.Product)
                .WithMany(p => p.OrderProducts)
                .HasForeignKey(op => op.ProductID);

            // Theater - Room (One-to-Many)
            modelBuilder.Entity<Room>()
                .HasOne(r => r.Theater)
                .WithMany(t => t.Rooms)
                .HasForeignKey(r => r.TheaterID);

            // Order - User (One-to-Many) with Cascade Delete
            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany()
                .HasForeignKey(o => o.UserId);

            // Order - Ticket (One-to-Many) with Cascade Delete
            modelBuilder.Entity<Order>()
                .HasMany(o => o.Tickets)
                .WithOne(t => t.Order)
                .HasForeignKey(t => t.OrderID);
        }


        private void ConfigureIndexes(ModelBuilder modelBuilder)
        {
            // Index for Room with TheaterID and RoomName
            modelBuilder.Entity<Room>()
                .HasIndex(r => new { r.TheaterID, r.RoomName })
                .IsUnique();
        }

        // DbSets
        public DbSet<Movie> Movies { get; set; } = default!;
        public DbSet<Genre> Genres { get; set; } = default!;
        public DbSet<MovieGenre> MovieGenres { get; set; } = default!;
        public DbSet<Order> Orders { get; set; } = default!;
        public DbSet<OrderProduct> OrderProducts { get; set; } = default!;
        public DbSet<Product> Products { get; set; } = default!;
        public DbSet<Room> Rooms { get; set; } = default!;
        public DbSet<Seat> Seats { get; set; } = default!;
        public DbSet<ShowTime> ShowTimes { get; set; } = default!;
        public DbSet<Ticket> Tickets { get; set; } = default!;
        public DbSet<Theater> Theaters { get; set; } = default!;
    }
}
