using Assistant2.Models;
using Assistant2.Repositories;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Assistant2.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;

        public OrderService(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<List<Order>> GetOrders()
        {
            try
            {
                var orders = await _orderRepository.GetAll().ToListAsync();

                if (orders != null)
                {
                    return orders;
                }
                else
                {
                    throw new FileNotFoundException("O arquivo de pedidos não foi encontrado.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter pedidos: {ex.Message}");

                throw new InvalidOperationException("Ocorreu um erro ao obter pedidos.");
            }
        }
    }
}
