using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoardGeekShopMVC.Data.Models
{
    public class Order
    {
		public int OrderId { get; set; }

		public List<OrderDetail> OrderDetails { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string Address { get; set; }

		public double OrderTotal { get; set; }

		public DateTime OrderDate { get; set; }
    }
}
