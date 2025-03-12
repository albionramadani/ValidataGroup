using Application.Customers.Queries;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidataGroup.Repository.IRepository;

namespace Application.Customers.Handlers
{
	public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdQuery, OrderDto?>
	{
		private readonly IUnitOfWork _unitOfWork;

		public GetOrderByIdHandler(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<OrderDto?> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
		{
			var order = await _unitOfWork.Orders.GetByIdAsync(request.OrderId);
			return order != null ? new OrderDto(order) : null;
		}
	}

}
