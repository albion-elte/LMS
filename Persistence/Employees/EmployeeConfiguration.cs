using LMS.Domain.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Persistence.Employees
{
    public class EmployeeConfiguration
           : IEntityTypeConfiguration<Employee>
    {

        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasData(
                new Employee() { Id = 1, Name = "Albanit Berisha" },
                new Employee() { Id = 2, Name = "Altin Berisha" },
                new Employee() { Id = 3, Name = "Elion Berisha" });
        }
    }
}
