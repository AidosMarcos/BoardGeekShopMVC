using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoardGeekShopMVC.Data.Models
{
    public class ShoppingCart
    {
		private readonly BoardGeekShopDbContext _boardGeekShopDbContext;

		public ShoppingCart(BoardGeekShopDbContext boardGeekShopDbContext)
		{
			_boardGeekShopDbContext = boardGeekShopDbContext;
		}

		public string ShoppingCartID { get; set; }

		public List<ShoppingCartItem> ShoppingCartItems { get; set; }

		public static ShoppingCart GetCart(IServiceProvider services)
		{
			ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

			var context = services.GetService<BoardGeekShopDbContext>();
			string cartID = session.GetString("CartID") ?? Guid.NewGuid().ToString();

			session.SetString("CartID", cartID);

			return new ShoppingCart(context) { ShoppingCartID = cartID };
		}

		public void AddToCart(Product product, int amount)
		{
			var shoppingCartItem = _boardGeekShopDbContext.ShoppingCartItems.SingleOrDefault(sci => sci.Product.ProductID == product.ProductID && sci.ShoppingCartID == ShoppingCartID);

			if (shoppingCartItem == null)
			{
				shoppingCartItem = new ShoppingCartItem
				{
					ShoppingCartID = ShoppingCartID,
					Product = product,
					Quantity = amount
				};

				_boardGeekShopDbContext.ShoppingCartItems.Add(shoppingCartItem);
			}
			else
			{
				shoppingCartItem.Quantity += amount;
			}

			_boardGeekShopDbContext.SaveChanges();
		}

		public int RemoveFromCart(Product product)
		{
			var shoppingCartItem = _boardGeekShopDbContext.ShoppingCartItems.SingleOrDefault(sci => sci.Product.ProductID == product.ProductID && sci.ShoppingCartID == ShoppingCartID);

			var currentAmout = 0;

			if (shoppingCartItem != null)
			{
				if (shoppingCartItem.Quantity > 1)
				{
					shoppingCartItem.Quantity--;
					currentAmout = shoppingCartItem.Quantity;
				}
				else
				{
					_boardGeekShopDbContext.ShoppingCartItems.Remove(shoppingCartItem);
				}
			}

			_boardGeekShopDbContext.SaveChanges();

			return currentAmout;
		}

		public List<ShoppingCartItem> GetShoppingCartItems()
		{
			return ShoppingCartItems ?? (ShoppingCartItems = _boardGeekShopDbContext.ShoppingCartItems
				.Where(c => c.ShoppingCartID == ShoppingCartID)
					.Include(s => s.Product).ToList());
		}

		public void ClearCart()
		{
			var cartItems = _boardGeekShopDbContext.ShoppingCartItems
				.Where(c => c.ShoppingCartID == ShoppingCartID);

			_boardGeekShopDbContext.ShoppingCartItems.RemoveRange(cartItems);

			_boardGeekShopDbContext.SaveChanges();
		}

		public double GetShoppingCartTotal()
		{
			return _boardGeekShopDbContext.ShoppingCartItems
				.Where(c => c.ShoppingCartID == ShoppingCartID)
					.Select(c => c.Product.Price * c.Quantity).Sum();
		}
	}
}
