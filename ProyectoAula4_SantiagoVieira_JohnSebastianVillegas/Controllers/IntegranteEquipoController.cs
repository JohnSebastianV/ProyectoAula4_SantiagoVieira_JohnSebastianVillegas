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

        // GET: IntegranteEquipo
        public ActionResult Index()
        {
            var integranteEquipo = db.IntegranteEquipo.Include(i => i.IdeaDeNegocio);
            return View(integranteEquipo.ToList());
        }

        // GET: IntegranteEquipo/Details/5
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

        // GET: IntegranteEquipo/Create
        public ActionResult Create()
        {
            ViewBag.IdeaDeNegocioID = new SelectList(db.IdeaDeNegocio, "ID", "Nombre");
            return View();
        }

        // POST: IntegranteEquipo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
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


        // GET: IntegranteEquipo/Edit/5
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

        // POST: IntegranteEquipo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: IntegranteEquipo/Delete/5
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

        // POST: IntegranteEquipo/Delete/5
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
