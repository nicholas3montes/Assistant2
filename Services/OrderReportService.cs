using Assistant2.Models;
using Assistant2.Repositories;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Assistant2.Services
{
    public class OrderReportService : IOrderReportService
    {
        private readonly IRepository<Order> _orderRepository;

        public OrderReportService(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<string> GetReport()
        {
            try
            {
                var orders = await _orderRepository.GetAll().ToListAsync();

                if (orders != null)
                {
                    decimal total = orders.Sum(order => order.Items.Sum(item => item.Value * item.Quantity));
                    int totalQuantity = orders.Sum(order => order.Items.Sum(item => item.Quantity));

                    var categoryQuantities = orders
                        .SelectMany(order => order.Items)
                        .GroupBy(item => item.Category)
                        .Select(group => new
                        {
                            Category = group.Key,
                            Quantity = group.Sum(item => item.Quantity)
                        }).ToList();


                    var analysis = new
                    {
                        TotalDeVendas = total,
                        QuantidadeDeItems = totalQuantity,
                        QuantidadePorCategoria = categoryQuantities
                    };

                    return JsonConvert.SerializeObject(analysis);
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
