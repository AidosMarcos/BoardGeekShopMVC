using BoardGeekShopMVC.Data.Models;
using BoardGeekShopMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoardGeekShopMVC.Components
{
    public class ShoppingCartSummary : ViewComponent
    {
		private readonly ShoppingCart _shoppingCart;

		public ShoppingCartSummary(ShoppingCart shoppingCart)
		{
			_shoppingCart = shoppingCart;
		}

		public IViewComponentResult Invoke()
		{
			_shoppingCart.ShoppingCartItems = _shoppingCart.GetShoppingCartItems();

			var shoppingCartViewModel = new ShoppingCartViewModel
			{
				ShoppingCart = _shoppingCart,
				ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
			};

			return View(shoppingCartViewModel);
		}
    }
}
