﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FitnessDaw.Controllers
{
    public class InicioController : Controller
    {
        private FitnessDbEntities1 db = new FitnessDbEntities1();

        //
        // GET: /Inicio/

        public ActionResult Index()
        {
            var articuloes = db.articuloes.Include(a => a.usuario);
            return View(articuloes.ToList());
        }

        //
        // GET: /Inicio/Details/5

        public ActionResult Details(int id = 0)
        {
            articulo articulo = db.articuloes.Find(id);
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
            ViewBag.idUsuario = new SelectList(db.usuarios, "idUsuario", "nick");
            return View();
        }

        //
        // POST: /Inicio/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(articulo articulo)
        {
            if (ModelState.IsValid)
            {
                db.articuloes.Add(articulo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUsuario = new SelectList(db.usuarios, "idUsuario", "nick", articulo.idUsuario);
            return View(articulo);
        }

        //
        // GET: /Inicio/Edit/5

        public ActionResult Edit(int id = 0)
        {
            articulo articulo = db.articuloes.Find(id);
            if (articulo == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUsuario = new SelectList(db.usuarios, "idUsuario", "nick", articulo.idUsuario);
            return View(articulo);
        }

        //
        // POST: /Inicio/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(articulo articulo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(articulo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUsuario = new SelectList(db.usuarios, "idUsuario", "nick", articulo.idUsuario);
            return View(articulo);
        }

        //
        // GET: /Inicio/Delete/5

        public ActionResult Delete(int id = 0)
        {
            articulo articulo = db.articuloes.Find(id);
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
            articulo articulo = db.articuloes.Find(id);
            db.articuloes.Remove(articulo);
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