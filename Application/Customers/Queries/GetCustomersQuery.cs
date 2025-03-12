using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidataGroup.Entities;

namespace Application.Customers.Queries
{
	public class GetOrderByIdQuery : IRequest<Order>
	{
		public int OrderId { get; set; }
		public GetOrderByIdQuery(int orderId) => OrderId = orderId;
	}

	public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdQuery, Order>
	{
		private readonly AppDbContext _context;

		public GetOrderByIdHandler(AppDbContext context)
		{
			_context = context;
		}

		public async Task<Order> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
		{
			return await _context.Orders
				.Include(o => o.Items)
				.ThenInclude(i => i.Product)
				.FirstOrDefaultAsync(o => o.OrderId == request.OrderId);
		}
	}
}
