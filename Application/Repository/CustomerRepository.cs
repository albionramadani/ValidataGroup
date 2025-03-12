using Microsoft.EntityFrameworkCore;
using ValidataGroup.Entities;
using ValidataGroup.Repository.IRepository;

namespace ValidataGroup.Repository
{

	public class CustomerRepository : ICustomerRepository
	{
		private readonly AppDbContext _context;

		public CustomerRepository(AppDbContext context)
		{
			_context = context;
		}

		public async Task<Customer> GetCustomerAsync(int customerId) =>
			await _context.Customers.Include(c => c.Orders).ThenInclude(o => o.Items).FirstOrDefaultAsync(c => c.CustomerId == customerId);

		public async Task<IEnumerable<Customer>> GetAllCustomersAsync() =>
			await _context.Customers.ToListAsync();

		public async Task<Customer> AddCustomerAsync(Customer customer)
		{
			var entry = await _context.Customers.AddAsync(customer);
			return entry.Entity; // ✅ This returns the actual Customer object
		}

		public async Task UpdateCustomerAsync(Customer customer) =>
			_context.Customers.Update(customer);

		public async Task DeleteCustomerAsync(int customerId)
		{
			var customer = await _context.Customers.FindAsync(customerId);
			if (customer != null)
				_context.Customers.Remove(customer);
		}
	}
}
