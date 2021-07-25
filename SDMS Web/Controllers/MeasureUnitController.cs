using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SDMS_Web.Controllers
{
    public class MeasureUnitController : Controller
    {
        public IActionResult Index()
        {
            return View("../Setup/ProductMeasureUnit/Index");
        }
    }
}
