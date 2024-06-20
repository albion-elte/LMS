using LMS.Application.Interfaces;
using LMS.Domain.Customers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceApplication.Customers
{
    public class CostumerService : ICostumerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CostumerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            var customersList = await _unitOfWork.Repository<Customer>().GetAll().ToListAsync();

            return customersList;
        }
    }
}
