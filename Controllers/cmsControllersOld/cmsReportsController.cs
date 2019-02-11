using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace AGS.ServerAPI.Controllers.cmsControllersOld
{
    public class cmsReportsController : Controller
    {
        private MedicalDBContext db = new MedicalDBContext();

        // GET: cmsReports
        public ActionResult Index()
        {
            return View(db.tblReports.ToList());
        }

        // GET: cmsReports/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblReports tblReports = db.tblReports.Find(id);
            if (tblReports == null)
            {
                return HttpNotFound();
            }
            return View(tblReports);
        }

        // GET: cmsReports/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: cmsReports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "iReportID,iAddedBy,dtAddedBy,iEditedBy,dtEditedby,strReport,strEmail,strContactNumber,bIsDeleted")] tblReports tblReports)
        {
            if (ModelState.IsValid)
            {
                var user = (clsUsers)Session["clsUser"];
                tblReports.dtAddedBy = DateTime.Now;
                tblReports.iAddedBy = user.iUserID;
                tblReports.dtEditedby = DateTime.Now;
                tblReports.iEditedBy = user.iUserID;
                tblReports.bIsDeleted = false;

                db.tblReports.Add(tblReports);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblReports);
        }

        // GET: cmsReports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblReports tblReports = db.tblReports.Find(id);
            if (tblReports == null)
            {
                return HttpNotFound();
            }
            return View(tblReports);
        }

        // POST: cmsReports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "iReportID,iAddedBy,dtAddedBy,iEditedBy,dtEditedby,strReport,strEmail,strContactNumber,bIsDeleted")] tblReports tblReports)
        {
            if (ModelState.IsValid)
            {
                var user = (clsUsers)Session["clsUser"];
                tblReports.dtEditedby = DateTime.Now;
                tblReports.iEditedBy = user.iUserID;

                db.Entry(tblReports).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblReports);
        }

        // GET: cmsReports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblReports tblReports = db.tblReports.Find(id);
            if (tblReports == null)
            {
                return HttpNotFound();
            }
            return View(tblReports);
        }

        // POST: cmsReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblReports tblReports = db.tblReports.Find(id);
            db.tblReports.Remove(tblReports);
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
