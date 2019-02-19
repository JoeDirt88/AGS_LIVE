using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using AGS.ServerAPI.Model_Managers;

namespace AGS.ServerAPI.Controllers
{
    public class LoginController : Controller
    {
        // GET
        public ActionResult Login()
        {

            var clsUser = new clsUsers();
            HttpCookie hcUserEmailCookie = Request.Cookies["strUserEmail"];
            if (hcUserEmailCookie != null)
            {
                clsUser.strEmail = hcUserEmailCookie.Value; //Get the email
            }
            else if (TempData["bUserEmailnotFound"] != null)
            {
                ViewBag.Message = "Please check if you have entered the correct username/email!";
                ViewBag.Register = true;
            }
            return View(clsUser);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(clsUsers clsUser)
        {
            //CMS Users Manager
            var clsUsersManager = new clsUsersManager();
            //CMS User
            var clsCurrentUser = clsUsersManager.getUserByEmail(clsUser.strEmail.ToLower());
            if (clsUser == null)
            {
                TempData["bUserEmailnotFound"] = true;
                return RedirectToAction("Login"); // login unsuccessful
            }
            else
            {
                //If User does not exist
                if (clsCurrentUser == null)
                {
                    ModelState.AddModelError("loginError", "Incorrect Login Credentials Entered");
                    clsCurrentUser.strPhone = string.Empty;
                    return View(clsCurrentUser);
                }
                //If password is incorrect
                if (clsCurrentUser.strPhone != clsUser.strPhone)
                {
                    ModelState.AddModelError("loginError", "Incorrect Login Credentials Entered");
                    clsCurrentUser.strPhone = string.Empty;
                    return View(clsCurrentUser);
                }
                else
                {
                    //Set cookie
                    if (Request.Cookies["strUserEmail"] != null)
                    {
                        Response.Cookies["strUserEmail"].Expires = DateTime.Now.AddDays(-1);
                    }

                    //Reset error message
                    ModelState.AddModelError("loginError", "");
                    Session["clsUser"] = clsCurrentUser;

                    return RedirectToAction("Administration", "Home"); // login succeed 
                }
            }
        }

        
        public ActionResult Logout()
        {
            Session.Remove("clsUser");
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public JsonResult checkIfEmailExists([Bind(Prefix = "strEmail")] string strEmail)
        {
            var bCanUseEmail = false;
            var clsUserManager = new clsUsersManager();
            if (!string.IsNullOrEmpty(strEmail))
                strEmail = strEmail.ToLower();
            var bDoesUserEmailExist = clsUserManager.checkIfUserExists(strEmail);
            if (bDoesUserEmailExist == false)
                bCanUseEmail = true;
            return Json(bCanUseEmail, JsonRequestBehavior.AllowGet);
        }
    }
}