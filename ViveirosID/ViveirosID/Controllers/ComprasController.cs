using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Viveiros.Models;
using ViveirosID.Models;

namespace Viveiros.Controllers {
    public class ComprasController : Controller {

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Compras
        public ActionResult Index() {
            return View(db.Compra.ToList());
        }

        // GET: Compras/Details/5
        public ActionResult Details(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compras compra = db.Compra.Find(id);
            if (compra == null) {
                return HttpNotFound();
            }
            return View(compra);
        }

        // GET: Compras/Create
        public ActionResult Create() {
            return View();
        }

        // POST: Compras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompraID,metodoentrega,metodopagamento,estado,data,precototal")] Compras compra) {
            if (ModelState.IsValid) {
                db.Compra.Add(compra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(compra);
        }

        // GET: Compras/Edit/5
        public ActionResult Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compras compra = db.Compra.Find(id);
            if (compra == null) {
                return HttpNotFound();
            }
            return View(compra);
        }

        // POST: Compras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompraID,metodoentrega,metodopagamento,estado,data,precototal")] Compras compra) {
            if (ModelState.IsValid) {
                db.Entry(compra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(compra);
        }

        // GET: Compras/Delete/5
        public ActionResult Delete(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compras compra = db.Compra.Find(id);
            if (compra == null) {
                return HttpNotFound();
            }
            return View(compra);
        }

        // POST: Compras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            Compras compra = db.Compra.Find(id);
            db.Compra.Remove(compra);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
