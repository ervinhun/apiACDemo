using Microsoft.EntityFrameworkCore;

namespace apiACDemo;

public class MyDbContext : DbContext
{
        public DbSet<AircraftEntity> Aircrafts { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source=aircrafts.db");

}