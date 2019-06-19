﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BestDeal.Controllers
{
    [Authorize(Policy ="SamoAdmin")]
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}