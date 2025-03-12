using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ValidataGroup.Entities
{
	 
	public class AppDbContext : DbContext
	{
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<Item> Items { get; set; }
		public DbSet<Product> Products { get; set; }

		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}
	}
}
