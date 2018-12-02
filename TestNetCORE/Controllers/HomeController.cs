using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestNetCORE.Models;
using TestNetCORE.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestNetCORE.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
