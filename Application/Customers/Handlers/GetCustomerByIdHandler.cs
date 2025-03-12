using Application.Customers.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidataGroup.Entities;

namespace Application.Customers.Handlers
{
	public class GetCustomerByIdQuery : IRequest<Customer>
	{
		public int Id { get; set; }
		public GetCustomerByIdQuery(int id)  
		{
			Id = id;
		}
	}
	public class GetCustomerByIdHandler : IRequestHandler<GetCustomerByIdQuery, Customer>
	{
		private readonly AppDbContext _context;

		public GetCustomerByIdHandler(AppDbContext context)
		{
			_context = context;
		}

		public async Task<Customer> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
		{
			return await _context.Customers.FindAsync(request.Id);
		}
	}
}
