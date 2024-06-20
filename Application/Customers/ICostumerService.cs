using LMS.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceApplication.Customers
{
    public interface ICostumerService
    {
        Task<List<Customer>> GetAllCustomers();
    }
}
