using SamFirstProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SamFirstProject.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string UserName,string Password)
        {
            
            DatabaseContext _context = new DatabaseContext();
            User _user = new User();
            _user.UserName = UserName;
            _user.Password = "";
            _user.Message = "Giriş Başarısız..";
            foreach (var item in _context.Users)
            {
                if (item.UserName == UserName && item.Password==Password)
                {
                    _user.UserName = UserName;
                    _user.Password = "";
                    _user.Message = "Giriş Başarılı..";
                    return RedirectToAction("Index", "Home");
                }
            }
        
            return View();
        }
    }
}