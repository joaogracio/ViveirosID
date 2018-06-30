using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
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
        [AllowAnonymous]
        public ActionResult Index()
        {
            var imagem = db.Imagem.Include(i => i.Artigo);
            return View(imagem.ToList());
        }

        // GET: Imagens/Details/5
        [AllowAnonymous]
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
        [Authorize(Roles = "Administrador,Profissonal")]
        public ActionResult Create()
        {
            ViewBag.ArtigoFK = new SelectList(db.Artigo, "ArtigoID", "Nome");
            ViewData["ArtigoFK"] = new SelectList(db.Artigo.ToList(), "ArtigoID", "Nome");
            return View();
        }

        // POST: Imagens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrador,Profissonal")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "descricao,ArtigoFK")] Imagens imagens, HttpPostedFileBase file)
        {
            // Aqui vejo se o modelo é válido, se a imagem é nula se tem conteudo e esse conteudo e inferior a 4 MB se o conteudo da imagem é do Tipo jpeg, png ou gif 
            //
            if (ModelState.IsValid && file != null && file.ContentLength > 0 && file.ContentLength <= 4194304 && (file.ContentType == "image/jpeg" || file.ContentType == "image/png" || file.ContentType == "image/gif" && file.ContentType == "image/bmp")) 
            {
                // Se a imagem passou no filtro de cima significa que esta imagem é viavel
                // A imagem vai agora ser guardada temporariamente sem o seu Nome final
                // por forma a ser guardada mais tarde com o Nome definitivo
                //

                // Recolhe o Nome do artigo sobre o qual se vai trabalhar
                //
                var last_art = (from umaImg in db.Imagem
                                where umaImg.ArtigoFK == imagens.ArtigoFK
                                select umaImg);

                var Tipo_conteudo = file.ContentType.Split('/');

                // Directorio que pretendo para guardar a imagem
                //
                string Directorio = "~\\Images\\" + (last_art.FirstOrDefault().Nome + "_" + (last_art.Count()+1) + "." + Tipo_conteudo[1]);
                try {
                    file.SaveAs(Server.MapPath(Directorio));
                    ViewBag.Message = "File uploaded successfully";
                } catch (Exception ex) {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                    return View();
                }

                // Determina o Tipo de imagem de que se trata
                //
                Image img = System.Drawing.Image.FromFile(Server.MapPath(Directorio));
                int largura = img.Width;
                int altura = img.Height;

                var Tipo = "pequeno";

                if (largura >= 800 && altura >= 600) {
                    Tipo = "medio";
                } else if (largura >= 1024 && altura >= 768) {
                    Tipo = "grande";
                }

                imagens.Nome = last_art.FirstOrDefault().Nome;
                imagens.Tipo = Tipo;
                imagens.Directorio = last_art.FirstOrDefault().Nome + "_" + (last_art.Count() + 1) + "." + Tipo_conteudo[1];
                db.Imagem.Add(imagens);
                db.SaveChanges();
            }


            //ViewBag.ArtigoFK = new SelectList(db.Artigo.ToList(), "ArtigoID", "Nome");

            ViewData["ArtigoFK"] = new SelectList(db.Artigo.ToList(), "ArtigoID", "Nome");

            return RedirectToAction("Index");
        }

        // GET: Imagens/Edit/5
        [Authorize(Roles = "Administrador,Profissonal")]
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
            ViewBag.ArtigoFK = new SelectList(db.Artigo, "ArtigoID", "Nome", imagens.ArtigoFK);
            return View(imagens);
        }

        // POST: Imagens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrador,Profissonal")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ImagemID,Nome,Directorio,descricao,Tipo,ArtigoFK")] Imagens imagens)
        {
            if (ModelState.IsValid)
            {
                db.Entry(imagens).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArtigoFK = new SelectList(db.Artigo, "ArtigoID", "Nome", imagens.ArtigoFK);
            return View(imagens);
        }

        // GET: Imagens/Delete/5
        [Authorize(Roles = "Administrador")]
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
        [Authorize(Roles = "Administrador")]
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
