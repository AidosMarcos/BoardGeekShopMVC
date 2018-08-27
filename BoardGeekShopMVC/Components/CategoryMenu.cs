using BoardGeekShopMVC.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoardGeekShopMVC.Components
{
    public class CategoryMenu : ViewComponent
    {
		private readonly ICategoryRepository _categoryRepository;

		public CategoryMenu(ICategoryRepository categoryRepository)
		{
			_categoryRepository = categoryRepository;
		}

		public IViewComponentResult Invoke()
		{
			var categories = _categoryRepository.Categories.OrderBy(c => c.Name); // order categories by name

			return View(categories);
		}
    }
}
