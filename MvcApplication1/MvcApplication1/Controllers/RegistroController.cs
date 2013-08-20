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
    public class RegistroController : Controller
    {
        private FitnessDb db = new FitnessDb();

        //
        // GET: /Registro/

        public ActionResult Index()
        {
            var usuario = db.Usuario.Include(u => u.Calendario);
            return View(usuario.ToList());
        }

        //
        // GET: /Registro/Details/5

        public ActionResult Details(int id = 0)
        {
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        //
        // GET: /Registro/Create

        public ActionResult Create()
        {
            ViewBag.idUsuario = new SelectList(db.Calendario, "idCalendatio", "idCalendatio");
            return View();
        }

        //
        // POST: /Registro/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Usuario.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUsuario = new SelectList(db.Calendario, "idCalendatio", "idCalendatio", usuario.idUsuario);
            return View(usuario);
        }

        //
        // GET: /Registro/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUsuario = new SelectList(db.Calendario, "idCalendatio", "idCalendatio", usuario.idUsuario);
            return View(usuario);
        }

        //
        // POST: /Registro/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUsuario = new SelectList(db.Calendario, "idCalendatio", "idCalendatio", usuario.idUsuario);
            return View(usuario);
        }

        //
        // GET: /Registro/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        //
        // POST: /Registro/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario usuario = db.Usuario.Find(id);
            db.Usuario.Remove(usuario);
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