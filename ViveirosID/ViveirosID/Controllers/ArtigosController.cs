using Microsoft.AspNet.Identity;
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

namespace ViveirosID.Controllers {
    public class ArtigosController : Controller {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Artigoes
        public ActionResult Index() {
            var artigo = db.Artigo.Include(a => a.Categoria);
            return View(artigo.ToList());
        }

        // GET: Artigoes/Details/5
        public ActionResult Details(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artigos artigo = db.Artigo.Find(id);
            if (artigo == null) {
                return HttpNotFound();
            }
            return View(artigo);
        }

        // GET: Artigoes/Create
        public ActionResult Create() {
            ViewBag.CategoriaFK = new SelectList(db.Categoria, "CategoriaID", "tipo");
            return View();
        }

        // POST: Artigoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArtigoID,nome,nometecncico,disponibilidade,descricao,plantacaoComeca,plantacaoAcaba,peso,crescimento,transplantacaoComeca,transplantacaoAcaba,Luz,Rega,floracaoComeca,floracaoAcaba,CategoriaFK")] Artigos artigo) {
            if (ModelState.IsValid) {
                db.Artigo.Add(artigo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaFK = new SelectList(db.Categoria, "CategoriaID", "tipo", artigo.CategoriaFK);
            return View(artigo);
        }

        // GET: Artigoes/Edit/5
        public ActionResult Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artigos artigo = db.Artigo.Find(id);
            if (artigo == null) {
                return HttpNotFound();
            }
            ViewBag.CategoriaFK = new SelectList(db.Categoria, "CategoriaID", "tipo", artigo.CategoriaFK);
            return View(artigo);
        }

        // POST: Artigoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArtigoID,nome,nometecnico,disponibilidade,descricao,plantacaoComeca,plantacaoAcaba,peso,crescimento,Luz,Rega,CategoriaFK")] Artigos artigo) {
            if (ModelState.IsValid) {
                db.Entry(artigo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaFK = new SelectList(db.Categoria, "CategoriaID", "tipo", artigo.CategoriaFK);
            return View(artigo);
        }

        // GET: Artigoes/Delete/5
        public ActionResult Delete(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artigos artigo = db.Artigo.Find(id);
            if (artigo == null) {
                return HttpNotFound();
            }
            return View(artigo);
        }

        // POST: Artigoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            Artigos artigo = db.Artigo.Find(id);
            db.Artigo.Remove(artigo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        public ActionResult Adiciona(int? id) {

            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Artigos artigo = db.Artigo.Find(id);

            if (artigo == null) {
                return HttpNotFound();
            }

            // determina o user ID do utilizador asp net numa string
            //
            string userAspNetID = User.Identity.GetUserId();

            // determina o ID do utilizador parte da base de dados Viveiros num inteiro
            //
            int userID = (from umUtilizador in db.Utilizador
                          where umUtilizador.IDaspuser == userAspNetID
                          select umUtilizador.UtilizadorID).FirstOrDefault();

            // determina o ID do carrinho associado ao utilizador da bd Viveiros
            //
            int carID = (from umUtilizador in db.Utilizador
                         where umUtilizador.CarrinhoFK == userID
                         select umUtilizador.CarrinhoFK).FirstOrDefault();

            // pesquisa se existe uma correspondencia para carrinho_artigos para o artigo de ID == id
            //
            int car_artID = (from umcar_art in db.Carrinho_Artigos
                             where umcar_art.CarrinhoFK == carID && umcar_art.ArtigoFK == id
                             select umcar_art.ID).FirstOrDefault();

            // se não existe uma correspondencia para o ID == id de carrinho_artigo cria um carrinho_artigo com 1 produto de ID == id
            // se existe uma correspondencia para um carrinho_artigo para o porduto de ID == id aumenta a quantidade em 1
            //
            if (car_artID == 0) {
                CarrinhoArtigo carrinho_artigos = new CarrinhoArtigo();
                carrinho_artigos.CarrinhoFK = carID;
                carrinho_artigos.ArtigoFK = (int)id;
                carrinho_artigos.quantidade = 1;

                db.Carrinho_Artigos.Add(carrinho_artigos);
                db.SaveChanges();

            } else {
                CarrinhoArtigo carrinho_artigos = db.Carrinho_Artigos.Find(car_artID);
                carrinho_artigos.quantidade = carrinho_artigos.quantidade + 1;

                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
