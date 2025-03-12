using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidataGroup.Entities;
using ValidataGroup.Repository.IRepository;

namespace Application.Customers.Commands
{
	/// <summary>
	/// Command to create a new customer.
	/// </summary>
	public class CreateCustomerCommand : IRequest<int>
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Address { get; set; }
		public string PostalCode { get; set; }
	}

	/// <summary>
	/// Handler for creating a new customer.
	/// </summary>
	public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, int>
	{
		private readonly IUnitOfWork _unitOfWork;

		public CreateCustomerHandler(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
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

			await _unitOfWork.Customers.AddCustomerAsync(customer);
			await _unitOfWork.CommitAsync();

			return customer.CustomerId;
		}
	}
}
