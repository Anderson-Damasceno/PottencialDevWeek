using Microsoft.EntityFrameworkCore;
using src.Models;

namespace src.Persistence;

public class DataBaseContext : DbContext
{
    public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
    {

    }
    public DbSet<Person>? People { get; set; }
    public DbSet<Contract>? Contracts { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Person>(table =>
        {
            table.HasKey(e => e.Id);
            table
            .HasMany(e => e.contracts)
            .WithOne()
            .HasForeignKey(c => c.PersonId);
        });
        builder.Entity<Contract>(table =>
        {
            table.HasKey(e => e.Id);
        });
    }
}