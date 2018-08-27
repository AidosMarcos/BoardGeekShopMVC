using BoardGeekShopMVC.Data.Interfaces;
using BoardGeekShopMVC.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoardGeekShopMVC.Data.Repositories
{
	public class CategoryRepository : ICategoryRepository
	{
		private readonly BoardGeekShopDbContext _boardGeekShopDbContext;

		public CategoryRepository(BoardGeekShopDbContext boardGeekShopDbContext)
		{
			_boardGeekShopDbContext = boardGeekShopDbContext;
		}

		public IEnumerable<Category> Categories => _boardGeekShopDbContext.Categories;
	}
}
