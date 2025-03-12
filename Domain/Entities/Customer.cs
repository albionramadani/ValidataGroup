namespace ValidataGroup.Entities
{
	public class Customer
	{
		public int CustomerId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Address { get; set; }
		public string PostalCode { get; set; }
		public List<Order> Orders { get; set; }
	}
}
