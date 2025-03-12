using NUnit.Framework;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Application.Customers.Commands;
using Domain.Models;
using ValidataGroup.Repository.IRepository;
using ValidataGroup.Entities;
using NUnit.Framework.Legacy;

namespace Tests.Handlers
{
	[TestFixture] // ✅ Required for NUnit
	public class CreateCustomerHandlerTests
	{
		private Mock<IUnitOfWork> _unitOfWorkMock;
		private Mock<ICustomerRepository> _customerRepositoryMock;
		private CreateCustomerHandler _handler;

		[SetUp]
		public void Setup()
		{
			_unitOfWorkMock = new Mock<IUnitOfWork>();
			_customerRepositoryMock = new Mock<ICustomerRepository>();

			_unitOfWorkMock.Setup(u => u.Customers).Returns(_customerRepositoryMock.Object);
			_handler = new CreateCustomerHandler(_unitOfWorkMock.Object);
		}

		[Test] 
		public async Task Handle_WhenValidRequest_ShouldCreateCustomerAndReturnId()
		{
			// Arrange
			var command = new Application.Customers.Commands.CreateCustomerCommand
			{
				FirstName = "Test",
				LastName = "TEst",
				Address = "Prishtine",
				PostalCode = "10000"
			};

			var customer = new Customer
			{
				CustomerId = 1,
				FirstName = command.FirstName,
				LastName = command.LastName,
				Address = command.Address,
				PostalCode = command.PostalCode
			};

			_customerRepositoryMock
		.Setup(repo => repo.AddCustomerAsync(It.IsAny<Customer>()))
		.ReturnsAsync((Customer customer) =>
		{
			customer.CustomerId = 1;  
			return customer;
		});

			var result = await _handler.Handle(command, CancellationToken.None);
			Assert.That(result, Is.EqualTo(1));

			_customerRepositoryMock.Verify(repo => repo.AddCustomerAsync(It.IsAny<Customer>()), Times.Once);
			_unitOfWorkMock.Verify(u => u.CommitAsync(), Times.Once);
		}
	}
}
