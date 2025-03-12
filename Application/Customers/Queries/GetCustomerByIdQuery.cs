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
	public class GetOrdersByCustomerIdQuery : IRequest<List<Order>>
	{
		public int CustomerId { get; set; }
		public GetOrdersByCustomerIdQuery(int customerId) => CustomerId = customerId;
	}

	public class GetOrdersByCustomerIdHandler : IRequestHandler<GetOrdersByCustomerIdQuery, List<Order>>
	{
		private readonly AppDbContext _context;

		public GetOrdersByCustomerIdHandler(AppDbContext context)
		{
			_context = context;
		}

		public async Task<List<Order>> Handle(GetOrdersByCustomerIdQuery request, CancellationToken cancellationToken)
		{
			return await _context.Orders
				.Where(o => o.CustomerId == request.CustomerId)
				.Include(o => o.Items)
				.ThenInclude(i => i.Product)
				.ToListAsync();
		}
	}
}
