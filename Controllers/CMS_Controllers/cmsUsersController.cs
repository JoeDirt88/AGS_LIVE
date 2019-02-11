using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AGS.ServerAPI.Model_Managers;

namespace AGS.ServerAPI.Controllers.CMS_Controllers
{
    public class cmsUsersController : Controller
    {
        private MedicalDBContext db = new MedicalDBContext();

        // GET: cmsUsers
        public ActionResult Index()
        {
            return View(db.tblUsers.ToList());
        }

        // GET: cmsUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblUsers tblUsers = db.tblUsers.Find(id);
            if (tblUsers == null)
            {
                return HttpNotFound();
            }
            return View(tblUsers);
        }

        // GET: cmsUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: cmsUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "iUserID,iAddedBy,dtAddedBy,iEditedBy,dtEditedby,strFirstName,strSurname,strEmail,strPhone,strLocation,iRoleID,bIsDeleted")] tblUsers tblUsers)
        {
            if (ModelState.IsValid)
            {
                var user = (clsUsers)Session["clsUser"];
                tblUsers.dtAddedBy = DateTime.Now;
                tblUsers.iAddedBy = user.iUserID;
                tblUsers.dtEditedby = DateTime.Now;
                tblUsers.iEditedBy = user.iUserID;
                tblUsers.bIsDeleted = false;

                db.tblUsers.Add(tblUsers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblUsers);
        }

        // GET: cmsUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblUsers tblUsers = db.tblUsers.Find(id);
            if (tblUsers == null)
            {
                return HttpNotFound();
            }
            return View(tblUsers);
        }

        // POST: cmsUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "iUserID,iAddedBy,dtAddedBy,iEditedBy,dtEditedby,strFirstName,strSurname,strEmail,strPhone,strLocation,iRoleID,bIsDeleted")] tblUsers tblUsers)
        {
            if (ModelState.IsValid)
            {
                var user = (clsUsers)Session["clsUser"];
                tblUsers.dtEditedby = DateTime.Now;
                tblUsers.iEditedBy = user.iUserID;

                db.Entry(tblUsers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblUsers);
        }

        // GET: cmsUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblUsers tblUsers = db.tblUsers.Find(id);
            if (tblUsers == null)
            {
                return HttpNotFound();
            }
            return View(tblUsers);
        }

        // POST: cmsUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblUsers tblUsers = db.tblUsers.Find(id);
            db.tblUsers.Remove(tblUsers);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        // USER ADDED
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
