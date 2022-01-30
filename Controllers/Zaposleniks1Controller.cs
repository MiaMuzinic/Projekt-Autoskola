using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autoskola_Mia.Controllers
{
    public class Zaposleniks1Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
