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
    public class IntegranteEquipoController : Controller
    {
        private ProyectoDeAula4JohnSebastian_SantiagoEntities db = new ProyectoDeAula4JohnSebastian_SantiagoEntities();

        
        public ActionResult Index()
        {
            var integranteEquipo = db.IntegranteEquipo.Include(i => i.IdeaDeNegocio);
            return View(integranteEquipo.ToList());
        }

        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IntegranteEquipo integranteEquipo = db.IntegranteEquipo.Find(id);
            if (integranteEquipo == null)
            {
                return HttpNotFound();
            }
            return View(integranteEquipo);
        }

        
        public ActionResult Create()
        {
            ViewBag.IdeaDeNegocioID = new SelectList(db.IdeaDeNegocio, "ID", "Nombre");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,IdeaDeNegocioID,Identificacion,Nombre,Apellido,Rol,Email")] IntegranteEquipo integranteEquipo)
        {
            if (ModelState.IsValid)
            {
                db.IntegranteEquipo.Add(integranteEquipo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdeaDeNegocioID = new SelectList(db.IdeaDeNegocio, "ID", "Nombre", integranteEquipo.IdeaDeNegocioID);
            return View(integranteEquipo);
        }


        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IntegranteEquipo integranteEquipo = db.IntegranteEquipo.Find(id);
            if (integranteEquipo == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdeaDeNegocioID = new SelectList(db.IdeaDeNegocio, "ID", "Nombre", integranteEquipo.IdeaDeNegocioID);
            return View(integranteEquipo);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,IdeaDeNegocioID,Identificacion,Nombre,Apellido,Rol,Email")] IntegranteEquipo integranteEquipo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(integranteEquipo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdeaDeNegocioID = new SelectList(db.IdeaDeNegocio, "ID", "Nombre", integranteEquipo.IdeaDeNegocioID);
            return View(integranteEquipo);
        }

        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IntegranteEquipo integranteEquipo = db.IntegranteEquipo.Find(id);
            if (integranteEquipo == null)
            {
                return HttpNotFound();
            }
            return View(integranteEquipo);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IntegranteEquipo integranteEquipo = db.IntegranteEquipo.Find(id);
            db.IntegranteEquipo.Remove(integranteEquipo);
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
