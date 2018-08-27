using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoardGeekShopMVC.Data.Interfaces;
using BoardGeekShopMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BoardGeekShopMVC.Controllers
{
    public class HomeController : Controller
    {

		private readonly IProductRepository _productRepository;

		public HomeController(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}
        public ViewResult Index()
        {
			var homeViewModel = new HomeViewModel
			{
				OnDisplayProducts = _productRepository.OnDisplayProduct
			};

            return View(homeViewModel);
        }
    }
}