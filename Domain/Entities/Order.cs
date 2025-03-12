namespace ValidataGroup.Entities
{
	public class Order
	{
		public int OrderId { get; set; }
		public int CustomerId { get; set; }
		public Customer Customer { get; set; } = null!;
		public DateTime OrderDate { get; set; } = DateTime.UtcNow;
		public List<Item> Items { get; set; } = new();
		public decimal TotalPrice => Items.Sum(item => item.TotalPrice);
	}
}
