using ComplainManagement.MVC.Models;
using ComplainManagement.MVC.Persistance;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplainManagement.MVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var loginVm = new LoginVm();
            return View(loginVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("UserName,Password")] LoginVm user)
        {
            if (ModelState.IsValid)
            {
                var userFromDb =_context.Users.Where(u => u.UserName==user.UserName).FirstOrDefault();
                if (userFromDb!=null)
                {
                    if(userFromDb.Password == user.Password)
                    {
                        //var result = await _signInMgr.PasswordSignInAsync(model.UserName, model.Password, false, false);
                        //if (result.Succeeded)
                        //{
                        //    return Ok();
                        //}
                        HttpContext.Session.SetString("UserName", user.UserName);
                        return RedirectToAction("Index","Home");
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }
    }
}
