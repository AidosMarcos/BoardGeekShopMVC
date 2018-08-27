using BoardGeekShopMVC.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoardGeekShopMVC.ViewModels
{
    public class HomeViewModel
    {
		public IEnumerable<Product> OnDisplayProducts { get; set; }
    }
}
