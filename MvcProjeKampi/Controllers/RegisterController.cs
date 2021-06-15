using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class RegisterController : Controller
    {
        IAuthService authService = new AuthManager(new AdminManager(new EfAdminDal()));
        // GET: Register
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(AdminForLoginAndRegister adminForLogin)
        {
            authService.Register(adminForLogin.AdminUserName, adminForLogin.AdminPassword);
            return RedirectToAction("Index", "AdminCategory");
        }
    }
}