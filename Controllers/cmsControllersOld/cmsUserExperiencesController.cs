using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace AGS.ServerAPI.Controllers.cmsControllersOld
{
    public class cmsUserExperiencesController : Controller
    {
        private MedicalDBContext db = new MedicalDBContext();

        // GET: cmsUserExperiences
        public ActionResult Index()
        {
            var tblUserExperience = db.tblUserExperience.Include(t => t.tblExperienceTypes);
            return View(tblUserExperience.ToList());
        }

        // GET: cmsUserExperiences/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblUserExperience tblUserExperience = db.tblUserExperience.Find(id);
            if (tblUserExperience == null)
            {
                return HttpNotFound();
            }
            return View(tblUserExperience);
        }

        // GET: cmsUserExperiences/Create
        public ActionResult Create()
        {
            ViewBag.iExperienceTypeID = new SelectList(db.tblExperienceTypes, "iExperienceTypeID", "strExperienceTitle");
            return View();
        }

        // POST: cmsUserExperiences/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "iUxID,iAddedBy,dtAddedBy,iEditedBy,dtEditedby,iExperienceTypeID,strQuestion,strUxQuestionL,iUxQuestionM,strUxQuestionR,bIsDeleted")] tblUserExperience tblUserExperience)
        {
            if (ModelState.IsValid)
            {
                var user = (clsUsers)Session["clsUser"];
                tblUserExperience.dtAddedBy = DateTime.Now;
                tblUserExperience.iAddedBy = user.iUserID;
                tblUserExperience.dtEditedby = DateTime.Now;
                tblUserExperience.iEditedBy = user.iUserID;
                tblUserExperience.bIsDeleted = false;

                db.tblUserExperience.Add(tblUserExperience);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.iExperienceTypeID = new SelectList(db.tblExperienceTypes, "iExperienceTypeID", "strExperienceTitle", tblUserExperience.iExperienceTypeID);
            return View(tblUserExperience);
        }

        // GET: cmsUserExperiences/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblUserExperience tblUserExperience = db.tblUserExperience.Find(id);
            if (tblUserExperience == null)
            {
                return HttpNotFound();
            }
            ViewBag.iExperienceTypeID = new SelectList(db.tblExperienceTypes, "iExperienceTypeID", "strExperienceTitle", tblUserExperience.iExperienceTypeID);
            return View(tblUserExperience);
        }

        // POST: cmsUserExperiences/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "iUxID,iAddedBy,dtAddedBy,iEditedBy,dtEditedby,iExperienceTypeID,strQuestion,strUxQuestionL,iUxQuestionM,strUxQuestionR,bIsDeleted")] tblUserExperience tblUserExperience)
        {
            if (ModelState.IsValid)
            {
                var user = (clsUsers)Session["clsUser"];
                tblUserExperience.dtEditedby = DateTime.Now;
                tblUserExperience.iEditedBy = user.iUserID;

                db.Entry(tblUserExperience).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.iExperienceTypeID = new SelectList(db.tblExperienceTypes, "iExperienceTypeID", "strExperienceTitle", tblUserExperience.iExperienceTypeID);
            return View(tblUserExperience);
        }

        // GET: cmsUserExperiences/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblUserExperience tblUserExperience = db.tblUserExperience.Find(id);
            if (tblUserExperience == null)
            {
                return HttpNotFound();
            }
            return View(tblUserExperience);
        }

        // POST: cmsUserExperiences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblUserExperience tblUserExperience = db.tblUserExperience.Find(id);
            db.tblUserExperience.Remove(tblUserExperience);
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
