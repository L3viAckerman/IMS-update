using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using IMS.Models;
using IMS.Modules.MUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers
{
    public class AppController : Controller
    {
        private IUserService UserService;
        public AppController(IUserService UserService)
        {
            this.UserService = UserService;
        }
        public IActionResult Index()
        {
            var file = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "index.html");
            return PhysicalFile(file, "text/html");
        }

        [Route("Login")]
        public IActionResult Login(UserEntity UserEntity)
        {
            try
            {
                if (Request.Method == "POST")
                {
                    string JWT = UserService.Login(UserEntity);
                    Response.Cookies.Append("JWT", JWT);
                    return RedirectToAction("Index", "InternNews");
                }
                return View();
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View();
        }
        [Route("Logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("JWT");
            return RedirectToAction("Login");
        }
    }
}