using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using LMS.Application.Interfaces;
using LMS.Domain.Employees;
using LMS.Persistence.Employees;


namespace EcommercePersistence
{
    public class DatabaseService : DbContext, IDatabaseService
    {
        private readonly IConfiguration _configuration;

        public DatabaseService(IConfiguration configuration)
        {
            _configuration = configuration;

            Database.EnsureCreated();
        }

        public DbSet<Employee> Employees { get; set; }

        public void Save()
        {
            this.SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            new EmployeeConfiguration().Configure(builder.Entity<Employee>());
        }
    }
}
