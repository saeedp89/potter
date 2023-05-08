using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Potter.Domain.Entities;

namespace Potter.Repositories;

public class PotterDbContext : DbContext
{
    public PotterDbContext(DbContextOptions<PotterDbContext> options) : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new CustomerConfigurationBuilder());
    }

}

public class PotterDbContextFactory : IDesignTimeDbContextFactory<PotterDbContext>
{
    public PotterDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<PotterDbContext>();
        builder.UseSqlServer("Server=.;Database=VortexVPN;User Id=sa;Password=basterdios;MultipleActiveResultSets=True;TrustServerCertificate=True;");
        return new PotterDbContext(builder.Options);
    }
}