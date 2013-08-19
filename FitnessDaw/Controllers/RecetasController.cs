using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FitnessDaw.Controllers
{
    public class RecetasController : Controller
    {
        private FitnessDbEntities1 db = new FitnessDbEntities1();

        //
        // GET: /Recetas/

        public ActionResult Index()
        {
            var recetas = db.recetas.Include(r => r.calendario).Include(r => r.usuario);
            return View(recetas.ToList());
        }

        //
        // GET: /Recetas/Details/5

        public ActionResult Details(int id = 0)
        {
            receta receta = db.recetas.Find(id);
            if (receta == null)
            {
                return HttpNotFound();
            }
            return View(receta);
        }

        //
        // GET: /Recetas/Create

        public ActionResult Create()
        {
            ViewBag.idCalendario = new SelectList(db.calendarios, "idCalendario", "idCalendario");
            ViewBag.idUsuario = new SelectList(db.usuarios, "idUsuario", "nick");
            return View();
        }

        //
        // POST: /Recetas/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(receta receta)
        {
            if (ModelState.IsValid)
            {
                db.recetas.Add(receta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCalendario = new SelectList(db.calendarios, "idCalendario", "idCalendario", receta.idCalendario);
            ViewBag.idUsuario = new SelectList(db.usuarios, "idUsuario", "nick", receta.idUsuario);
            return View(receta);
        }

        //
        // GET: /Recetas/Edit/5

        public ActionResult Edit(int id = 0)
        {
            receta receta = db.recetas.Find(id);
            if (receta == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCalendario = new SelectList(db.calendarios, "idCalendario", "idCalendario", receta.idCalendario);
            ViewBag.idUsuario = new SelectList(db.usuarios, "idUsuario", "nick", receta.idUsuario);
            return View(receta);
        }

        //
        // POST: /Recetas/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(receta receta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(receta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCalendario = new SelectList(db.calendarios, "idCalendario", "idCalendario", receta.idCalendario);
            ViewBag.idUsuario = new SelectList(db.usuarios, "idUsuario", "nick", receta.idUsuario);
            return View(receta);
        }

        //
        // GET: /Recetas/Delete/5

        public ActionResult Delete(int id = 0)
        {
            receta receta = db.recetas.Find(id);
            if (receta == null)
            {
                return HttpNotFound();
            }
            return View(receta);
        }

        //
        // POST: /Recetas/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            receta receta = db.recetas.Find(id);
            db.recetas.Remove(receta);
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