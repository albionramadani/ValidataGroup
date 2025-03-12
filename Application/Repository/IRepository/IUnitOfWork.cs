namespace ValidataGroup.Repository.IRepository
{
	public interface IUnitOfWork : IDisposable
	{
		ICustomerRepository Customers { get; }
		IOrderRepository Orders { get; }  // Ensure this exists in the interface
		Task<int> CommitAsync();
	}

}
