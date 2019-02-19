using System;
using System.IO;
using System.Web.Mvc;
using AGS.ServerAPI.Models;
using AGS.ServerAPI.Model_Managers;
using Newtonsoft.Json;

namespace AGS.ServerAPI.Controllers
{
    public class HomeController : Controller
    {
        public string strQuoteTempPath = @"c:/ftproot/Domains/AGS_joey/Connection_Config/ConnectionConfig.json";
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
                
                if (System.IO.File.Exists(strQuoteTempPath))
                {
                    System.IO.File.SetAttributes(strQuoteTempPath, FileAttributes.Normal);
                    System.IO.File.Delete(strQuoteTempPath);
                }
                System.IO.File.WriteAllText(strQuoteTempPath, json);
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

                if (System.IO.File.Exists(strQuoteTempPath))
                {
                    System.IO.File.SetAttributes(strQuoteTempPath, FileAttributes.Normal);
                    System.IO.File.Delete(strQuoteTempPath);
                }
                System.IO.File.WriteAllText(strQuoteTempPath, json);
            }
            return RedirectToAction("Administration", "Home", portManager);
        }

        public ActionResult Download(string fileName)
        {
            if (Path.GetExtension(fileName) != ".apk")
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.Forbidden);
            var fullPath = Path.Combine(Server.MapPath("~/Downloads/"), fileName);
            return File(fullPath, "application/vnd.android.package-archive");
        }

    }
}
