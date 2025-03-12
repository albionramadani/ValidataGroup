using ValidataGroup.Entities;
using ValidataGroup.Repository.IRepository;

namespace ValidataGroup.Repository
{
	public class UnitOfWork : IUnitOfWork, IDisposable
	{
		private readonly AppDbContext _context;
		private readonly ICustomerRepository _customerRepository;
		private readonly IOrderRepository _orderRepository;
		private bool _disposed = false;

		public UnitOfWork(AppDbContext context, ICustomerRepository customerRepository, IOrderRepository orderRepository)
		{
			_context = context;
			_customerRepository = customerRepository;
			_orderRepository = orderRepository;
		}

		public ICustomerRepository Customers => _customerRepository;
		public IOrderRepository Orders => _orderRepository;  // ✅ Fix: Implement missing Orders property

		public async Task<int> CommitAsync()
		{
			return await _context.SaveChangesAsync();
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!_disposed)
			{
				if (disposing)
				{
					_context.Dispose();
				}
				_disposed = true;
			}
		}
	}


}
