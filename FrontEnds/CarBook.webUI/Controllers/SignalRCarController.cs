﻿using Microsoft.AspNetCore.Mvc;

namespace CarBook.webUI.Controllers
{
    public class SignalRCarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
