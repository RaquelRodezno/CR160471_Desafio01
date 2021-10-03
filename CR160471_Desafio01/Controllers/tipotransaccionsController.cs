using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CR160471_Desafio01.Models;

namespace CR160471_Desafio01.Controllers
{
    public class tipotransaccionsController : Controller
    {
        private banco db = new banco();

        // GET: tipotransaccions
        public ActionResult Index()
        {
            return View(db.tipotransaccion.ToList());
        }

        // GET: tipotransaccions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipotransaccion tipotransaccion = db.tipotransaccion.Find(id);
            if (tipotransaccion == null)
            {
                return HttpNotFound();
            }
            return View(tipotransaccion);
        }

        // GET: tipotransaccions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tipotransaccions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,tipotransacciones")] tipotransaccion tipotransaccion)
        {
            if (ModelState.IsValid)
            {
                db.tipotransaccion.Add(tipotransaccion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipotransaccion);
        }

        // GET: tipotransaccions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipotransaccion tipotransaccion = db.tipotransaccion.Find(id);
            if (tipotransaccion == null)
            {
                return HttpNotFound();
            }
            return View(tipotransaccion);
        }

        // POST: tipotransaccions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,tipotransacciones")] tipotransaccion tipotransaccion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipotransaccion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipotransaccion);
        }

        // GET: tipotransaccions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipotransaccion tipotransaccion = db.tipotransaccion.Find(id);
            if (tipotransaccion == null)
            {
                return HttpNotFound();
            }
            return View(tipotransaccion);
        }

        // POST: tipotransaccions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tipotransaccion tipotransaccion = db.tipotransaccion.Find(id);
            db.tipotransaccion.Remove(tipotransaccion);
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
