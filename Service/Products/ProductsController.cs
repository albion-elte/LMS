using Microsoft.AspNetCore.Mvc;

namespace LMS.Service.Products
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        public ProductsController()
        {
                
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}