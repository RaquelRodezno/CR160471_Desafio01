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
    public class tipocuentabancariasController : Controller
    {
        private banco db = new banco();

        // GET: tipocuentabancarias
        public ActionResult Index()
        {
            return View(db.tipocuentabancaria.ToList());
        }

        // GET: tipocuentabancarias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipocuentabancaria tipocuentabancaria = db.tipocuentabancaria.Find(id);
            if (tipocuentabancaria == null)
            {
                return HttpNotFound();
            }
            return View(tipocuentabancaria);
        }

        // GET: tipocuentabancarias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tipocuentabancarias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,tipocuenta,activo")] tipocuentabancaria tipocuentabancaria)
        {
            if (ModelState.IsValid)
            {
                db.tipocuentabancaria.Add(tipocuentabancaria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipocuentabancaria);
        }

        // GET: tipocuentabancarias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipocuentabancaria tipocuentabancaria = db.tipocuentabancaria.Find(id);
            if (tipocuentabancaria == null)
            {
                return HttpNotFound();
            }
            return View(tipocuentabancaria);
        }

        // POST: tipocuentabancarias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,tipocuenta,activo")] tipocuentabancaria tipocuentabancaria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipocuentabancaria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipocuentabancaria);
        }

        // GET: tipocuentabancarias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipocuentabancaria tipocuentabancaria = db.tipocuentabancaria.Find(id);
            if (tipocuentabancaria == null)
            {
                return HttpNotFound();
            }
            return View(tipocuentabancaria);
        }

        // POST: tipocuentabancarias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tipocuentabancaria tipocuentabancaria = db.tipocuentabancaria.Find(id);
            db.tipocuentabancaria.Remove(tipocuentabancaria);
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
