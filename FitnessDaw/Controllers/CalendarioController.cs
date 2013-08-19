using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FitnessDaw.Controllers
{
    public class CalendarioController : Controller
    {
        private FitnessDbEntities1 db = new FitnessDbEntities1();

        //
        // GET: /Calendario/

        public ActionResult Index()
        {
            var calendarios = db.calendarios.Include(c => c.usuario);
            return View(calendarios.ToList());
        }

        //
        // GET: /Calendario/Details/5

        public ActionResult Details(int id = 0)
        {
            calendario calendario = db.calendarios.Find(id);
            if (calendario == null)
            {
                return HttpNotFound();
            }
            return View(calendario);
        }

        //
        // GET: /Calendario/Create

        public ActionResult Create()
        {
            ViewBag.idUsuario = new SelectList(db.usuarios, "idUsuario", "nick");
            return View();
        }

        //
        // POST: /Calendario/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(calendario calendario)
        {
            if (ModelState.IsValid)
            {
                db.calendarios.Add(calendario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUsuario = new SelectList(db.usuarios, "idUsuario", "nick", calendario.idUsuario);
            return View(calendario);
        }

        //
        // GET: /Calendario/Edit/5

        public ActionResult Edit(int id = 0)
        {
            calendario calendario = db.calendarios.Find(id);
            if (calendario == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUsuario = new SelectList(db.usuarios, "idUsuario", "nick", calendario.idUsuario);
            return View(calendario);
        }

        //
        // POST: /Calendario/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(calendario calendario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(calendario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUsuario = new SelectList(db.usuarios, "idUsuario", "nick", calendario.idUsuario);
            return View(calendario);
        }

        //
        // GET: /Calendario/Delete/5

        public ActionResult Delete(int id = 0)
        {
            calendario calendario = db.calendarios.Find(id);
            if (calendario == null)
            {
                return HttpNotFound();
            }
            return View(calendario);
        }

        //
        // POST: /Calendario/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            calendario calendario = db.calendarios.Find(id);
            db.calendarios.Remove(calendario);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}