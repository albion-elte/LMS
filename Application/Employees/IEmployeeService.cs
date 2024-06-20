using LMS.Domain.Employees;

namespace EcommerceApplication.Employees
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAllCustomers();
    }
}
