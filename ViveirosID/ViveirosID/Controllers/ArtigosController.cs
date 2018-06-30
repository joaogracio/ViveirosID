using Microsoft.AspNet.Identity;
using System;
using System.Collections;
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

        [AllowAnonymous]
        public ActionResult Index() {

            //retirado de 
            //https://forums.asp.net/t/2037073.aspx?dynamically+building+3+column+bootstrap+layout
            //ainda nao devidamente entendido
            var artigo = (from umArtigo in db.Artigo
                          select umArtigo);

            /*var imagem = (from umArtigo in artigo
                          from umaImagem in db.Imagem
                          where umArtigo.ArtigoID == umaImagem.ArtigoFK
                          select umaImagem).FirstOrDefault().descricao;*/

            // Get Post Params Here
            //var var1 = Request["Ordem"];

            return View(artigo.ToList());
        
        }

        [AllowAnonymous]
        public ActionResult Pesquisa() {

            // Prepara a lista standart de artigos para enviar para a View
            //
            var artigo = (from umArtigo in db.Artigo
                          select umArtigo).Include(a => a.Categoria);

            // Recolhe o valor mais alto de Preco e o mais baixo
            //
            ViewBag.primeiro_Preco = artigo.OrderBy(a => a.Preco).FirstOrDefault().Preco;

            ViewBag.ultimo_Preco = artigo.OrderByDescending(a => a.Preco).FirstOrDefault().Preco;

            // Recolhe o valor mais alto de Peso e o mais baixo
            //
            ViewBag.primeiro_Peso = artigo.OrderBy(a => a.Peso).FirstOrDefault().Peso;

            ViewBag.ultimo_Peso = artigo.OrderByDescending(a => a.Peso).FirstOrDefault().Peso;

            // Recolhe o valor mais alto de Crescimento e o mais baixo
            //
            ViewBag.primeiro_Crescimento = artigo.OrderBy(a => a.Crescimento).FirstOrDefault().Crescimento;

            ViewBag.ultimo_Crescimento = artigo.OrderByDescending(a => a.Crescimento).FirstOrDefault().Crescimento;

            // Recolhe o valor mais alto de Luz e o mais baixo
            //
            ViewBag.primeira_Luz = artigo.OrderBy(a => a.Luz).FirstOrDefault().Luz;

            ViewBag.Ultima_Luz = artigo.OrderByDescending(a => a.Luz).FirstOrDefault().Luz;

            // Recolhe o valor mais alto de Rega e o mais baixo
            //
            ViewBag.primeira_Rega = artigo.OrderBy(a => a.Rega).FirstOrDefault().Rega;

            ViewBag.Ultima_Rega = artigo.OrderByDescending(a => a.Rega).FirstOrDefault().Rega;

            return View(artigo.ToList());
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Pesquisa(string nome, string Peso, string Preco, string Crescimento, string Luz, string Rega) {

            // Faz uma selecao de todos os artigos
            // para usar de forma auxilar
            //
            
            var artigo = (from umArtigo in db.Artigo
                          select umArtigo);

            // Verifica e captura os valores para primeira_Luz e Ultima_Luz
            //
            var separa_Rega = new string[50];
            var primeira_Rega = 0.0;
            var Ultima_Rega = 0.0;
            if (Rega != "" && Rega.Count(x => x == ' ') == 1) {
                separa_Rega = Rega.Split(' ');
                var Rega1 = float.Parse(separa_Rega[0]);
                var Rega2 = float.Parse(separa_Rega[1]);
                if (Rega1 <= (artigo.OrderByDescending(a => a.Rega).FirstOrDefault().Rega) && Rega2 >= (artigo.OrderBy(a => a.Rega).FirstOrDefault().Rega)) {
                    primeira_Rega = Rega1;
                    Ultima_Rega = Rega2;
                } else {
                    primeira_Rega = (artigo.OrderByDescending(a => a.Rega).FirstOrDefault().Rega);
                    Ultima_Rega = (artigo.OrderBy(a => a.Rega).FirstOrDefault().Rega);
                }
            }

            // Verifica e captura os valores para primeiro_Crescimento e ultimo_Crescimento
            //
            var separa_Luz = new string[50];
            var primeira_Luz = 0.0;
            var Ultima_Luz = 0.0;
            if (Luz != "" && Luz.Count(x => x == ' ') == 1) {
                separa_Luz = Luz.Split(' ');
                var Luz1 = float.Parse(separa_Luz[0]);
                var Luz2 = float.Parse(separa_Luz[1]);
                if (Luz1 <= (artigo.OrderByDescending(a => a.Luz).FirstOrDefault().Luz) && Luz2 >= (artigo.OrderBy(a => a.Luz).FirstOrDefault().Luz)) {
                    primeira_Luz = Luz1;
                    Ultima_Luz = Luz2;
                } else {
                    primeira_Luz = (artigo.OrderByDescending(a => a.Luz).FirstOrDefault().Luz);
                    Ultima_Luz = (artigo.OrderBy(a => a.Luz).FirstOrDefault().Luz);
                }
            }

            // Verifica e captura os valores para primeiro_Crescimento e ultimo_Crescimento
            //
            var separa_Crescimento = new string[50];
            var primeiro_Crescimento = 0.0;
            var ultimo_Crescimento = 0.0;
            if (Crescimento != "" && Crescimento.Count(x => x == ' ') == 1) {
                separa_Crescimento = Crescimento.Split(' ');
                var Crescimento1 = float.Parse(separa_Crescimento[0]);
                var Crescimento2 = float.Parse(separa_Crescimento[1]);
                if (Crescimento1 <= (artigo.OrderByDescending(a => a.Crescimento).FirstOrDefault().Crescimento) && Crescimento2 >= (artigo.OrderBy(a => a.Crescimento).FirstOrDefault().Crescimento)) {
                    primeiro_Crescimento = Crescimento1;
                    ultimo_Crescimento = Crescimento2;
                } else {
                    primeiro_Crescimento = (artigo.OrderByDescending(a => a.Crescimento).FirstOrDefault().Crescimento);
                    ultimo_Crescimento = (artigo.OrderBy(a => a.Crescimento).FirstOrDefault().Crescimento);
                }
            }

            // Verifica e captura os valores para primeiro_Preco e ultimo_Preco
            //
            var separa_Preco = new string[50];
            var primeiro_Preco = 0.0;
            var ultimo_Preco = 0.0;
            if (Preco != "" && Preco.Count(x => x == ' ') == 1) {
                separa_Preco = Preco.Split(' ');
                var Preco1 = float.Parse(separa_Preco[0]);
                var Preco2 = float.Parse(separa_Preco[1]);
                if (Preco1 <= (artigo.OrderByDescending(a => a.Preco).FirstOrDefault().Preco) && Preco2 >= (artigo.OrderBy(a => a.Preco).FirstOrDefault().Preco)) {
                    primeiro_Preco = Preco1;
                    ultimo_Preco = Preco2;
                } else {
                    primeiro_Preco = (artigo.OrderByDescending(a => a.Preco).FirstOrDefault().Preco);
                    ultimo_Preco = (artigo.OrderBy(a => a.Preco).FirstOrDefault().Preco);
                }
            }

            // Verifica e captura os valores para primeiro_Peso e ultimo_Peso
            //
            var separa_Peso = new string[50];
            var primeiro_Peso = 0.0;
            var ultimo_Peso = 0.0;
            if (Peso != "" && Peso.Count(x => x == ' ') == 1) {
                separa_Peso = Peso.Split(' ');
                var Peso1 = float.Parse(separa_Peso[0]);
                var Peso2 = float.Parse(separa_Peso[1]);
                if (Peso1 <= (artigo.OrderByDescending(a => a.Peso).FirstOrDefault().Peso) && Peso2 >= (artigo.OrderBy(a => a.Peso).FirstOrDefault().Peso)) {
                    primeiro_Peso = Peso1;
                    ultimo_Peso = Peso2;
                } else {
                    primeiro_Peso = (artigo.OrderByDescending(a => a.Peso).FirstOrDefault().Peso);
                    ultimo_Peso = (artigo.OrderBy(a => a.Peso).FirstOrDefault().Peso);
                }
            }

            // Faz uma pesquisa da palavra a encontrar pesquisa em cada um dos artigos se existe uma correspondencia para nome
            //
            if (nome != "") {
                artigo = artigo.Where(a => a.Nome.Contains(nome) || a.Nometecnico.Contains(nome) || a.Descricao.Contains(nome));
                /*artigo = artigo.Concat(artigo.Where(a => a.nometecnico.Contains(nome)));
                artigo = artigo.Concat(artigo.Where(a => a.descricao.Contains(nome)));*/
                
            }

            // Implementa dois filtros para Peso
            //
            artigo = artigo.Where(a => a.Peso >= primeiro_Peso);
            artigo = artigo.Where(a => a.Peso <= ultimo_Peso);

            // Implementa dois filtros para Preco
            //
            artigo = artigo.Where(a => a.Preco >= primeiro_Preco);
            artigo = artigo.Where(a => a.Preco <= ultimo_Preco);

            // Implementa dois filtros para Crescimento
            //
            artigo = artigo.Where(a => a.Crescimento >= primeiro_Crescimento);
            artigo = artigo.Where(a => a.Crescimento <= ultimo_Crescimento);

            // Implementa dois filtros para Rega
            //
            artigo = artigo.Where(a => a.Rega >= primeira_Rega);
            artigo = artigo.Where(a => a.Crescimento <= Ultima_Rega);

            // Implementa dois filtros para Luz
            //
            artigo = artigo.Where(a => a.Luz >= primeira_Luz);
            artigo = artigo.Where(a => a.Luz <= Ultima_Luz);

            var artigos = (from umArtigo in db.Artigo
                          select umArtigo);
            // Recolhe o valor mais alto de Preco e o mais baixo
            //
            ViewBag.primeiro_Preco = artigos.OrderBy(a => a.Preco).FirstOrDefault().Preco;

            ViewBag.ultimo_Preco = artigos.OrderByDescending(a => a.Preco).FirstOrDefault().Preco;

            // Recolhe o valor mais alto de Peso e o mais baixo
            //
            ViewBag.primeiro_Peso = artigos.OrderBy(a => a.Peso).FirstOrDefault().Peso;

            ViewBag.ultimo_Peso = artigos.OrderByDescending(a => a.Peso).FirstOrDefault().Peso;

            // Recolhe o valor de Crescimento mais baixo e o mais elevado
            //
            ViewBag.primeiro_Crescimento = artigos.OrderBy(a => a.Crescimento).FirstOrDefault().Crescimento;

            ViewBag.ultimo_Crescimento = artigos.OrderByDescending(a => a.Crescimento).FirstOrDefault().Crescimento;

            // Recolhe o valor de Luz mais baixo e mais elevado
            //
            ViewBag.primeira_Luz = artigos.OrderBy(a => a.Luz).FirstOrDefault().Luz;

            ViewBag.Ultima_Luz = artigos.OrderByDescending(a => a.Luz).FirstOrDefault().Luz;

            // Recolhe o valor de Rega mais baixo e o mais elevado
            //
            ViewBag.primeira_Rega = artigos.OrderBy(a => a.Rega).FirstOrDefault().Rega;

            ViewBag.Ultima_Rega = artigos.OrderByDescending(a => a.Rega).FirstOrDefault().Rega;

            return View(artigo.ToList());
        }

        // GET: Artigoes/Details/5
        [AllowAnonymous]
        public ActionResult Details(int? id) {

            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Encontra o artigo acerca do qual se procuram os detalhes
            //
            Artigos artigo = db.Artigo.Find(id);
            if (artigo == null) {
                return HttpNotFound();
            }

            // Filtrar apenas aqueles que são clientes
            //
            var aspnetusers = (from umUtilizador in db.Utilizador
                               from umAspNetUser in db.Users
                               from umRoleID in umAspNetUser.Roles.Where(a => a.RoleId == "3")
                               where umUtilizador.IDaspuser == umAspNetUser.Id && umRoleID.UserId == umAspNetUser.Id
                               select umUtilizador);

            // Filtrar apenas as compras que sao de clientes
            //
            var comprasDeClientes = (from umaCompra in db.Compra
                                     from umUtilizador in aspnetusers
                                     where umaCompra.Utilizador.IDaspuser == umUtilizador.IDaspuser
                                     select umaCompra);

            // Faz a lista de artigos que estao a ser fortemente comprados quando
            // o "artigo" foi comprado
            var compra_artigo = (from umaCompra_Artigo in db.Compra_Artigos
                                 where umaCompra_Artigo.ArtigoFK == id
                                 select umaCompra_Artigo);

            comprasDeClientes = (from umaCompra in comprasDeClientes
                                 from umaCompraArtigo in compra_artigo
                                 where umaCompra.CompraID == umaCompraArtigo.CompraFK
                                 select umaCompra);

            // Remove todas as compras onde apenas aparece o artigo de ID = id
            // essas compras nao tem interesse nao indicam um comportamento
            // padrao dos clientes
            //
            comprasDeClientes = comprasDeClientes.Where(a => a.ListadeArtigos.Count > 1);

            // Prepara uma lista nula de artigos para adicionar os 
            // artigos a apresentar
            //
            var artigos_apresentar = (from umArtigo in db.Artigo
                                      where umArtigo.Descricao == "maluco"
                                      select umArtigo);

            // Prepara uma lista nula de CompraArtigos para listar todas 
            // as comprasArtigo onde o nosso artigo de ID = id aparece referenciado
            //
            var compra_artigos = (from umaCompraArtigos in db.Compra_Artigos
                                  where umaCompraArtigos.Preco == -1
                                  select umaCompraArtigos);

            var compra_artigos_list = new List<CompraArtigo>();

            // Compra a compra, listadeArtigos a listadeArtigos
            // coloca todos os compraArtigo em compra_artigos
            // para a seguir mediante as quantidades escolher
            // quais devem ser sugeridos
            //
            foreach (Compras elm in comprasDeClientes) {
                foreach (CompraArtigo var in elm.ListadeArtigos) {
                    CompraArtigo compra_artigo_temp = new CompraArtigo();
                    compra_artigo_temp.ArtigoFK = var.ArtigoFK;
                    compra_artigo_temp.CompraFK = var.CompraFK;
                    compra_artigo_temp.ID = var.ID;
                    compra_artigo_temp.IVA = var.IVA;
                    compra_artigo_temp.Preco = var.Preco;
                    compra_artigo_temp.Quantidade = var.Quantidade;

                    compra_artigos_list.Add(compra_artigo_temp);
                }
            }

            // Seleciona as CompraArtigo cujo ArtigoFK seja diferente do id
            // não são desejadas entradas para o produto para o qual são procurados os detalhes
            // apenas os mais procurados associados a este
            //
            compra_artigos =  compra_artigos_list.Where(a => a.ArtigoFK != 1).OrderByDescending(b => b.Quantidade).Take(3).AsQueryable<CompraArtigo>();

            foreach (CompraArtigo elm in compra_artigos) {
                var artigo_temp = (from umArtigo in db.Artigo
                                   where umArtigo.ArtigoID == elm.ArtigoFK
                                   select umArtigo);
                artigos_apresentar = artigos_apresentar.Concat(artigo_temp);
            }
            //=========================================================================

            //Seleciona uma lista de artigos da mesma categoria
            //
            var artigos_categoria = (from umArtigo in db.Artigo
                                     //from umaCategoria in db.Categoria
                                     where umArtigo.CategoriaFK == artigo.CategoriaFK 
                                     select umArtigo);

            // Seleciona a categoria a qual o artigo corresponde
            //
            var categoria = (from umaCategoria in db.Categoria
                             where artigo.CategoriaFK == umaCategoria.CategoriaID
                             select umaCategoria).FirstOrDefault();

            // Imagem ou grupo de Imagens que corresponde ao artigo
            //
            var imagem = (from umArtigo in db.Artigo
                          from umaImagem in db.Imagem
                          where umArtigo.ArtigoID == umaImagem.ArtigoFK && umaImagem.ArtigoFK == artigo.ArtigoID
                          select umaImagem);

            // Faz o Modelo para ser enviado para a View Details
            //
            var model = new ProdutoDetalhesViewModel();
            model.Artigo = artigo;
            model.Categoria = categoria;
            model.Artigos = artigos_categoria.ToList() as ICollection<Artigos>;
            model.Imagens = imagem.ToList() as ICollection<Imagens>;

            return View(model);
        }

        // GET: Artigoes/Create
        [Authorize(Roles = "Administrador,Profissional")]
        public ActionResult Create() {
            ViewBag.CategoriaFK = new SelectList(db.Categoria, "CategoriaID", "Tipo");
            return View();
        }

        // POST: Artigoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrador,Profissonal")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArtigoID,nome,nometecnico,disponibilidade,descricao,plantacaoComeca,plantacaoAcaba,Peso,Crescimento,Preco,Luz,Rega,CategoriaFK")] Artigos artigo) {
            if (ModelState.IsValid) {
                db.Artigo.Add(artigo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaFK = new SelectList(db.Categoria, "CategoriaID", "Tipo", artigo.CategoriaFK);
            return View(artigo);
        }

        // GET: Artigoes/Edit/5
        [Authorize(Roles = "Administrador,Profissonal")]
        public ActionResult Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artigos artigo = db.Artigo.Find(id);
            if (artigo == null) {
                return HttpNotFound();
            }
            ViewBag.CategoriaFK = new SelectList(db.Categoria, "CategoriaID", "Tipo", artigo.CategoriaFK);
            return View(artigo);
        }

        // POST: Artigoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrador,Profissonal")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArtigoID,nome,nometecnico,disponibilidade,descricao,plantacaoComeca,plantacaoAcaba,Peso,Crescimento,Luz,Rega,CategoriaFK")] Artigos artigo) {
            if (ModelState.IsValid) {
                db.Entry(artigo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaFK = new SelectList(db.Categoria, "CategoriaID", "Tipo", artigo.CategoriaFK);
            return View(artigo);
        }

        // GET: Artigoes/Delete/5
        [Authorize(Roles = "Administrador")]
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
        [Authorize (Roles = "Administrador")]
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

        [Authorize]
        public ActionResult Adiciona(int? id, int? id2) {

            if (id == null || id2 == null) {
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
                         where umUtilizador.UtilizadorID == userID
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
                carrinho_artigos.Quantidade = (int) id2;

                db.Carrinho_Artigos.Add(carrinho_artigos);
                db.SaveChanges();

            } else {
                CarrinhoArtigo carrinho_artigos = db.Carrinho_Artigos.Find(car_artID);
                carrinho_artigos.Quantidade = carrinho_artigos.Quantidade + (int) id2;

                db.SaveChanges();
            }

            /*if (id2.Equals("artigo")) return RedirectToAction("Index");
            else return RedirectToAction("Index", "Home");*/

            return Redirect(Request.UrlReferrer.ToString());
        }

        [Authorize]
        public ActionResult Actualiza(int? id, int? id2) {

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
            var car_artID = (from umcar_art in db.Carrinho_Artigos
                             where umcar_art.CarrinhoFK == carID && umcar_art.ArtigoFK == id
                             select umcar_art).ToList();

            car_artID.Select(c => { c.Quantidade = (int) id2; return c; }).ToList();

            return View("Index");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult MaisProcurados() {

            // determina o user ID do utilizador asp net numa string
            //
            string userAspNetID = User.Identity.GetUserId();

            // determina o ID do utilizador parte da base de dados Viveiros num inteiro
            //
            int userID = (from umUtilizador in db.Utilizador
                          where umUtilizador.IDaspuser == userAspNetID
                          select umUtilizador.UtilizadorID).FirstOrDefault();

            // Fazer uma lista de todos os elementos da tabela CompraArtigos
            // em que as CompraArtigos tem correspondecia com Compras em que o userID 
            // aparece como chave forasteira UtilizadorFK
            // 
            var artigo_comprado = (from umaCompra in db.Compra
                                   from umaCompraArtigo in db.Compra_Artigos
                                   where umaCompra.CompraID == umaCompraArtigo.CompraFK && umaCompra.UtilizadorFK == userID
                                   select umaCompraArtigo);

            var artigo = (from umArtigo in db.Artigo
                          where umArtigo.Nome == "maluco"
                          select umArtigo);

            var artigo_mais_quantidade = artigo_comprado.GroupBy(a => a.ArtigoFK)
                                            .Select(a => new { ArtigoFK = a.Key, quantidade = a.Sum(b => b.Quantidade) });

            artigo_mais_quantidade = artigo_mais_quantidade.OrderByDescending(a => a.quantidade);

            artigo_mais_quantidade = artigo_mais_quantidade.Take(5);

            //.Select(a => new {Amount = a.Sum(b => b.ArticleAmount),Name=a.ArticleName})

            // Coloca numa lista os cinco artigos mais comprados
            //
            foreach (var elm in artigo_mais_quantidade) {
                var artigo_temp = (from umArtigo in db.Artigo
                                   where umArtigo.ArtigoID == elm.ArtigoFK
                                   select umArtigo);
                artigo = artigo.Concat(artigo_temp);
            }


            artigo = artigo.GroupBy(a => a.ArtigoID).Select(y => y.FirstOrDefault()).Take(5);

            return View(artigo.ToList());
        }
    }
}
