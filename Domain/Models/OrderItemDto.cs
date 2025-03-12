using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidataGroup.Entities;

namespace Domain.Models
{
	public class OrderItemDto
	{
		public int ItemId { get; set; }
		public int ProductId { get; set; }
		public int Quantity { get; set; }
		public Product Product { get; set; }
	}
}
