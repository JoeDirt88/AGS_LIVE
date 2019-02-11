using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace AGS.ServerAPI.Controllers.CMS_Controllers
{
    public class cmsResultsController : Controller
    {
        private MedicalDBContext db = new MedicalDBContext();

        // GET: cmsResults
        public ActionResult Index()
        {
            var tblResult = db.tblResult.Include(t => t.tblModules);
            return View(tblResult.ToList());
        }

        // GET: cmsResults/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblResult tblResult = db.tblResult.Find(id);
            if (tblResult == null)
            {
                return HttpNotFound();
            }
            return View(tblResult);
        }

        // GET: cmsResults/Create
        public ActionResult Create()
        {
            ViewBag.strModID = new SelectList(db.tblModules, "strModID", "strModName");
            return View();
        }

        // POST: cmsResults/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "iResultID,iAddedBy,dtAddedBy,iEditedBy,dtEditedby,strClientID,strModID,TestData,Result,bIsDeleted")] tblResult tblResult)
        {
            if (ModelState.IsValid)
            {
                var user = (clsUsers)Session["clsUser"];
                tblResult.dtAddedBy = DateTime.Now;
                tblResult.iAddedBy = user.iUserID;
                tblResult.dtEditedby = DateTime.Now;
                tblResult.iEditedBy = user.iUserID;
                tblResult.bIsDeleted = false;

                db.tblResult.Add(tblResult);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.strModID = new SelectList(db.tblModules, "strModID", "strModName", tblResult.strModID);
            return View(tblResult);
        }

        // GET: cmsResults/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblResult tblResult = db.tblResult.Find(id);
            if (tblResult == null)
            {
                return HttpNotFound();
            }
            ViewBag.strModID = new SelectList(db.tblModules, "strModID", "strModName", tblResult.strModID);
            return View(tblResult);
        }

        // POST: cmsResults/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "iResultID,iAddedBy,dtAddedBy,iEditedBy,dtEditedby,strClientID,strModID,TestData,Result,bIsDeleted")] tblResult tblResult)
        {
            if (ModelState.IsValid)
            {
                var user = (clsUsers)Session["clsUser"];
                tblResult.dtEditedby = DateTime.Now;
                tblResult.iEditedBy = user.iUserID;

                db.Entry(tblResult).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.strModID = new SelectList(db.tblModules, "strModID", "strModName", tblResult.strModID);
            return View(tblResult);
        }

        // GET: cmsResults/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblResult tblResult = db.tblResult.Find(id);
            if (tblResult == null)
            {
                return HttpNotFound();
            }
            return View(tblResult);
        }

        // POST: cmsResults/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblResult tblResult = db.tblResult.Find(id);
            db.tblResult.Remove(tblResult);
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
