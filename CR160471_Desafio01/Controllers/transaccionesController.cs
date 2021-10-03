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
    public class transaccionesController : Controller
    {
        private banco db = new banco();

        // GET: transacciones
        public ActionResult Index()
        {
            var transacciones = db.transacciones.Include(t => t.cuentabancaria).Include(t => t.tipotransaccion);
            return View(transacciones.ToList());
        }

        // GET: transacciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            transacciones transacciones = db.transacciones.Find(id);
            if (transacciones == null)
            {
                return HttpNotFound();
            }
            return View(transacciones);
        }

        // GET: transacciones/Create
        public ActionResult Create()
        {
            ViewBag.idcuentabancaria = new SelectList(db.cuentabancaria, "id", "modena");
            ViewBag.tipotrans = new SelectList(db.tipotransaccion, "id", "tipotransacciones");
            return View();
        }

        // POST: transacciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,monto,estado,fechatransaccion,fechaaplicacion,tipotrans,idcuentabancaria")] transacciones transacciones)
        {
            if (ModelState.IsValid)
            {
                db.transacciones.Add(transacciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idcuentabancaria = new SelectList(db.cuentabancaria, "id", "modena", transacciones.idcuentabancaria);
            ViewBag.tipotrans = new SelectList(db.tipotransaccion, "id", "tipotransacciones", transacciones.tipotrans);
            return View(transacciones);
        }

        // GET: transacciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            transacciones transacciones = db.transacciones.Find(id);
            if (transacciones == null)
            {
                return HttpNotFound();
            }
            ViewBag.idcuentabancaria = new SelectList(db.cuentabancaria, "id", "modena", transacciones.idcuentabancaria);
            ViewBag.tipotrans = new SelectList(db.tipotransaccion, "id", "tipotransacciones", transacciones.tipotrans);
            return View(transacciones);
        }

        // POST: transacciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,monto,estado,fechatransaccion,fechaaplicacion,tipotrans,idcuentabancaria")] transacciones transacciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transacciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idcuentabancaria = new SelectList(db.cuentabancaria, "id", "modena", transacciones.idcuentabancaria);
            ViewBag.tipotrans = new SelectList(db.tipotransaccion, "id", "tipotransacciones", transacciones.tipotrans);
            return View(transacciones);
        }

        // GET: transacciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            transacciones transacciones = db.transacciones.Find(id);
            if (transacciones == null)
            {
                return HttpNotFound();
            }
            return View(transacciones);
        }

        // POST: transacciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            transacciones transacciones = db.transacciones.Find(id);
            db.transacciones.Remove(transacciones);
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
