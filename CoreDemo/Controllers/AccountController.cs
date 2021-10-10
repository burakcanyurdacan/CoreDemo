using BusinessLogicLayer.Concrete;
using BusinessLogicLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class AccountController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Writer p)
        {
            WriterValidator wv = new WriterValidator();
            ValidationResult valRes = wv.Validate(p);
            if (valRes.IsValid)
            {
                p.WriterAbout = "";
                p.WriterStatus = true;
                wm.AddWriter(p);
                return RedirectToAction("Login", "Account");
            }
            else
            {
                foreach (var item in valRes.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}
