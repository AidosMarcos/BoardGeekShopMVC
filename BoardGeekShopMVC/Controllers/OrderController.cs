﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoardGeekShopMVC.Data.Interfaces;
using BoardGeekShopMVC.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace BoardGeekShopMVC.Controllers
{
    public class OrderController : Controller
    {
		private readonly IOrderRepository _orderRepository;
		private readonly ShoppingCart _shoppingCart;

		public OrderController(IOrderRepository orderRepository, ShoppingCart shoppingCart)
		{
			_orderRepository = orderRepository;
			_shoppingCart = shoppingCart;
		}

		public IActionResult Checkout()
        {
            return View();
        }
    }
}