using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ValidataGroup.Entities
{

	public class Item
	{
		[Key] // Primary Key
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[ForeignKey("Product")]
		public int ProductId { get; set; }
		public Product Product { get; set; }

		public int Quantity { get; set; }

		[ForeignKey("Order")]
		public int OrderId { get; set; }
		public Order Order { get; set; }
		public decimal TotalPrice => Product.Price * Quantity;


	}
}
