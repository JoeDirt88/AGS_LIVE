using System;
using System.Web.Mvc;
using AGS.ServerAPI.Models;
using AGS.ServerAPI.Model_Managers;
using Newtonsoft.Json;

namespace AGS.ServerAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Administration(PortManager portManager)
        {
            ViewBag.Title = "Administration Page";
            if (portManager.ip != null && portManager.port != null)
            {
                var json = JsonConvert.SerializeObject(portManager);
                System.IO.File.WriteAllText(@"c:/ftproot/Domains/AGS_joey/Connection_Config/ConnectionConfig.json", json);
            }
            return View(portManager);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Administrate(PortManager portManager)
        {
            if (portManager.ip != null && portManager.port != null)
            {
                var json = JsonConvert.SerializeObject(portManager);
                System.IO.File.WriteAllText(@"c:/ftproot/Domains/AGS_joey/Connection_Config/ConnectionConfig.json", json);
            }
            return RedirectToAction("Administration","Home",portManager);
        }
    }
}
