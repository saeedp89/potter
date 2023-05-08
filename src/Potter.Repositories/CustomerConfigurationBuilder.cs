using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Potter.Domain.Entities;

namespace Potter.Repositories;

public class CustomerConfigurationBuilder : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.Property(e => e.Id)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("NEWID()");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.CreatedAt)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("GETUTCDATE()");
        builder.Property(e => e.UpdatedAt)
            .IsRequired(false);
        builder.Property(e => e.DeletedAt)
            .IsRequired(false);
    }
}