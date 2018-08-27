using BoardGeekShopMVC.Data.Interfaces;
using BoardGeekShopMVC.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoardGeekShopMVC.Data.Mocks
{
	public class MockCategoryRepository : ICategoryRepository
	{
		public IEnumerable<Category> Categories
		{
			get
			{
				return new List<Category>
				{
					new Category { Name = "Boardgame" },

					new Category { Name = "Dice" }
				};
			}
		}
	};
}
