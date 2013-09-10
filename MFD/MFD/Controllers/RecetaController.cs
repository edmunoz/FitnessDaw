using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MFD.Models;

namespace MFD.Controllers
{
    public class RecetaController : Controller
    {
        private FitnessContext db = new FitnessContext();

        //
        // GET: /Receta/

        public ActionResult Index()
        {
            var recetas = db.Recetas.Include(r => r.Usuario);
            return View(recetas.ToList());
        }

        //
        // GET: /Receta/Details/5

        public ActionResult Details(int id = 0)
        {
            Receta receta = db.Recetas.Find(id);
            if (receta == null)
            {
                return HttpNotFound();
            }
            return View(receta);
        }

        //
        // GET: /Receta/Create

        public ActionResult Create()
        {
            ViewBag.idUsuario = new SelectList(db.Usuarios, "idUsuario", "nick");
            return View();
        }

        //
        // POST: /Receta/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Receta receta)
        {
            if (ModelState.IsValid)
            {
                db.Recetas.Add(receta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUsuario = new SelectList(db.Usuarios, "idUsuario", "nick", receta.idUsuario);
            return View(receta);
        }

        //
        // GET: /Receta/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Receta receta = db.Recetas.Find(id);
            if (receta == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUsuario = new SelectList(db.Usuarios, "idUsuario", "nick", receta.idUsuario);
            return View(receta);
        }

        //
        // POST: /Receta/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Receta receta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(receta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUsuario = new SelectList(db.Usuarios, "idUsuario", "nick", receta.idUsuario);
            return View(receta);
        }

        //
        // GET: /Receta/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Receta receta = db.Recetas.Find(id);
            if (receta == null)
            {
                return HttpNotFound();
            }
            return View(receta);
        }

        //
        // POST: /Receta/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Receta receta = db.Recetas.Find(id);
            db.Recetas.Remove(receta);
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