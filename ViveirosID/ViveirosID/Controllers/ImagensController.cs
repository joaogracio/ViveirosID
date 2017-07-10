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
        public ActionResult Create([Bind(Include = "descricao,ArtigoFK")] Imagens imagens, HttpPostedFileBase file)
        {
            // Aqui vejo se o modelo é válido, se a imagem é nula se tem conteudo e esse conteudo e inferior a 4 MB se o conteudo da imagem é do tipo jpeg, png ou gif 
            //
            if (ModelState.IsValid && file != null && file.ContentLength > 0 && file.ContentLength <= 4194304 && (file.ContentType == "image/jpeg" || file.ContentType == "image/png" || file.ContentType == "image/gif" && file.ContentType == "image/bmp")) 
            {
                // Se a imagem passou no filtro de cima significa que esta imagem é viavel
                // A imagem vai agora ser guardada temporariamente sem o seu nome final
                // por forma a ser guardada mais tarde com o nome definitivo
                //

                // Recolhe o nome do artigo sobre o qual se vai trabalhar
                //
                string artigo_nome = (from umArtigo in db.Artigo
                                      where umArtigo.ArtigoID == imagens.ArtigoFK
                                      select umArtigo).FirstOrDefault().nome;

                // Pesquisas de todos os ficheiros comecados pelo nome do artigo em questao
                //
                string[] directorias = Directory.GetFiles(@"D:\Joao\Informatica\PSI\ViveirosID\ViveirosID\ViveirosID\Images\", artigo_nome + "*");

                var proxima_imagem = 1;

                // Ve qual o numero a aplicar a imagem que vai ficar registada
                //
                if (directorias.Length > 0) {
                    proxima_imagem = directorias.Length + 1;
                }

                var split_content_type = file.ContentType.Split('/');

                var img_tipo = "." + split_content_type[1];

                // Directorio que pretendo para guardar a imagem
                //
                string directorio = "\\Images\\" + (artigo_nome + "_" + proxima_imagem + img_tipo);

                try {
                    file.SaveAs(directorio);
                    ViewBag.Message = "File uploaded successfully";
                } catch (Exception ex) {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }

                // Determina o tipo de imagem de que se trata
                //
                Image img = System.Drawing.Image.FromFile(directorio);
                int largura = img.Width;
                int altura = img.Height;

                var tipo = "pequeno";

                if (largura >= 800 && altura >= 600) {
                    tipo = "medio";
                } else if (largura >= 1024 && altura >= 768) {
                    tipo = "grande";
                }

                imagens.nome = artigo_nome;
                imagens.tipo = tipo;
                imagens.directorio = directorio;
                db.Imagem.Add(imagens);
                db.SaveChanges();
            }


            //ViewBag.ArtigoFK = new SelectList(db.Artigo.ToList(), "ArtigoID", "nome");

            ViewData["ArtigoFK"] = new SelectList(db.Artigo.ToList(), "ArtigoID", "nome");

            return View();
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
