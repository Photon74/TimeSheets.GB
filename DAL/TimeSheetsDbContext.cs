using Microsoft.EntityFrameworkCore;

using System.Diagnostics;

using TimeSheets.GB.DAL.Entities;

namespace TimeSheets.GB.DAL
{
    public class TimeSheetsDbContext : DbContext
    {
        public TimeSheetsDbContext(DbContextOptions<TimeSheetsDbContext> options) : base(options) { }

        public DbSet<UserEntity> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=TimeSheets;Username=postgres;Password=3299;");
            optionsBuilder.LogTo(message => Debug.WriteLine(message));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>();
        }
    }
}
