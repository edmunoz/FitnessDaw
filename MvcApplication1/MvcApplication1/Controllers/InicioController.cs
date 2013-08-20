﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class InicioController : Controller
    {
        private FitnessDb db = new FitnessDb();

        //
        // GET: /Inicio/

        public ActionResult Index()
        {
            return View(db.Articulo.ToList());
        }

        //
        // GET: /Inicio/Details/5

        public ActionResult Details(int id = 0)
        {
            Articulo articulo = db.Articulo.Find(id);
            if (articulo == null)
            {
                return HttpNotFound();
            }
            return View(articulo);
        }

        //
        // GET: /Inicio/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Inicio/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Articulo articulo)
        {
            if (ModelState.IsValid)
            {
                db.Articulo.Add(articulo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(articulo);
        }

        //
        // GET: /Inicio/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Articulo articulo = db.Articulo.Find(id);
            if (articulo == null)
            {
                return HttpNotFound();
            }
            return View(articulo);
        }

        //
        // POST: /Inicio/Edit/5

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
        // GET: /Inicio/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Articulo articulo = db.Articulo.Find(id);
            if (articulo == null)
            {
                return HttpNotFound();
            }
            return View(articulo);
        }

        //
        // POST: /Inicio/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Articulo articulo = db.Articulo.Find(id);
            db.Articulo.Remove(articulo);
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