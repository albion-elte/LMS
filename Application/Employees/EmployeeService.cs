using LMS.Application.Interfaces;
using LMS.Domain.Employees;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApplication.Employees
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Employee>> GetAllCustomers()
        {
            var customersList = await _unitOfWork.Repository<Employee>().GetAll().ToListAsync();

            return customersList;
        }
    }
}
