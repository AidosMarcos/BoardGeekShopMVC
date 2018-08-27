using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoardGeekShopMVC.Data.Models
{
	public class Product
	{
		public int ProductID { get; set; }

		public string Name { get; set; }

		public string FullDescription { get; set; }

		public string ShortDescription { get; set; }

		public double Price { get; set; }

		public string ImagePath { get; set; }

		public bool OnDisplay { get; set; }

		public bool InStock { get; set; }

		public int CategoryID { get; set; }

		public virtual Category Category { get; set; }
    }
}
