using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace AGS.ServerAPI.Controllers.CMS_Controllers
{
    public class cmsExperienceTypesController : Controller
    {
        private MedicalDBContext db = new MedicalDBContext();

        // GET: cmsExperienceTypes
        public ActionResult Index()
        {
            return View(db.tblExperienceTypes.ToList());
        }

        // GET: cmsExperienceTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblExperienceTypes tblExperienceTypes = db.tblExperienceTypes.Find(id);
            if (tblExperienceTypes == null)
            {
                return HttpNotFound();
            }
            return View(tblExperienceTypes);
        }

        // GET: cmsExperienceTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: cmsExperienceTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "iExperienceTypeID,iAddedBy,dtAddedBy,iEditedBy,dtEditedby,strExperienceTitle,bIsDeleted")] tblExperienceTypes tblExperienceTypes)
        {
            if (ModelState.IsValid)
            {
                var user = (clsUsers)Session["clsUser"];
                tblExperienceTypes.dtAddedBy = DateTime.Now;
                tblExperienceTypes.iAddedBy = user.iUserID;
                tblExperienceTypes.dtEditedby = DateTime.Now;
                tblExperienceTypes.iEditedBy = user.iUserID;
                tblExperienceTypes.bIsDeleted = false;

                db.tblExperienceTypes.Add(tblExperienceTypes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblExperienceTypes);
        }

        // GET: cmsExperienceTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblExperienceTypes tblExperienceTypes = db.tblExperienceTypes.Find(id);
            if (tblExperienceTypes == null)
            {
                return HttpNotFound();
            }
            return View(tblExperienceTypes);
        }

        // POST: cmsExperienceTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "iExperienceTypeID,iAddedBy,dtAddedBy,iEditedBy,dtEditedby,strExperienceTitle,bIsDeleted")] tblExperienceTypes tblExperienceTypes)
        {
            if (ModelState.IsValid)
            {
                var user = (clsUsers)Session["clsUser"];
                tblExperienceTypes.dtEditedby = DateTime.Now;
                tblExperienceTypes.iEditedBy = user.iUserID;

                db.Entry(tblExperienceTypes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblExperienceTypes);
        }

        // GET: cmsExperienceTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblExperienceTypes tblExperienceTypes = db.tblExperienceTypes.Find(id);
            if (tblExperienceTypes == null)
            {
                return HttpNotFound();
            }
            return View(tblExperienceTypes);
        }

        // POST: cmsExperienceTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblExperienceTypes tblExperienceTypes = db.tblExperienceTypes.Find(id);
            db.tblExperienceTypes.Remove(tblExperienceTypes);
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
