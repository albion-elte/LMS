using EcommerceApplication.Customers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Service.Customers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICostumerService _costumerService;

        public CustomersController(ICostumerService costumerService)
        {
            _costumerService = costumerService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var customers = await _costumerService.GetAllCustomers();

            return Ok();
        }
    }
}