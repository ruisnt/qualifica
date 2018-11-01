using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Qualifica.Frontend.Controllers
{
    public class ConquistasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}