using System;
using System.Web.Mvc;
using System.Web.Security;

namespace TestApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Account()
        {
            return View(DateTime.UtcNow);
        }

        [HttpPost]
        public ActionResult Login()
        {
            FormsAuthentication.SetAuthCookie("vasya", true);

            return RedirectToAction("Account");
        }

        [HttpPost]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Extend()
        {
            return Json(new { date = DateTime.UtcNow });
        }

        public ActionResult Close()
        {
            return Json(new { date = DateTime.UtcNow });
        }
    }
}