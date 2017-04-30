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
    public class CarrinhosController : Controller {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Carrinhoes
        [Authorize]
        public ActionResult Index() {
            // determina o user ID do utilizador asp net numa string
            //
            string userAspNetID = User.Identity.GetUserId();

            // determina o ID do utilizador parte da base de dados Viveiros num inteiro
            //
            int userID = (from umUtilizador in db.Utilizador
                          where umUtilizador.IDaspuser == userAspNetID
                          select umUtilizador.UtilizadorID).FirstOrDefault();

            // determina o ID do carrinho associado ao userID
            //
            int carID = (from umCarrinho in db.Carrinho
                         where umCarrinho.UtilizadorFK == userID
                         select umCarrinho.CarrinhoID).FirstOrDefault();



            var listaArtigosNoCarrinho = (from car_art in db.Carrinho_Artigos
                                          from art in db.Artigo
                                          where car_art.ArtigoFK == art.ArtigoID && car_art.CarrinhoFK == carID
                                          select new ListaArtigosCarrinhoViewModel() {
                                              ArtigoID = art.ArtigoID,
                                              nome = art.nome,
                                              quantidade = car_art.quantidade
                                          });

            return View(listaArtigosNoCarrinho);
        }

        [Authorize]
        public ActionResult ConcluirCompra() {

            // determina o user ID do utilizador asp net numa string
            //
            string userAspNetID = User.Identity.GetUserId();

            // determina o ID do utilizador parte da base de dados Viveiros num inteiro
            //
            int userID = (from umUtilizador in db.Utilizador
                          where umUtilizador.IDaspuser == userAspNetID
                          select umUtilizador.UtilizadorID).FirstOrDefault();

            
            // determina o ID do carrinho associado ao userID
            //
            int carID = (from umCarrinho in db.Carrinho
                         where umCarrinho.UtilizadorFK == userID
                         select umCarrinho.CarrinhoID).FirstOrDefault();

            return null;
        }

        // GET: Carrinhoes/Details/5
        [Authorize]
        public ActionResult Details(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carrinhos carrinho = db.Carrinho.Find(id);
            if (carrinho == null) {
                return HttpNotFound();
            }
            return View(carrinho);
        }

        // GET: Carrinhoes/Create
        [Authorize(Roles = "Administrador")]
        public ActionResult Create() {
            ViewBag.UtilizadorFK = new SelectList(db.Utilizador, "UtilizadorID", "nome");
            return View();
        }

        // POST: Carrinhoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CarrinhoID,preçototal,ultimaAlteracao,peso,UtilizadorFK")] Carrinhos carrinho) {
            if (ModelState.IsValid) {
                db.Carrinho.Add(carrinho);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UtilizadorFK = new SelectList(db.Utilizador, "UtilizadorID", "nome", carrinho.UtilizadorFK);
            return View(carrinho);
        }

        // GET: Carrinhoes/Edit/5
        [Authorize(Roles = "Administador")]
        public ActionResult Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carrinhos carrinho = db.Carrinho.Find(id);
            if (carrinho == null) {
                return HttpNotFound();
            }
            ViewBag.UtilizadorFK = new SelectList(db.Utilizador, "UtilizadorID", "nome", carrinho.UtilizadorFK);
            return View(carrinho);
        }

        // POST: Carrinhoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CarrinhoID,preçototal,ultimaAlteracao,peso,UtilizadorFK")] Carrinhos carrinho) {
            if (ModelState.IsValid) {
                db.Entry(carrinho).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UtilizadorFK = new SelectList(db.Utilizador, "UtilizadorID", "nome", carrinho.UtilizadorFK);
            return View(carrinho);
        }

        // GET: Carrinhoes/Delete/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Delete(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carrinhos carrinho = db.Carrinho.Find(id);
            if (carrinho == null) {
                return HttpNotFound();
            }
            return View(carrinho);
        }

        // POST: Carrinhoes/Delete/5
        [Authorize(Roles = "Administrador")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            Carrinhos carrinho = db.Carrinho.Find(id);
            db.Carrinho.Remove(carrinho);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult Tranferencia(string trans) {
            if (trans == "transferencia") {

                // Determina o Asp Net ID do utilizador corrente
                //
                var aspnetuser = User.Identity.GetUserId();

                // Determina o Utilizador corrente atraves do aspnetuser
                //
                var utilizadorcorrente = (from umUtilizador in db.Utilizador
                                          where umUtilizador.IDaspuser == aspnetuser
                                          select umUtilizador).FirstOrDefault();

                var userID = utilizadorcorrente.UtilizadorID;
                // Determina o Carrinho ID do utilizador corrente
                //
                var carID = (from umCarrinho in db.Carrinho
                             where umCarrinho.UtilizadorFK == utilizadorcorrente.UtilizadorID
                             select umCarrinho).FirstOrDefault().CarrinhoID;

                // Cria uma nova compra para o presente carrinho que ira ser encerrado
                //
                Compras compra = new Compras();
                compra.data = DateTime.Now;
                compra.estado = "Tranferencia a ser confirmada";
                compra.metodoentrega = "A Definir";

                db.Compra.Add(compra);
                // Faz gravação aqui para poder recolher o ID do elemento compra
                //
                db.SaveChanges();

                // Determina o ID da Compra presente no sentido de preencher a tabela Compra_Artigos
                //
                int compraID = compra.CompraID;

                // Com ID atribuido a esta compra "compraID" cria-se agora uma tabela Utilizador_Compra
                //
                UtilizadorCompra utilizador_compra = new UtilizadorCompra();
                utilizador_compra.CompraFK = compraID;
                utilizador_compra.UtilizadorFK = userID;
                utilizador_compra.Utilizador = (from umUtilizador in db.Utilizador
                                                where umUtilizador.UtilizadorID == userID
                                                select umUtilizador).FirstOrDefault();
                utilizador_compra.Compra = compra;

                // Gravam-se os dados na base de dados
                //
                db.Utilizador_Compra.Add(utilizador_compra);
                db.SaveChanges();
                
                // determina a lista de artigos que estão no carrinho até ao presente momento
                // no momento de declaracao do lista_carrinho_artigos o metodo ToList
                // evita uma exececao no comando a baixo por o DataReader estar aberto
                //
                var lista_carrinho_artigos = (from car_art in db.Carrinho_Artigos
                                              from art in db.Artigo
                                              where car_art.ArtigoFK == art.ArtigoID && car_art.CarrinhoFK == carID
                                              select art).ToList();

                int precototal = 0;

                foreach (Artigos artigo in lista_carrinho_artigos) {

                    // Esclarece o ArtigoID para evitar usos artigo.ArtigoID
                    //
                    int artID = artigo.ArtigoID;

                    CompraArtigo compra_artigo = new CompraArtigo();
                    compra_artigo.ArtigoFK = artigo.ArtigoID;
                    compra_artigo.CompraFK = compraID;
                    compra_artigo.preço = artigo.preço;

                    db.Compra_Artigos.Add(compra_artigo);
                    db.SaveChanges();

                    // Determina a tabela correspondente ao relacionamento Carrinho_Artigo
                    // usando o carID e artID
                    // no momento de declaracao do lista_carrinho_artigos o metodo ToList
                    // evita uma exececao no comando a baixo por o DataReader estar aberto
                    //
                    CarrinhoArtigo carrinho_artigo = (from umCarrinho_Artigo in db.Carrinho_Artigos
                                                      where umCarrinho_Artigo.CarrinhoFK == carID && umCarrinho_Artigo.ArtigoFK == artID
                                                      select umCarrinho_Artigo).FirstOrDefault();

                    // Elimina a referencia a carrinho_artigo para a presente carID e artID
                    //
                    db.Carrinho_Artigos.Remove(carrinho_artigo);

                    // Regista as alterações de criacao de compra_artigo e remocao de carrinho_artigo
                    //
                    db.SaveChanges();
                }
            }

            return null;
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}