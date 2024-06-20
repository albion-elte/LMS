using Microsoft.EntityFrameworkCore;
using LMS.Domain.Employees;

namespace LMS.Application.Interfaces
{
    public interface IDatabaseService
    {
        DbSet<Employee> Employees { get; set; }

        void Save();
    }
}