using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CustomerApplication.Models;

namespace CustomerApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            CustomerModel customerObj = new CustomerModel();
            ViewBag.CustomersList =  customerObj.GetAllCustomers();
            return View();
        }


        [HttpGet]
        public IActionResult Create(int? id)
        {
            if(id != null)
            {
                CustomerModel customerObj = new CustomerModel();
                ViewBag.Customer = customerObj.GetCustomer(id);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Create(CustomerModel customer)
        {
            customer.CreateCustomer();
            return View();
        }

        public IActionResult Delete(int id)
        {
            ViewData["CustomerID"] = id.ToString();
            return View();
        }

        public IActionResult DeleteCustomer(int id)
        {
            new CustomerModel().DeleteCustomer(id);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
