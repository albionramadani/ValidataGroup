using Microsoft.EntityFrameworkCore;
using ValidataGroup.Entities;
using ValidataGroup.Repository.IRepository;

namespace ValidataGroup.Repository
{
	public class OrderRepository : IOrderRepository
	{
		private readonly AppDbContext _context;

		public OrderRepository(AppDbContext context)
		{
			_context = context;
		}

		public async Task<Order?> GetByIdAsync(int id) =>
			await _context.Orders.Include(o => o.Items).ThenInclude(i => i.Product).FirstOrDefaultAsync(o => o.OrderId == id);

		public async Task<IEnumerable<Order>> GetByCustomerIdAsync(int customerId) =>
			await _context.Orders.Where(o => o.CustomerId == customerId)
								 .Include(o => o.Items).ThenInclude(i => i.Product)
								 .ToListAsync();

		public async Task<IEnumerable<Order>> GetAllByDateAsync(DateTime date) =>
			await _context.Orders.Where(o => o.OrderDate.Date == date.Date)
								 .Include(o => o.Items).ThenInclude(i => i.Product)
								 .ToListAsync();

		public async Task AddAsync(Order order) => await _context.Orders.AddAsync(order);

		public void Update(Order order) => _context.Orders.Update(order);

		public void Delete(Order order) => _context.Orders.Remove(order);
	}
}
