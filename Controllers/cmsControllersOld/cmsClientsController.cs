using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace AGS.ServerAPI.Controllers.cmsControllersOld
{
    public class cmsClientsController : Controller
    {
        private MedicalDBContext db = new MedicalDBContext();

        // GET: cmsClients
        public ActionResult Index()
        {
            return View(db.tblClients.ToList());
        }

        // GET: cmsClients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblClients tblClients = db.tblClients.Find(id);
            if (tblClients == null)
            {
                return HttpNotFound();
            }
            return View(tblClients);
        }

        // GET: cmsClients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: cmsClients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "iClientID,strClientID,iAddedBy,dtAddedBy,iEditedBy,dtEditedby,strFirstName,strSurname,iAge,strSex,strLocation,iRoleID,bIsDeleted")] tblClients tblClients)
        {
            if (ModelState.IsValid)
            {
                var user = (clsUsers)Session["clsUser"];
                tblClients.dtAddedBy = DateTime.Now;
                tblClients.iAddedBy = user.iUserID;
                tblClients.dtEditedby = DateTime.Now;
                tblClients.iEditedBy = user.iUserID;
                tblClients.bIsDeleted = false;

                db.tblClients.Add(tblClients);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblClients);
        }

        // GET: cmsClients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblClients tblClients = db.tblClients.Find(id);
            if (tblClients == null)
            {
                return HttpNotFound();
            }
            return View(tblClients);
        }

        // POST: cmsClients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "iClientID,strClientID,iAddedBy,dtAddedBy,iEditedBy,dtEditedby,strFirstName,strSurname,iAge,strSex,strLocation,iRoleID,bIsDeleted")] tblClients tblClients)
        {
            if (ModelState.IsValid)
            {
                var user = (clsUsers)Session["clsUser"];
                tblClients.dtEditedby = DateTime.Now;
                tblClients.iEditedBy = user.iUserID;

                db.Entry(tblClients).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblClients);
        }

        // GET: cmsClients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblClients tblClients = db.tblClients.Find(id);
            if (tblClients == null)
            {
                return HttpNotFound();
            }
            return View(tblClients);
        }

        // POST: cmsClients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblClients tblClients = db.tblClients.Find(id);
            db.tblClients.Remove(tblClients);
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
    }
}
