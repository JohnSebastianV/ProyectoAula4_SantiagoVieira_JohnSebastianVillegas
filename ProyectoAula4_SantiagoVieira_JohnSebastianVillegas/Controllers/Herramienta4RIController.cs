using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoAula4_SantiagoVieira_JohnSebastianVillegas;

namespace ProyectoAula4_SantiagoVieira_JohnSebastianVillegas.Controllers
{
    public class Herramienta4RIController : Controller
    {
        private ProyectoDeAula4JohnSebastian_SantiagoEntities db = new ProyectoDeAula4JohnSebastian_SantiagoEntities();

        // GET: Herramienta4RI
        public ActionResult Index()
        {
            return View(db.Herramienta4RI.ToList());
        }

        // GET: Herramienta4RI/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Herramienta4RI herramienta4RI = db.Herramienta4RI.Find(id);
            if (herramienta4RI == null)
            {
                return HttpNotFound();
            }
            return View(herramienta4RI);
        }

        // GET: Herramienta4RI/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Herramienta4RI/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nombre")] Herramienta4RI herramienta4RI)
        {
            if (ModelState.IsValid)
            {
                db.Herramienta4RI.Add(herramienta4RI);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(herramienta4RI);
        }

        // GET: Herramienta4RI/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Herramienta4RI herramienta4RI = db.Herramienta4RI.Find(id);
            if (herramienta4RI == null)
            {
                return HttpNotFound();
            }
            return View(herramienta4RI);
        }

        // POST: Herramienta4RI/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nombre")] Herramienta4RI herramienta4RI)
        {
            if (ModelState.IsValid)
            {
                db.Entry(herramienta4RI).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(herramienta4RI);
        }

        // GET: Herramienta4RI/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Herramienta4RI herramienta4RI = db.Herramienta4RI.Find(id);
            if (herramienta4RI == null)
            {
                return HttpNotFound();
            }
            return View(herramienta4RI);
        }

        // POST: Herramienta4RI/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Herramienta4RI herramienta4RI = db.Herramienta4RI.Find(id);
            db.Herramienta4RI.Remove(herramienta4RI);
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
