using BoardGeekShopMVC.Data.Interfaces;
using BoardGeekShopMVC.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoardGeekShopMVC.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
		private readonly BoardGeekShopDbContext _boardGeekShopDbContext;
		private readonly ShoppingCart _shoppingCart;

		public OrderRepository(BoardGeekShopDbContext boardGeekShopDbContext, ShoppingCart shoppingCart)
		{
			_boardGeekShopDbContext = boardGeekShopDbContext;
			_shoppingCart = shoppingCart;
		}

		public void CreateOrder(Order order)
		{
			order.OrderDate = DateTime.Now;
			_boardGeekShopDbContext.Orders.Add(order);

			var shopppingCartItems = _shoppingCart.ShoppingCartItems;

			foreach (var item in shopppingCartItems)
			{
				var orderDetail = new OrderDetail()
				{
					Quantity = item.Quantity,
					ProductID = item.Product.ProductID,
					OrderID = order.OrderId,
					Price = item.Product.Price
				};

				_boardGeekShopDbContext.OrderDetails.Add(orderDetail);
			}
			_boardGeekShopDbContext.SaveChanges();
		}
	}
}
