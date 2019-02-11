using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace AGS.ServerAPI.Controllers.cmsControllersOld
{
    public class cmsQuestionsController : Controller
    {
        private MedicalDBContext db = new MedicalDBContext();

        // GET: cmsQuestions
        public ActionResult Index()
        {
            return View(db.tblQuestions.ToList());
        }

        // GET: cmsQuestions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblQuestions tblQuestions = db.tblQuestions.Find(id);
            if (tblQuestions == null)
            {
                return HttpNotFound();
            }
            return View(tblQuestions);
        }

        // GET: cmsQuestions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: cmsQuestions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "iQuestionID,strQuestionID,iAddedBy,dtAddedBy,iEditedBy,dtEditedby,strQuestion,strFlavourText,strSignificance,strUnit,bIsDeleted")] tblQuestions tblQuestions)
        {
            if (ModelState.IsValid)
            {
                var user = (clsUsers)Session["clsUser"];
                tblQuestions.dtAddedBy = DateTime.Now;
                tblQuestions.iAddedBy = user.iUserID;
                tblQuestions.dtEditedby = DateTime.Now;
                tblQuestions.iEditedBy = user.iUserID;
                tblQuestions.bIsDeleted = false;

                db.tblQuestions.Add(tblQuestions);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblQuestions);
        }

        // GET: cmsQuestions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblQuestions tblQuestions = db.tblQuestions.Find(id);
            if (tblQuestions == null)
            {
                return HttpNotFound();
            }
            return View(tblQuestions);
        }

        // POST: cmsQuestions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "iQuestionID,strQuestionID,iAddedBy,dtAddedBy,iEditedBy,dtEditedby,strQuestion,strFlavourText,strSignificance,strUnit,bIsDeleted")] tblQuestions tblQuestions)
        {
            if (ModelState.IsValid)
            {
                var user = (clsUsers)Session["clsUser"];
                tblQuestions.dtEditedby = DateTime.Now;
                tblQuestions.iEditedBy = user.iUserID;

                db.Entry(tblQuestions).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblQuestions);
        }

        // GET: cmsQuestions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblQuestions tblQuestions = db.tblQuestions.Find(id);
            if (tblQuestions == null)
            {
                return HttpNotFound();
            }
            return View(tblQuestions);
        }

        // POST: cmsQuestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblQuestions tblQuestions = db.tblQuestions.Find(id);
            db.tblQuestions.Remove(tblQuestions);
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
