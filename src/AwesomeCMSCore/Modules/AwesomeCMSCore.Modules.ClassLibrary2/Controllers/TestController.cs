﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ClassLibrary1.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
      
    }
}
