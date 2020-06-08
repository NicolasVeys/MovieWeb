using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MovieApp.Controllers
{
    public class HelloController : Controller
    {
        public IActionResult Welcome(string name = "vreemdeling", int numberOfTimes= 2)
        {
            ViewData["name"] = name;
            ViewData["numberOfTimes"] = numberOfTimes;
            return View();
        }
    }
}
