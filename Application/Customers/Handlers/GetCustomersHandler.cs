using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidataGroup.Entities;

namespace Application.Customers.Handlers
{
	public class GetCustomersQuery : IRequest<List<Customer>> { }

	public class GetCustomersHandler : IRequestHandler<GetCustomersQuery, List<Customer>>
	{
		private readonly AppDbContext _context;

		public GetCustomersHandler(AppDbContext context)
		{
			_context = context;
		}

		public async Task<List<Customer>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
		{
			return await _context.Customers.ToListAsync();
		}
	}
}
