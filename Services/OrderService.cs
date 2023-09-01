using Assistant2.Models;
using Newtonsoft.Json;

namespace Assistant2.Services
{
    public class OrderService : IOrderService
    {
        public async Task<List<Order>> GetOrders(string route)
        {
            try
            {
                string content = await File.ReadAllTextAsync(route);
                var orderList = JsonConvert.DeserializeObject<List<Order>>(content);

                return orderList;
            }
            catch
            {
                return null;
            }
        }
    }
}
