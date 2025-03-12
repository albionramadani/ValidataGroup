﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ValidataGroup.Entities
{
		public class Product
		{
			[Key] // Primary Key
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

			[Required]
			public string Name { get; set; } = string.Empty;

			[Required]
			[Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero")]
			public decimal Price { get; set; }
	}
}
