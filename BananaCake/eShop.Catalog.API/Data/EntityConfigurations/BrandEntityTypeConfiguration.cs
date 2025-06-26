using eShop.Catalog.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShop.Catalog.API.Data.EntityConfigurations;

internal sealed  class BrandEntityTypeConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder
            .ToTable("Brands");

        builder
            .Property(cb => cb.Name)
            .HasMaxLength(100);
    }
}
