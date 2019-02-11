using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace AGS.ServerAPI.Controllers.CMS_Controllers
{
    public class cmsExperienceAnswersController : Controller
    {
        private MedicalDBContext db = new MedicalDBContext();

        // GET: cmsExperienceAnswers
        public ActionResult Index()
        {
            var tblExperienceAnswers = db.tblExperienceAnswers.Include(t => t.tblExperienceTypes);
            return View(tblExperienceAnswers.ToList());
        }

        // GET: cmsExperienceAnswers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblExperienceAnswers tblExperienceAnswers = db.tblExperienceAnswers.Find(id);
            if (tblExperienceAnswers == null)
            {
                return HttpNotFound();
            }
            return View(tblExperienceAnswers);
        }

        // GET: cmsExperienceAnswers/Create
        public ActionResult Create()
        {
            ViewBag.iExperienceTypeID = new SelectList(db.tblExperienceTypes, "iExperienceTypeID", "strExperienceTitle");
            return View();
        }

        // POST: cmsExperienceAnswers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "iExperienceAnswerID,iAddedBy,dtAddedBy,iEditedBy,dtEditedby,strEmail,strPhone,strOccupation,iExperienceTypeID,strAnswers,iAverage,bIsDeleted")] tblExperienceAnswers tblExperienceAnswers)
        {
            if (ModelState.IsValid)
            {
                var user = (clsUsers)Session["clsUser"];
                tblExperienceAnswers.dtAddedBy = DateTime.Now;
                tblExperienceAnswers.iAddedBy = user.iUserID;
                tblExperienceAnswers.dtEditedby = DateTime.Now;
                tblExperienceAnswers.iEditedBy = user.iUserID;
                tblExperienceAnswers.bIsDeleted = false;

                db.tblExperienceAnswers.Add(tblExperienceAnswers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.iExperienceTypeID = new SelectList(db.tblExperienceTypes, "iExperienceTypeID", "strExperienceTitle", tblExperienceAnswers.iExperienceTypeID);
            return View(tblExperienceAnswers);
        }

        // GET: cmsExperienceAnswers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblExperienceAnswers tblExperienceAnswers = db.tblExperienceAnswers.Find(id);
            if (tblExperienceAnswers == null)
            {
                return HttpNotFound();
            }
            ViewBag.iExperienceTypeID = new SelectList(db.tblExperienceTypes, "iExperienceTypeID", "strExperienceTitle", tblExperienceAnswers.iExperienceTypeID);
            return View(tblExperienceAnswers);
        }

        // POST: cmsExperienceAnswers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "iExperienceAnswerID,iAddedBy,dtAddedBy,iEditedBy,dtEditedby,strEmail,strPhone,strOccupation,iExperienceTypeID,strAnswers,iAverage,bIsDeleted")] tblExperienceAnswers tblExperienceAnswers)
        {
            if (ModelState.IsValid)
            {
                var user = (clsUsers)Session["clsUser"];
                tblExperienceAnswers.dtEditedby = DateTime.Now;
                tblExperienceAnswers.iEditedBy = user.iUserID;

                db.Entry(tblExperienceAnswers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.iExperienceTypeID = new SelectList(db.tblExperienceTypes, "iExperienceTypeID", "strExperienceTitle", tblExperienceAnswers.iExperienceTypeID);
            return View(tblExperienceAnswers);
        }

        // GET: cmsExperienceAnswers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblExperienceAnswers tblExperienceAnswers = db.tblExperienceAnswers.Find(id);
            if (tblExperienceAnswers == null)
            {
                return HttpNotFound();
            }
            return View(tblExperienceAnswers);
        }

        // POST: cmsExperienceAnswers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblExperienceAnswers tblExperienceAnswers = db.tblExperienceAnswers.Find(id);
            db.tblExperienceAnswers.Remove(tblExperienceAnswers);
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
