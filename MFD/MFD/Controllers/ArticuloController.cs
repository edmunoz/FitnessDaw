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
    public class ArticuloController : Controller
    {
        private FitnessContext db = new FitnessContext();

        //
        // GET: /Articulo/

        public ActionResult Index()
        {
            return View(db.Articulos.ToList());
        }

        public ActionResult Calendario()
        {
            return View();
        }

        //
        // GET: /Articulo/Details/5

        public ActionResult Details(int id = 0)
        {
            Articulo articulo = db.Articulos.Find(id);
            if (articulo == null)
            {
                return HttpNotFound();
            }
            return View(articulo);
        }

        //
        // GET: /Articulo/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Articulo/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Articulo articulo)
        {
            if (ModelState.IsValid)
            {
                db.Articulos.Add(articulo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(articulo);
        }

        //
        // GET: /Articulo/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Articulo articulo = db.Articulos.Find(id);
            if (articulo == null)
            {
                return HttpNotFound();
            }
            return View(articulo);
        }

        //
        // POST: /Articulo/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Articulo articulo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(articulo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(articulo);
        }

        //
        // GET: /Articulo/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Articulo articulo = db.Articulos.Find(id);
            if (articulo == null)
            {
                return HttpNotFound();
            }
            return View(articulo);
        }

        //
        // POST: /Articulo/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Articulo articulo = db.Articulos.Find(id);
            db.Articulos.Remove(articulo);
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