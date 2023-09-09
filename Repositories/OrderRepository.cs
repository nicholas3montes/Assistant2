using Assistant2.Data;
using Assistant2.Models;
using Microsoft.EntityFrameworkCore;

namespace Assistant2.Repositories
{
    public class OrderRepository : IRepository<Order>
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IQueryable<Order> GetAll()
        {
            return _context.Orders.Include(o => o.Items);
        }
    }
}
