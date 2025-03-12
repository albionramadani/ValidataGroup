using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidataGroup.Entities;

namespace Domain.Models
{
	public class OrderDto
	{
		public int OrderId { get; set; }
		public DateTime OrderDate { get; set; }
		public decimal TotalPrice { get; set; }
		public List<OrderItemDto> Items { get; set; } = new();

		public OrderDto(Order order)
		{
			OrderId = order.OrderId;
			OrderDate = order.OrderDate;
			TotalPrice = order.TotalPrice;
			Items = order.Items.Select(i => new OrderItemDto { ProductId = i.ProductId, Quantity = i.Quantity }).ToList();
		}
	}
}
