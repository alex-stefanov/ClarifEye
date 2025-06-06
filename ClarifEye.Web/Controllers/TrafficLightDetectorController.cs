﻿using ClarifEye.Common.Enums;
using Microsoft.AspNetCore.Mvc;

namespace ClarifEye.Web.Controllers
{
    public class TrafficLightDetectorController : Controller
    {
        public IActionResult Index(TrafficLight type)
        {
            ViewBag.TrafficLightValue = (int)type;
            
            return View();
        }
    }
}
