using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mvc.Models;

namespace mvc.Controllers
{
    public class regionesController : Controller
    {
        private contextodb db = new contextodb();

        // GET: regiones
        public ActionResult Index()
        {
            return View(db.regiones.ToList());
        }

        // GET: regiones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            regiones regiones = db.regiones.Find(id);
            if (regiones == null)
            {
                return HttpNotFound();
            }
            return View(regiones);
        }

        // GET: regiones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: regiones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_regiones,codigo,nombre")] regiones regiones)
        {
            if (ModelState.IsValid)
            {
                db.regiones.Add(regiones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(regiones);
        }

        // GET: regiones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            regiones regiones = db.regiones.Find(id);
            if (regiones == null)
            {
                return HttpNotFound();
            }
            municipios activos;

           
            ViewBag.id_municipios = db.municipios;
            return View(regiones);
        }

        // POST: regiones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_regiones,codigo,nombre")] regiones regiones)
        {


           
            if (ModelState.IsValid)
            {
                db.Entry(regiones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(regiones);
        }

        // GET: regiones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            regiones regiones = db.regiones.Find(id);
            if (regiones == null)
            {
                return HttpNotFound();
            }
            return View(regiones);
        }

        // POST: regiones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            regiones regiones = db.regiones.Find(id);
            db.regiones.Remove(regiones);
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
