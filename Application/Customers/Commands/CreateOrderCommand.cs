using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Customers.Commands
{
	public class CreateOrderCommand : IRequest<int>
	{
		public int CustomerId { get; set; }
		public List<OrderItemDto> Items { get; set; } = new();
	}

	public class OrderItemDto
	{
		public int ProductId { get; set; }
		public int Quantity { get; set; }
	}

}
