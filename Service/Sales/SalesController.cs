using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Service.Sales
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesController : ControllerBase
    {
        public SalesController()
        {
                
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
