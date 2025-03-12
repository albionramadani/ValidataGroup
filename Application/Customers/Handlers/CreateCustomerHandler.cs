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
	public class CreateCustomerCommand : IRequest<int> // ✅ Add this interface
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Address { get; set; }
		public string PostalCode { get; set; }
	}
	public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, int>
	{
		private readonly AppDbContext _context;

		public CreateCustomerHandler(AppDbContext context)
		{
			_context = context;
		}

		public async Task<int> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
		{
			var customer = new Customer
			{
				FirstName = request.FirstName,
				LastName = request.LastName,
				Address = request.Address,
				PostalCode = request.PostalCode
			};

			_context.Customers.Add(customer);
			await _context.SaveChangesAsync(cancellationToken);
			return customer.CustomerId;
		}
	}
}
