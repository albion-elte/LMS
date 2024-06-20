using LMS.Domain.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Persistence.Customers
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {       

        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasData(
                new Customer() { Id = 1, Name = "Albion Berisha" },
                new Customer() { Id = 2, Name = "Albi Berisha" },
                new Customer() { Id = 3, Name = "Niti Berisha" });
        }
    }
}
