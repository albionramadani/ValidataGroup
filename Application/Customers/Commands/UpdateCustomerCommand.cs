using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidataGroup.Entities;

namespace Application.Customers.Commands
{
	public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand, bool>
	{
		private readonly AppDbContext _context;

		public UpdateCustomerHandler(AppDbContext context)
		{
			_context = context;
		}

		public async Task<bool> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
		{
			var customer = await _context.Customers.FindAsync(request.Id);
			if (customer == null) return false;

			customer.FirstName = request.FirstName;
			customer.LastName = request.LastName;
			customer.Address = request.Address;
			customer.PostalCode = request.PostalCode;

			await _context.SaveChangesAsync(cancellationToken);
			return true;
		}
	}
}
