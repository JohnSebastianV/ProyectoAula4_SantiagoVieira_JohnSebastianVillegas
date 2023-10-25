using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoAula4_SantiagoVieira_JohnSebastianVillegas;
using System.Data.Entity.SqlServer;

namespace ProyectoAula4_SantiagoVieira_JohnSebastianVillegas.Controllers
{
    public class IdeaDeNegociosController : Controller
    {
        private ProyectoDeAula4JohnSebastian_SantiagoEntities db = new ProyectoDeAula4JohnSebastian_SantiagoEntities();

        // GET: IdeaDeNegocios
        public ActionResult Index()
        {
            var ideaDeNegocio = db.IdeaDeNegocio.Include(i => i.Herramienta4RI);
            return View(ideaDeNegocio.ToList());
        }

        // GET: IdeaDeNegocios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IdeaDeNegocio ideaDeNegocio = db.IdeaDeNegocio.Find(id);
            if (ideaDeNegocio == null)
            {
                return HttpNotFound();
            }
            return View(ideaDeNegocio);
        }

        // GET: IdeaDeNegocios/Create
        public ActionResult Create()
        {
            ViewBag.Herramienta4RIID = new SelectList(db.Herramienta4RI, "ID", "Nombre");
            return View();
        }

        // POST: IdeaDeNegocios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nombre,ImpactoSocialEconomico,ValorInversion,ValorInversionInfraestructura,Ingresos3Anios,Herramienta4RIID")] IdeaDeNegocio ideaDeNegocio)
        {
            if (ModelState.IsValid)
            {
                db.IdeaDeNegocio.Add(ideaDeNegocio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Herramienta4RIID = new SelectList(db.Herramienta4RI, "ID", "Nombre", ideaDeNegocio.Herramienta4RIID);
            return View(ideaDeNegocio);
        }

        // GET: IdeaDeNegocios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IdeaDeNegocio ideaDeNegocio = db.IdeaDeNegocio.Find(id);
            if (ideaDeNegocio == null)
            {
                return HttpNotFound();
            }
            ViewBag.Herramienta4RIID = new SelectList(db.Herramienta4RI, "ID", "Nombre", ideaDeNegocio.Herramienta4RIID);
            return View(ideaDeNegocio);
        }

        // POST: IdeaDeNegocios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nombre,ImpactoSocialEconomico,ValorInversion,ValorInversionInfraestructura,Ingresos3Anios,Herramienta4RIID")] IdeaDeNegocio ideaDeNegocio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ideaDeNegocio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Herramienta4RIID = new SelectList(db.Herramienta4RI, "ID", "Nombre", ideaDeNegocio.Herramienta4RIID);
            return View(ideaDeNegocio);
        }

        // GET: IdeaDeNegocios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IdeaDeNegocio ideaDeNegocio = db.IdeaDeNegocio.Find(id);
            if (ideaDeNegocio == null)
            {
                return HttpNotFound();
            }
            return View(ideaDeNegocio);
        }

        // POST: IdeaDeNegocios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IdeaDeNegocio ideaDeNegocio = db.IdeaDeNegocio.Find(id);
            db.IdeaDeNegocio.Remove(ideaDeNegocio);
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

        

        

        public ActionResult IdeaMayorIngresos()
        {
            var ideaMayorIngresos = db.IdeaDeNegocio
                .OrderByDescending(nd => nd.Ingresos3Anios)
                .FirstOrDefault();

            return View(ideaMayorIngresos);
        }

        public ActionResult IdeasMasRentables()
        {
            var ideasMasRentables = db.IdeaDeNegocio
                .OrderByDescending(nd => nd.Ingresos3Anios)
                .Take(3)
                .ToList();

            return View(ideasMasRentables);
        }

        

        public ActionResult SumaTotalIngresos()
        {
            decimal sumaIngresos = db.IdeaDeNegocio.Sum(nd => nd.Ingresos3Anios);
            ViewBag.SumaIngresos = sumaIngresos;
            return View();
        }

        public ActionResult SumaTotalInversion()
        {
            decimal sumaInversion = db.IdeaDeNegocio.Sum(nd => nd.ValorInversion);
            ViewBag.SumaInversion = sumaInversion;
            return View();
        }


        public ActionResult IdeasDesarrolloSostenible()
        {
            var ideasDesarrolloSostenible = db.IdeaDeNegocio
                .Where(nd => SqlFunctions.PatIndex("%desarrollo sostenible%", nd.ImpactoSocialEconomico) > 0)
                .ToList();
            return View(ideasDesarrolloSostenible);
        }

        public ActionResult IdeaMayorInversionInfraestructura()
        {
            var ideaMayorInversionInfraestructura = db.IdeaDeNegocio
                .OrderByDescending(nd => nd.ValorInversionInfraestructura)
                .FirstOrDefault();
            return View(ideaMayorInversionInfraestructura);
        }

        public ActionResult IdeasIngresosMayoresAlPromedio()
        {
            decimal promedioIngresos = db.IdeaDeNegocio.Average(nd => nd.Ingresos3Anios);
            var ideasMayoresAlPromedio = db.IdeaDeNegocio
                .Where(nd => nd.Ingresos3Anios > promedioIngresos)
                .ToList();
            return View(ideasMayoresAlPromedio);
        }

        public ActionResult Detalles()
        {


            return View();
        }







    }
}
