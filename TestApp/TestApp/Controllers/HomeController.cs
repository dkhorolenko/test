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
            var auth = FormsAuthentication.GetAuthCookie("vasya", true);
            return View(auth.Expires.ToUniversalTime());
        }

        [HttpPost]
        public ActionResult Login()
        {
            FormsAuthentication.SetAuthCookie("vasya", true);
            return RedirectToAction("Account");
        }

        [HttpPost]
        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize]
        public ActionResult Extend()
        {
            var auth = FormsAuthentication.GetAuthCookie("vasya", true);
            return Json(new { date = auth.Expires.ToUniversalTime().ToString("O") });
        }
    }
}