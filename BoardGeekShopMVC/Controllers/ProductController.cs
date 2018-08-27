using BoardGeekShopMVC.Data.Interfaces;
using BoardGeekShopMVC.Data.Models;
using BoardGeekShopMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoardGeekShopMVC.Controllers
{
    public class ProductController : Controller
    {
		private readonly ICategoryRepository _categoryRepository;
		private readonly IProductRepository _productRepository;

		public ProductController(ICategoryRepository categoryRepository, IProductRepository productRepository)
		{
			_categoryRepository = categoryRepository;
			_productRepository = productRepository;
		}

		public ViewResult List(string category)
		{
			string _category = category;
			IEnumerable<Product> products;

			string currentCategory = string.Empty;

			if (string.IsNullOrEmpty(category))
			{
				products = _productRepository.Products.OrderBy(p => p.ProductID);
				currentCategory = "All products";
			}
			else
			{
				if (string.Equals("Boardgame", _category, StringComparison.OrdinalIgnoreCase))
				{
					products = _productRepository.Products.Where(p => p.Category.Name.Equals("Boardgame")).OrderBy(p => p.Name);
				}
				else
				{
					products = _productRepository.Products.Where(p => p.Category.Name.Equals("Dice")).OrderBy(p => p.Name);
				}

				currentCategory = _category;
			}

			ViewBag.Name = "Products";

			var productViewModel = new ProductListViewModel()
			{
				Products = products,
				CurrentCategory = currentCategory
			};

			return View(productViewModel);
		}


    }
}
