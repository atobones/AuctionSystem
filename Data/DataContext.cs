using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AuctionSystem.Models;

namespace AuctionSystem.Data
{
    public class DataContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        // DbSet для пользователей
        public new DbSet<ApplicationUser> Users { get; set; }
        
        // DbSet для аукционных предметов
        public DbSet<AuctionItem> AuctionItems { get; set; }
        
        // DbSet для платежей
        public DbSet<Payment> Payments { get; set; }
        
        // DbSet для ставок
        public DbSet<Bid> Bids { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Настройка типа данных для StartingBid
            modelBuilder.Entity<AuctionItem>()
                .Property(a => a.StartingBid)
                .HasColumnType("decimal(18,2)");

            // Настройка типа данных для Amount в Payment
            modelBuilder.Entity<Payment>()
                .Property(p => p.Amount)
                .HasColumnType("decimal(18,2)");

            // Настройка типа данных для Amount в Bid
            modelBuilder.Entity<Bid>()
                .Property(b => b.Amount)
                .HasColumnType("decimal(18,2)");
        }
    }
}
