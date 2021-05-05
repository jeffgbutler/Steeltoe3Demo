using Microsoft.EntityFrameworkCore;
using PaymentCalculator.Models;

namespace PaymentCalculator.Data
{
    public class SteeltoeContext : DbContext
    {
        public SteeltoeContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("Person");
        }
    }
}
