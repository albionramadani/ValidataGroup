using Application.Customers.Handlers;
using Application.Customers.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ValidataGroup.Controllers
{
	[Route("api/orders")]
	[ApiController]
	public class OrdersController : ControllerBase
	{
		private readonly IMediator _mediator;

		public OrdersController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet("{orderId}")]
		public async Task<IActionResult> GetOrderById(int orderId)
		{
			var order = await _mediator.Send(new Application.Customers.Handlers.GetOrderByIdQuery(orderId));
			return order != null ? Ok(order) : NotFound();
		}

		[HttpGet("customer/{customerId}")]
		public async Task<IActionResult> GetOrdersByCustomerId(int customerId)
		{
			var orders = await _mediator.Send(new GetOrdersByCustomerIdQuery(customerId));
			return Ok(orders);
		}
		[HttpPost]
		public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
		{
			var orderId = await _mediator.Send(command);
			return CreatedAtAction(nameof(GetOrderById), new { orderId }, orderId);
		}
	}
}
