using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Customers.Handlers
{
	public class GetOrderByIdQuery : IRequest<OrderDto>
	{
		public int OrderId { get; }
		public GetOrderByIdQuery(int orderId) => OrderId = orderId;
	}

}
