using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoardGeekShopMVC.Data.Models
{
    public class ShoppingCartItem
    {
		public int ShoppingCartItemID { get; set; }

		public Product Product { get; set; }

		public int Quantity { get; set; }

		public string ShoppingCartID { get; set; }
    }
}
