using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class CalendarioController : Controller
    {
        private FitnessDb db = new FitnessDb();

        //
        // GET: /Calendario/

        public ActionResult Index()
        {
            var calendario = db.Calendario.Include(c => c.Usuario);
            return View(calendario.ToList());
        }

        //
        // GET: /Calendario/Details/5

        public ActionResult Details(int id = 0)
        {
            Calendario calendario = db.Calendario.Find(id);
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
            ViewBag.idCalendatio = new SelectList(db.Usuario, "idUsuario", "nick");
            return View();
        }

        //
        // POST: /Calendario/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Calendario calendario)
        {
            if (ModelState.IsValid)
            {
                db.Calendario.Add(calendario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCalendatio = new SelectList(db.Usuario, "idUsuario", "nick", calendario.idCalendatio);
            return View(calendario);
        }

        //
        // GET: /Calendario/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Calendario calendario = db.Calendario.Find(id);
            if (calendario == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCalendatio = new SelectList(db.Usuario, "idUsuario", "nick", calendario.idCalendatio);
            return View(calendario);
        }

        //
        // POST: /Calendario/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Calendario calendario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(calendario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCalendatio = new SelectList(db.Usuario, "idUsuario", "nick", calendario.idCalendatio);
            return View(calendario);
        }

        //
        // GET: /Calendario/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Calendario calendario = db.Calendario.Find(id);
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
            Calendario calendario = db.Calendario.Find(id);
            db.Calendario.Remove(calendario);
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