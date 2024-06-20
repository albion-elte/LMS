using LMS.Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Persistence.Products
{
    public class ProductConfiguration
           : IEntityTypeConfiguration<Product>
    {

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Price)
                .IsRequired()
                .HasPrecision(5, 2);

            builder.HasData(
                new Product() { Id = 1, Name = "Laptop", Price = 5m },
                new Product() { Id = 2, Name = "Mouse", Price = 10m },
                new Product() { Id = 3, Name = "Keyboard", Price = 15m });
        }
    }
}
