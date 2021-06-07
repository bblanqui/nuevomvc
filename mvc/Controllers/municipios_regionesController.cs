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
    public class municipios_regionesController : Controller
    {
        private contextodb db = new contextodb();

        // GET: municipios_regiones
        public ActionResult Index()
        {
            var municipios_regiones = db.municipios_regiones.Include(m => m.municipio).Include(m => m.regiones);
            return View(municipios_regiones.ToList());
        }
        


        // GET: municipios_regiones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            municipios_regiones municipios_regiones = db.municipios_regiones.Find(id);
            if (municipios_regiones == null)
            {
                return HttpNotFound();
            }
            return View(municipios_regiones);
        }

        // GET: municipios_regiones/Create
        public ActionResult Create()
        {
            ViewBag.id_municipio = new SelectList(db.municipios, "id_municipio", "codigo");
            ViewBag.id_regiones = new SelectList(db.regiones, "id_regiones", "codigo");
            return View();
        }

        // POST: municipios_regiones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_regiones,id_municipio")] municipios_regiones municipios_regiones)
        {
            if (ModelState.IsValid)
            {
                db.municipios_regiones.Add(municipios_regiones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_municipio = new SelectList(db.municipios, "id_municipio", "codigo", municipios_regiones.id_municipio);
            ViewBag.id_regiones = new SelectList(db.regiones, "id_regiones", "codigo", municipios_regiones.id_regiones);
            return View(municipios_regiones);
        }

        // GET: municipios_regiones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            municipios_regiones municipios_regiones = db.municipios_regiones.Find(id);
            if (municipios_regiones == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_municipio = new SelectList(db.municipios, "id_municipio", "codigo", municipios_regiones.id_municipio);
            ViewBag.id_regiones = new SelectList(db.regiones, "id_regiones", "codigo", municipios_regiones.id_regiones);
            return View(municipios_regiones);
        }

        // POST: municipios_regiones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_regiones,id_municipio")] municipios_regiones municipios_regiones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(municipios_regiones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_municipio = new SelectList(db.municipios, "id_municipio", "codigo", municipios_regiones.id_municipio);
            ViewBag.id_regiones = new SelectList(db.regiones, "id_regiones", "codigo", municipios_regiones.id_regiones);
            return View(municipios_regiones);
        }

        // GET: municipios_regiones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            municipios_regiones municipios_regiones = db.municipios_regiones.Find(id);
            if (municipios_regiones == null)
            {
                return HttpNotFound();
            }
            return View(municipios_regiones);
        }

        // POST: municipios_regiones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            municipios_regiones municipios_regiones = db.municipios_regiones.Find(id);
            db.municipios_regiones.Remove(municipios_regiones);
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
