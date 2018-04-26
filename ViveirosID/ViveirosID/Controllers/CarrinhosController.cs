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
        public ActionResult Index(){
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
                         where umCarrinho.Utilizador.UtilizadorID == userID
                         select umCarrinho.CarrinhoID).FirstOrDefault();

            // Preenche os parâmetros de ListaArtigosCarrinhoViewModel
            //
            var listaArtigosNoCarrinho = (from car_art in db.Carrinho_Artigos
                                          from art in db.Artigo
                                          from catedor in db.Categoria
                                          where car_art.ArtigoFK == art.ArtigoID && car_art.CarrinhoFK == carID && catedor.CategoriaID == art.CategoriaFK 
                                          select new ListaArtigosCarrinhoViewModel() {
                                              ArtigoID = art.ArtigoID,
                                              nome = art.nome,
                                              preco = art.preco,
                                              preco_total_prd = (car_art.quantidade * art.preco),
                                              quantidade = car_art.quantidade,
                                              tipo = catedor.tipo
                                          });

            // Cria uma lista de imagens relativas a cada artigo
            //
            /*foreach (var elm in listaArtigosNoCarrinho) {
                var imagem = (from img in db.Imagem
                              where img.ArtigoFK == elm.ArtigoID
                              select img);
                listaArtigosNoCarrinho.Where(id => id.ArtigoID == elm.ArtigoID).FirstOrDefault().Imagens = imagem.ToList() as ICollection<Imagens>; 
            }*/

            return View(listaArtigosNoCarrinho);
        }

        public ActionResult MetodoDePagamento() {
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
                         where umCarrinho.Utilizador.UtilizadorID == userID
                         select umCarrinho.CarrinhoID).FirstOrDefault();



            var listaArtigosNoCarrinho = (from car_art in db.Carrinho_Artigos
                                          from art in db.Artigo
                                          where car_art.ArtigoFK == art.ArtigoID && car_art.CarrinhoFK == carID
                                          select new ListaArtigosCarrinhoViewModel()
                                          {
                                              ArtigoID = art.ArtigoID,
                                              nome = art.nome,
                                              quantidade = car_art.quantidade
                                          });

            return View("MetodoDePagamento", listaArtigosNoCarrinho);
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

            // determina o carrinho que esta a ser usado
            //
            var carrinhoNOW = (from umCarrinho in db.Carrinho
                               where umCarrinho.Utilizador.UtilizadorID == userID
                               select umCarrinho).FirstOrDefault();

            // determina o ID do carrinho associado ao userID
            //
            int carID = (from umCarrinho in db.Carrinho
                         where umCarrinho.Utilizador.UtilizadorID == userID
                         select umCarrinho.CarrinhoID).FirstOrDefault();

            // determina o ID o carrinhoArtigos associado ao carrinho 
            // presente
            Compras compra = new Compras();
            compra.data = DateTime.Now;
            
            
            // Calcula o precototal

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
        public ActionResult Create([Bind(Include = "CarrinhoID,precototal,ultimaAlteracao,peso,UtilizadorFK")] Carrinhos carrinho) {
            if (ModelState.IsValid) {
                db.Carrinho.Add(carrinho);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UtilizadorFK = new SelectList(db.Utilizador, "UtilizadorID", "nome", carrinho.Utilizador.UtilizadorID);
            return View(carrinho);
        }

        // GET: Carrinhoes/Edit/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carrinhos carrinho = db.Carrinho.Find(id);
            if (carrinho == null) {
                return HttpNotFound();
            }
            ViewBag.UtilizadorFK = new SelectList(db.Utilizador, "UtilizadorID", "nome", carrinho.Utilizador.UtilizadorID);
            return View(carrinho);
        }

        // POST: Carrinhoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CarrinhoID,precototal,ultimaAlteracao,peso,UtilizadorFK")] Carrinhos carrinho) {
            if (ModelState.IsValid) {
                db.Entry(carrinho).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UtilizadorFK = new SelectList(db.Utilizador, "UtilizadorID", "nome", carrinho.Utilizador.UtilizadorID);
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
        public ActionResult Transferencia()
        {

            return View("Transferencia", "Carrinhos");
        }

        [HttpPost]
        [Authorize]
        public ActionResult Transferencia(string trans) {
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

                // Determina o valor do trasporte
                //
                if (utilizadorcorrente.pais == "Portugal")
                {
                    utilizadorcorrente.preco_transporte = 6.0;
                }
                else {
                    utilizadorcorrente.preco_transporte = 15.0;
                }

                db.SaveChanges();
                
                // Determina o Carrinho ID do utilizador corrente
                //
                var carID = (from umCarrinho in db.Carrinho
                             where umCarrinho.Utilizador.UtilizadorID == utilizadorcorrente.UtilizadorID
                             select umCarrinho).FirstOrDefault().CarrinhoID;
                

                // determina a lista de artigos que estão no carrinho até ao presente momento
                // no momento de declaracao do lista_carrinho_artigos o metodo ToList
                // evita uma exececao no comando a baixo por o DataReader estar aberto
                //
                var lista_carrinho_artigos = (from car_art in db.Carrinho_Artigos
                                              from art in db.Artigo
                                              where car_art.ArtigoFK == art.ArtigoID && car_art.CarrinhoFK == carID
                                              select art).ToList();

                // caso a lista de carrinhos_artigos seja nula retorna para a vista de carrinho sem alterações
                //
                if (lista_carrinho_artigos.Count == 0) {
                    return View("Index");
                }

                int comprasID = 1;

                try
                {
                    comprasID = (from umaCompra in db.Compra
                                 select umaCompra.CompraID).Max() + 1;
                }
                catch (Exception ex) {
                    //comprasID = 1;
                    //A tabela de compras esta nula
                }

                // Cria uma nova compra para o presente carrinho que ira ser encerrado
                //
                Compras compra = new Compras();
                compra.data = DateTime.Now;
                compra.estado = "Tranferencia a ser confirmada";
                compra.metodoentrega = "A Definir";
                compra.UtilizadorFK = userID;
                compra.CompraID = comprasID;
                db.Compra.Add(compra);
                // Faz gravacão aqui para poder recolher o ID do elemento compra
                //
                db.SaveChanges();

                double precototal = 0;

                foreach (Artigos artigo in lista_carrinho_artigos) {

                    // Esclarece o ArtigoID para evitar usos artigo.ArtigoID
                    //
                    int artID = artigo.ArtigoID;

                    // Determina a tabela correspondente ao relacionamento Carrinho_Artigo
                    // usando o carID e artID
                    // no momento de declaracao do lista_carrinho_artigos o metodo ToList
                    // evita uma exececao no comando a baixo por o DataReader estar aberto
                    //
                    CarrinhoArtigo carrinho_artigo = (from umCarrinho_Artigo in db.Carrinho_Artigos
                                                      where umCarrinho_Artigo.CarrinhoFK == carID && umCarrinho_Artigo.ArtigoFK == artID
                                                      select umCarrinho_Artigo).FirstOrDefault();

                    CompraArtigo compra_artigo = new CompraArtigo();
                    compra_artigo.ArtigoFK = artigo.ArtigoID;
                    compra_artigo.CompraFK = compra.CompraID;
                    compra_artigo.preco = artigo.preco;
                    compra_artigo.quantidade = carrinho_artigo.quantidade;
                    precototal += (compra_artigo.preco * compra_artigo.quantidade);
                    db.Compra_Artigos.Add(compra_artigo);
                    db.SaveChanges();

                    // Elimina a referencia a carrinho_artigo para a presente carID e artID
                    //
                    db.Carrinho_Artigos.Remove(carrinho_artigo);

                    // Regista as alteracões de criacao de compra_artigo e remocao de carrinho_artigo
                    //
                    db.SaveChanges();
                }

                compra.precototal = precototal + utilizadorcorrente.preco_transporte;

                db.SaveChanges();
            }

            return RedirectToAction("Index", "Compras"); 
        }

        [Authorize]
        public ActionResult Remover(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artigos artigo = db.Artigo.Find(id);
            if (artigo == null)
            {
                return HttpNotFound();
            }

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
                         where umCarrinho.Utilizador.UtilizadorID == utilizadorcorrente.UtilizadorID
                         select umCarrinho).FirstOrDefault().CarrinhoID;
            
            // Pesquisa o Carrinho_Artigos 
            var car_art = (from umCarrinho_Artigo in db.Carrinho_Artigos
                           where umCarrinho_Artigo.CarrinhoFK == carID && umCarrinho_Artigo.ArtigoFK == id
                           select umCarrinho_Artigo).FirstOrDefault();

            // Remove da tabela Carrinhos_Artigo o Carrinho_Artigo que corresponde aquele que armazena o produto
            db.Carrinho_Artigos.Remove(car_art);

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult Actualiza(int? id, int? id2)
        {

            if (id == null || id2 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Artigos artigo = db.Artigo.Find(id);

            if (artigo == null)
            {
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
                         where umUtilizador.UtilizadorID == userID
                         select umUtilizador.CarrinhoFK).FirstOrDefault();

            // pesquisa se existe uma correspondencia para carrinho_artigos para o artigo de ID == id
            //
            // pesquisa se existe uma correspondencia para carrinho_artigos para o artigo de ID == id
            //
            int car_artID = (from umcar_art in db.Carrinho_Artigos
                             where umcar_art.CarrinhoFK == carID && umcar_art.ArtigoFK == id
                             select umcar_art.ID).FirstOrDefault();

            // se não existe uma correspondencia para o ID == id de carrinho_artigo cria um carrinho_artigo com 1 produto de ID == id
            // se existe uma correspondencia para um carrinho_artigo para o porduto de ID == id aumenta a quantidade em 1
            //
            if (car_artID == 0)
            {
                CarrinhoArtigo carrinho_artigos = new CarrinhoArtigo();
                carrinho_artigos.CarrinhoFK = carID;
                carrinho_artigos.ArtigoFK = (int)id;
                carrinho_artigos.quantidade = (int)id2;

                db.Carrinho_Artigos.Add(carrinho_artigos);
                db.SaveChanges();

            }
            else
            {
                CarrinhoArtigo carrinho_artigos = db.Carrinho_Artigos.Find(car_artID);
                carrinho_artigos.quantidade = (int)id2;

                db.SaveChanges();
            }


            var listaArtigosNoCarrinho = (from car_art in db.Carrinho_Artigos
                                          from art in db.Artigo
                                          from catedor in db.Categoria
                                          where car_art.ArtigoFK == art.ArtigoID && car_art.CarrinhoFK == carID && catedor.CategoriaID == art.CategoriaFK
                                          select new ListaArtigosCarrinhoViewModel()
                                          {
                                              ArtigoID = art.ArtigoID,
                                              nome = art.nome,
                                              preco = art.preco,
                                              preco_total_prd = (car_art.quantidade * art.preco),
                                              quantidade = car_art.quantidade,
                                              tipo = catedor.tipo
                                          });

            return View("Index", listaArtigosNoCarrinho);
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}