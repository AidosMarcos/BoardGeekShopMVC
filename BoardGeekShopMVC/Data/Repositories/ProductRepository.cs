using BoardGeekShopMVC.Data.Interfaces;
using BoardGeekShopMVC.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoardGeekShopMVC.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
		private readonly BoardGeekShopDbContext _boardGeekShopDbContext;

		public ProductRepository(BoardGeekShopDbContext boardGeekShopDbContext)
		{
			_boardGeekShopDbContext = boardGeekShopDbContext;
		}

		public IEnumerable<Product> Products => _boardGeekShopDbContext.Products.Include(c => c.Category);

		public IEnumerable<Product> OnDisplayProduct => _boardGeekShopDbContext.Products.Where(p => p.OnDisplay).Include(c => c.Category);

		public Product GetProductById(int productId) => _boardGeekShopDbContext.Products.FirstOrDefault(p => p.ProductID == productId);
	}
}
