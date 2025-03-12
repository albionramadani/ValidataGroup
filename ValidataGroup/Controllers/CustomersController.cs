using Application.Customers.Handlers;
using Application.Customers.Queries;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ValidataGroup.Controllers
{

	[Route("api/customers")]
	[ApiController]
	public class CustomersController : ControllerBase
	{
		private readonly IMediator _mediator;

		public CustomersController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]
		public async Task<IActionResult> CreateCustomer([FromBody] Application.Customers.Handlers.CreateCustomerCommand command)
		{
			var customerId = await _mediator.Send(command);
			return CreatedAtAction(nameof(GetCustomerById), new { id = customerId }, customerId);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateCustomer(int id, [FromBody] UpdateCustomerCommand command)
		{
			if (id != command.Id) return BadRequest();
			var result = await _mediator.Send(command);
			return result ? NoContent() : NotFound();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteCustomer(int id)
		{
			var result = await _mediator.Send(new DeleteCustomerCommand { Id = id });
			return result ? NoContent() : NotFound();
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetCustomerById(int id)
		{
			var customer = await _mediator.Send(new GetCustomerByIdQuery(id));
			return customer != null ? Ok(customer) : NotFound();
		}

		[HttpGet]
		public async Task<IActionResult> GetCustomers()
		{
			var customers = await _mediator.Send(new GetCustomersQuery());
			return Ok(customers);
		}
	}
}
