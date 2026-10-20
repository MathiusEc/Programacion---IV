using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using S1_SailorMoon.Models;

namespace S1_SailorMoon.Controllers
{
    public class AliadoesController : Controller
    {
        private SailorMoonContext db = new SailorMoonContext();

        // GET: Aliadoes
        public ActionResult Index()
        {
            return View(db.Aliados.ToList());
        }

        // GET: Aliadoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aliado aliado = db.Aliados.Find(id);
            if (aliado == null)
            {
                return HttpNotFound();
            }
            return View(aliado);
        }

        // GET: Aliadoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Aliadoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NombreAliado,Tipo,Edad,SailorSenshiId")] Aliado aliado)
        {
            if (ModelState.IsValid)
            {
                db.Aliados.Add(aliado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aliado);
        }

        // GET: Aliadoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aliado aliado = db.Aliados.Find(id);
            if (aliado == null)
            {
                return HttpNotFound();
            }
            return View(aliado);
        }

        // POST: Aliadoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NombreAliado,Tipo,Edad,SailorSenshiId")] Aliado aliado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aliado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aliado);
        }

        // GET: Aliadoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aliado aliado = db.Aliados.Find(id);
            if (aliado == null)
            {
                return HttpNotFound();
            }
            return View(aliado);
        }

        // POST: Aliadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Aliado aliado = db.Aliados.Find(id);
            db.Aliados.Remove(aliado);
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
