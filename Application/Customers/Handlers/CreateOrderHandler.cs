using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidataGroup.Entities;

namespace Application.Customers.Handlers
{
	public class CreateOrderCommand : IRequest<int>
	{
		public int CustomerId { get; set; }
		public List<OrderItemDto> Items { get; set; }
	}

	public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, int>
	{
		private readonly AppDbContext _context;

		public CreateOrderHandler(AppDbContext context)
		{
			_context = context;
		}

		public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
		{
			var order = new Order { CustomerId = request.CustomerId, Items = new List<Item>(), OrderDate = DateTime.UtcNow };
			foreach (var item in request.Items)
			{
				var product = await _context.Products.FindAsync(item.ProductId);
				if (product != null)
				{
					order.Items.Add(new Item { ProductId = product.Id, Quantity = item.Quantity });
				}
			}
			_context.Orders.Add(order);
			await _context.SaveChangesAsync(cancellationToken);
			return order.OrderId;
		}
	}
}
