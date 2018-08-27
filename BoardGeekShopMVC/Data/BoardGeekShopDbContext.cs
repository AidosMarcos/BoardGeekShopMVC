using BoardGeekShopMVC.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoardGeekShopMVC.Data
{
    public class BoardGeekShopDbContext : DbContext
    {
		public BoardGeekShopDbContext(DbContextOptions<BoardGeekShopDbContext> options) : base(options)
		{
		}

		public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
