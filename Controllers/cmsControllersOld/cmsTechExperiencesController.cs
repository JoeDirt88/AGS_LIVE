using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace AGS.ServerAPI.Controllers.cmsControllersOld
{
    public class cmsTechExperiencesController : Controller
    {
        private MedicalDBContext db = new MedicalDBContext();

        // GET: cmsTechExperiences
        public ActionResult Index()
        {
            var tblTechExperience = db.tblTechExperience.Include(t => t.tblExperienceTypes);
            return View(tblTechExperience.ToList());
        }

        // GET: cmsTechExperiences/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTechExperience tblTechExperience = db.tblTechExperience.Find(id);
            if (tblTechExperience == null)
            {
                return HttpNotFound();
            }
            return View(tblTechExperience);
        }

        // GET: cmsTechExperiences/Create
        public ActionResult Create()
        {
            ViewBag.iExperienceTypeID = new SelectList(db.tblExperienceTypes, "iExperienceTypeID", "strExperienceTitle");
            return View();
        }

        // POST: cmsTechExperiences/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "iTxID,iAddedBy,dtAddedBy,iEditedBy,dtEditedby,iExperienceTypeID,strQuestion,strTxQuestionL,iTxQuestionM,strTxQuestionR,bIsDeleted")] tblTechExperience tblTechExperience)
        {
            if (ModelState.IsValid)
            {

                var user = (clsUsers)Session["clsUser"];
                tblTechExperience.dtAddedBy = DateTime.Now;
                tblTechExperience.iAddedBy = user.iUserID;
                tblTechExperience.dtEditedby = DateTime.Now;
                tblTechExperience.iEditedBy = user.iUserID;
                tblTechExperience.bIsDeleted = false;

                db.tblTechExperience.Add(tblTechExperience);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.iExperienceTypeID = new SelectList(db.tblExperienceTypes, "iExperienceTypeID", "strExperienceTitle", tblTechExperience.iExperienceTypeID);
            return View(tblTechExperience);
        }

        // GET: cmsTechExperiences/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTechExperience tblTechExperience = db.tblTechExperience.Find(id);
            if (tblTechExperience == null)
            {
                return HttpNotFound();
            }
            ViewBag.iExperienceTypeID = new SelectList(db.tblExperienceTypes, "iExperienceTypeID", "strExperienceTitle", tblTechExperience.iExperienceTypeID);
            return View(tblTechExperience);
        }

        // POST: cmsTechExperiences/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "iTxID,iAddedBy,dtAddedBy,iEditedBy,dtEditedby,iExperienceTypeID,strQuestion,strTxQuestionL,iTxQuestionM,strTxQuestionR,bIsDeleted")] tblTechExperience tblTechExperience)
        {
            if (ModelState.IsValid)
            {
                var user = (clsUsers)Session["clsUser"];
                tblTechExperience.dtEditedby = DateTime.Now;
                tblTechExperience.iEditedBy = user.iUserID;

                db.Entry(tblTechExperience).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.iExperienceTypeID = new SelectList(db.tblExperienceTypes, "iExperienceTypeID", "strExperienceTitle", tblTechExperience.iExperienceTypeID);
            return View(tblTechExperience);
        }

        // GET: cmsTechExperiences/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTechExperience tblTechExperience = db.tblTechExperience.Find(id);
            if (tblTechExperience == null)
            {
                return HttpNotFound();
            }
            return View(tblTechExperience);
        }

        // POST: cmsTechExperiences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblTechExperience tblTechExperience = db.tblTechExperience.Find(id);
            db.tblTechExperience.Remove(tblTechExperience);
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
