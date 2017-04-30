using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ViveirosID.Models;

namespace ViveirosID.Controllers
{
    public class ImagensController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        
        // GET: Imagens
        public ActionResult Index()
        {
            var imagem = db.Imagem.Include(i => i.Artigo);
            return View(imagem.ToList());
        }

        // GET: Imagens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Imagens imagens = db.Imagem.Find(id);
            if (imagens == null)
            {
                return HttpNotFound();
            }
            return View(imagens);
        }

        // GET: Imagens/Create
        public ActionResult Create()
        {
            ViewBag.ArtigoFK = new SelectList(db.Artigo, "ArtigoID", "nome");
            ViewData["ArtigoFK"] = new SelectList(db.Artigo.ToList(), "ArtigoID", "nome");
            return View();
        }

        // POST: Imagens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nome,descricao,tipo,ArtigoFK")] Imagens imagens, HttpPostedFileBase file)
        {
            // Aqui vejo se o modelo é válido 
            //
            if (ModelState.IsValid) 
            {
                imagens.directorio = Path.Combine(Server.MapPath("~/Images"),Path.GetFileName(file.FileName));
                db.Imagem.Add(imagens);
                db.SaveChanges();
            }

            if (file != null && file.ContentLength > 0)
                try {
                    string path = Path.Combine(Server.MapPath("~/Images"),
                                               Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    ViewBag.Message = "File uploaded successfully";
                } catch (Exception ex) {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                } else {
                ViewBag.Message = "You have not specified a file.";
            }

            ViewBag.ArtigoFK = new SelectList(db.Artigo.ToList(), "ArtigoID", "nome");

            ViewData["ArtigoFK"] = new SelectList(db.Artigo.ToList(), "ArtigoID", "nome");

            return View();
            /*
            if (ModelState.IsValid)
            {
                db.Imagem.Add(imagens);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArtigoFK = new SelectList(db.Artigo, "ArtigoID", "nome", imagens.ArtigoFK);
            return View(imagens);
            */
        }

        // GET: Imagens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Imagens imagens = db.Imagem.Find(id);
            if (imagens == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArtigoFK = new SelectList(db.Artigo, "ArtigoID", "nome", imagens.ArtigoFK);
            return View(imagens);
        }

        // POST: Imagens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ImagemID,nome,directorio,descricao,tipo,ArtigoFK")] Imagens imagens)
        {
            if (ModelState.IsValid)
            {
                db.Entry(imagens).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArtigoFK = new SelectList(db.Artigo, "ArtigoID", "nome", imagens.ArtigoFK);
            return View(imagens);
        }

        // GET: Imagens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Imagens imagens = db.Imagem.Find(id);
            if (imagens == null)
            {
                return HttpNotFound();
            }
            return View(imagens);
        }

        // POST: Imagens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Imagens imagens = db.Imagem.Find(id);
            db.Imagem.Remove(imagens);
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
