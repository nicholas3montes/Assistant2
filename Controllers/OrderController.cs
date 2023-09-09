using Assistant2.Models;
using Assistant2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Assistant2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IOrderReportService _orderReportService;
        
        public OrderController(IOrderService orderService, IOrderReportService orderReportService)
        {
            _orderService = orderService;
            _orderReportService = orderReportService;
        }

        [HttpGet]
        public async Task<List<Order>> Get()
        {
            try
            {

                var orders = _orderService.GetOrders();
                if (orders != null)
                {
                    return await orders;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet("Report")]
        public async Task<string> GetReport()
        {
            try
            {
                var result = _orderReportService.GetReport();

                if (result != null)
                {
                    return await result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}