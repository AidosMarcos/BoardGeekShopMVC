using BoardGeekShopMVC.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoardGeekShopMVC.Data.Interfaces
{
    public interface ICategoryRepository
    {
		IEnumerable<Category> Categories { get; }
    }
}
