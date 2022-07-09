using hw5.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hw5.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                var userGender = user.Gender;
                if (userGender.Equals("male"))
                {
                    ViewBag.FullName = user.FullName;
                    return View("Thanks");
                }
                else
                {
                    return View("Sorry");
                }
            }
            else
            {
                return View();
            }
        }
    }
}
