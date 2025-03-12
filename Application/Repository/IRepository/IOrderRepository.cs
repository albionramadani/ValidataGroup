using ValidataGroup.Entities;

namespace ValidataGroup.Repository.IRepository
{
	public interface IOrderRepository
	{
		Task<Order?> GetByIdAsync(int id);
		Task<IEnumerable<Order>> GetByCustomerIdAsync(int customerId);
		Task<IEnumerable<Order>> GetAllByDateAsync(DateTime date);
		Task AddAsync(Order order);
		void Update(Order order);
		void Delete(Order order);
	}
}
