using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace AGS.ServerAPI.Controllers.cmsControllersOld
{
    public class cmsModulesController : Controller
    {
        private MedicalDBContext db = new MedicalDBContext();

        // GET: cmsModules
        public ActionResult Index()
        {
            return View(db.tblModules.ToList());
        }

        // GET: cmsModules/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblModules tblModules = db.tblModules.Find(id);
            if (tblModules == null)
            {
                return HttpNotFound();
            }
            return View(tblModules);
        }

        // GET: cmsModules/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: cmsModules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "strModID,iAddedBy,dtAddedBy,iEditedBy,dtEditedby,strModName,strModDescription,bModStatus,bIsDeleted")] tblModules tblModules)
        {
            if (ModelState.IsValid)
            {
                var user = (clsUsers)Session["clsUser"];
                tblModules.dtAddedBy = DateTime.Now;
                tblModules.iAddedBy = user.iUserID;
                tblModules.dtEditedby = DateTime.Now;
                tblModules.iEditedBy = user.iUserID;
                tblModules.bIsDeleted = false;

                db.tblModules.Add(tblModules);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblModules);
        }

        // GET: cmsModules/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblModules tblModules = db.tblModules.Find(id);
            if (tblModules == null)
            {
                return HttpNotFound();
            }
            return View(tblModules);
        }

        // POST: cmsModules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "strModID,iAddedBy,dtAddedBy,iEditedBy,dtEditedby,strModName,strModDescription,bModStatus,bIsDeleted")] tblModules tblModules)
        {
            if (ModelState.IsValid)
            {
                var user = (clsUsers)Session["clsUser"];
                tblModules.dtEditedby = DateTime.Now;
                tblModules.iEditedBy = user.iUserID;

                db.Entry(tblModules).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblModules);
        }

        // GET: cmsModules/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblModules tblModules = db.tblModules.Find(id);
            if (tblModules == null)
            {
                return HttpNotFound();
            }
            return View(tblModules);
        }

        // POST: cmsModules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tblModules tblModules = db.tblModules.Find(id);
            db.tblModules.Remove(tblModules);
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
