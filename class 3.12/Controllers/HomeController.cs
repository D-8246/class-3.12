using class_3._12.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace class_3._12.Controllers
{
    public class HomeController : Controller
    {
        private string _connectionString = @"Data Source=.\sqlexpress;Initial Catalog=Northwnd;Integrated Security=true;TrustServerCertificate=yes;";

        public IActionResult Index()
        {
            var nm = new NorthwindModel(_connectionString);
            var ovm = new OrdersViewModel
            {
                Orders = nm.GetOrders()
            };
            return View(ovm);
        }

    }
}
