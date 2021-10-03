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
    public class cuentabancariasController : Controller
    {
        private banco db = new banco();

        // GET: cuentabancarias
        public ActionResult Index()
        {
            var cuentabancaria = db.cuentabancaria.Include(c => c.cliente).Include(c => c.tipocuentabancaria);
            return View(cuentabancaria.ToList());
        }

        // GET: cuentabancarias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cuentabancaria cuentabancaria = db.cuentabancaria.Find(id);
            if (cuentabancaria == null)
            {
                return HttpNotFound();
            }
            return View(cuentabancaria);
        }

        // GET: cuentabancarias/Create
        public ActionResult Create()
        {
            ViewBag.idcliente = new SelectList(db.cliente, "id", "nombres");
            ViewBag.tipo = new SelectList(db.tipocuentabancaria, "id", "tipocuenta");
            return View();
        }

        // POST: cuentabancarias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,idcliente,modena,tipo")] cuentabancaria cuentabancaria)
        {
            if (ModelState.IsValid)
            {
                db.cuentabancaria.Add(cuentabancaria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idcliente = new SelectList(db.cliente, "id", "nombres", cuentabancaria.idcliente);
            ViewBag.tipo = new SelectList(db.tipocuentabancaria, "id", "tipocuenta", cuentabancaria.tipo);
            return View(cuentabancaria);
        }

        // GET: cuentabancarias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cuentabancaria cuentabancaria = db.cuentabancaria.Find(id);
            if (cuentabancaria == null)
            {
                return HttpNotFound();
            }
            ViewBag.idcliente = new SelectList(db.cliente, "id", "nombres", cuentabancaria.idcliente);
            ViewBag.tipo = new SelectList(db.tipocuentabancaria, "id", "tipocuenta", cuentabancaria.tipo);
            return View(cuentabancaria);
        }

        // POST: cuentabancarias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,idcliente,modena,tipo")] cuentabancaria cuentabancaria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cuentabancaria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idcliente = new SelectList(db.cliente, "id", "nombres", cuentabancaria.idcliente);
            ViewBag.tipo = new SelectList(db.tipocuentabancaria, "id", "tipocuenta", cuentabancaria.tipo);
            return View(cuentabancaria);
        }

        // GET: cuentabancarias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cuentabancaria cuentabancaria = db.cuentabancaria.Find(id);
            if (cuentabancaria == null)
            {
                return HttpNotFound();
            }
            return View(cuentabancaria);
        }

        // POST: cuentabancarias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            cuentabancaria cuentabancaria = db.cuentabancaria.Find(id);
            db.cuentabancaria.Remove(cuentabancaria);
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
