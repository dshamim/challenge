using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using App.Models;
using Microsoft.Extensions.Logging;

namespace App.Controllers
{
    public class ErrorController : Controller
    {      
        public IActionResult Index()
        {
            return View("Error");
        }
    }
}
