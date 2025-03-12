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
	public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerCommand, bool>
	{
		private readonly AppDbContext _context;

		public DeleteCustomerHandler(AppDbContext context)
		{
			_context = context;
		}

		public async Task<bool> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
		{
			var customer = await _context.Customers.FindAsync(request.Id);
			if (customer == null) return false;

			_context.Customers.Remove(customer);
			await _context.SaveChangesAsync(cancellationToken);
			return true;
		}
	}
}
