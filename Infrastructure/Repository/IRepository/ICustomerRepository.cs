using ValidataGroup.Entities;

namespace ValidataGroup.Repository.IRepository
{
	public interface ICustomerRepository
	{
		 
		Task<Customer> GetCustomerAsync(int customerId);
		Task<IEnumerable<Customer>> GetAllCustomersAsync();
		Task<Customer> AddCustomerAsync(Customer customer);
		Task UpdateCustomerAsync(Customer customer);
		Task DeleteCustomerAsync(int customerId);
	}

}
