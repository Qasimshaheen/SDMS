﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SDMS_Web.Controllers
{
    public class ProductManufacturingController : Controller
    {
        public IActionResult Index()
        {
            return View("../Production/Index");
        }
    }
}