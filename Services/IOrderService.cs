using Assistant2.Models;

namespace Assistant2.Services
{
    public interface IOrderService
    {
        Task<List<Order>> GetOrders();
    }
}
