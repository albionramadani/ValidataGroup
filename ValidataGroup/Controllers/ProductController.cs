using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ValidataGroup.Entities;

namespace ValidataGroup.Controllers
{
	[Route("api/products")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly AppDbContext _context;

		public ProductsController(AppDbContext context)
		{
			_context = context;
		}

		// ✅ Get All Products
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
		{
			return await _context.Products.ToListAsync();
		}

		// ✅ Create a New Product
		[HttpPost]
		public async Task<ActionResult<Product>> CreateProduct([FromBody] Product product)
		{
			if (product == null) return BadRequest("Invalid product data.");

			_context.Products.Add(product);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(GetProducts), new { id = product.Id }, product);
		}
	}
}
