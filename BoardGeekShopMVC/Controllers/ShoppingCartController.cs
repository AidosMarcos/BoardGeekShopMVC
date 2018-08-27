using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoardGeekShopMVC.Data.Interfaces;
using BoardGeekShopMVC.Data.Models;
using BoardGeekShopMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BoardGeekShopMVC.Controllers
{
    public class ShoppingCartController : Controller
    {
		private readonly IProductRepository _productRepository;
		private readonly ShoppingCart _shoppingCart;

		public ShoppingCartController(IProductRepository productRepository, ShoppingCart shoppingCart)
		{
			_productRepository = productRepository;
			_shoppingCart = shoppingCart;
		}

        public ViewResult Index()
		{
			var items = _shoppingCart.GetShoppingCartItems();
			_shoppingCart.ShoppingCartItems = items;

			var shopCartVM = new ShoppingCartViewModel
			{
				ShoppingCart = _shoppingCart,
				ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
			};

			return View(shopCartVM);
		}

		public RedirectToActionResult AddToShoppingCart(int productId)
		{
			var currentProduct = _productRepository.Products.FirstOrDefault(p => p.ProductID == productId);

			if (currentProduct != null)
			{
				_shoppingCart.AddToCart(currentProduct, 1);
			}
			return RedirectToAction("Index");
		}

		public RedirectToActionResult RemoveFromShoppingCart(int productId)
		{
			var currentProduct = _productRepository.Products.FirstOrDefault(p => p.ProductID == productId);

			if (currentProduct != null)
			{
				_shoppingCart.RemoveFromCart(currentProduct);
			}

			return RedirectToAction("Index");
		}
    }
}