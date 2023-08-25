using Microsoft.AspNetCore.Mvc;

namespace Assistant2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet("GetOrdersOfDay")]
        public async Task<IActionResult> GetOrdersOfDay()
        {
            try
            {
                return Ok();
            }
            catch (Exception ex) 
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("GetDailyAnalysis")]
        public async Task<IActionResult> GetDailyAnalysis()
        {
            try
            {
                return Ok();
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}