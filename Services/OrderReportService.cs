using Assistant2.Models;
using Newtonsoft.Json;

namespace Assistant2.Services
{
    public class OrderReportService : IOrderReportService
    {
        public async Task<string> GetReport(string route)
        {
            try
            {
                string content = await File.ReadAllTextAsync(route);
                var orders = JsonConvert.DeserializeObject<List<Order>>(content);

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
