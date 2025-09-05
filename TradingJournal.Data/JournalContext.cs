using Microsoft.EntityFrameworkCore;
using TradingJournal.Data.Models;

namespace TradingJournal.Data
{
    public class JournalContext : DbContext
    {
        public DbSet<Trade> Trades { get; set; }

        public JournalContext(DbContextOptions<JournalContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Trade>().ToTable("Trades");
        }
    }
}
