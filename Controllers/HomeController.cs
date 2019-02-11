using System.Web.Mvc;

namespace AGS.ServerAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        public ActionResult Administration()
        {
            ViewBag.Title = "Administration Page";

            return View();
        }
    }
}
