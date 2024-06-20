using Microsoft.EntityFrameworkCore;
using LMS.Domain.Customers;
using LMS.Domain.Employees;
using LMS.Domain.Products;
using LMS.Domain.Sales;

namespace LMS.Application.Interfaces
{
    public interface IDatabaseService
    {
        DbSet<Customer> Customers { get; set; }

        DbSet<Employee> Employees { get; set; }
        
        DbSet<Product> Products { get; set; }
        
        DbSet<Sale> Sales { get; set; }

        void Save();
    }
}