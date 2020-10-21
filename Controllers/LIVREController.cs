using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Loango.Models;

namespace Loango.Controllers
{
    public class LIVREController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: LIVRE
        public ActionResult Index()
        {
            var lIVRESet = db.LIVRESet.Include(l => l.USER);
            return View(lIVRESet.ToList());
        }

        // GET: LIVRE/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LIVRE lIVRE = db.LIVRESet.Find(id);
            if (lIVRE == null)
            {
                return HttpNotFound();
            }
            return View(lIVRE);
        }

        // GET: LIVRE/Create
        public ActionResult Create()
        {
            ViewBag.USERId_user = new SelectList(db.USERSet, "Id_user", "nom_user");
            return View();
        }

        // POST: LIVRE/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_livre,titre_livre,USERId_user")] LIVRE lIVRE)
        {
            if (ModelState.IsValid)
            {
                db.LIVRESet.Add(lIVRE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.USERId_user = new SelectList(db.USERSet, "Id_user", "nom_user", lIVRE.USERId_user);
            return View(lIVRE);
        }

        // GET: LIVRE/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LIVRE lIVRE = db.LIVRESet.Find(id);
            if (lIVRE == null)
            {
                return HttpNotFound();
            }
            ViewBag.USERId_user = new SelectList(db.USERSet, "Id_user", "nom_user", lIVRE.USERId_user);
            return View(lIVRE);
        }

        // POST: LIVRE/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_livre,titre_livre,USERId_user")] LIVRE lIVRE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lIVRE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.USERId_user = new SelectList(db.USERSet, "Id_user", "nom_user", lIVRE.USERId_user);
            return View(lIVRE);
        }

        // GET: LIVRE/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LIVRE lIVRE = db.LIVRESet.Find(id);
            if (lIVRE == null)
            {
                return HttpNotFound();
            }
            return View(lIVRE);
        }

        // POST: LIVRE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LIVRE lIVRE = db.LIVRESet.Find(id);
            db.LIVRESet.Remove(lIVRE);
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
