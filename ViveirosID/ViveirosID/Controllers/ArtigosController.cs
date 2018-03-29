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

        
        /*
        // GET: Artigoes
        public ActionResult Index(string ordem, string filtro) {

            var artigo = (from umArtigo in db.Artigo
                          select umArtigo).Include(a => a.Categoria);

            switch (filtro) {

                case "tipo":
                    if (ordem == "ascendente") {
                        artigo = artigo.OrderBy(a => a.Categoria.tipo);
                    } else if (ordem == "descendente") {
                        artigo = artigo.OrderByDescending(a => a.Categoria.tipo);
                    }
                    break;

                case "nome":
                    if (ordem == "ascendente") {
                        artigo = artigo.OrderBy(a => a.nome);
                    } else if (ordem == "descendente") {
                        artigo = artigo.OrderByDescending(a => a.nome);
                    }
                    break;

                case "nome tecnico":
                    if (ordem == "ascendente") {
                        artigo = artigo.OrderBy(a => a.nometecnico);
                    } else if (ordem == "descendente") {
                        artigo = artigo.OrderByDescending(a => a.nometecnico);
                    }
                    break;

                case "disponibilidade":
                    if (ordem == "ascendente") {
                        artigo = artigo.OrderBy(a => a.disponibilidade);
                    } else if (ordem == "descendente") {
                        artigo = artigo.OrderByDescending(a => a.disponibilidade);
                    }
                    break;

                case "descricao":
                    if (ordem == "ascendente") {
                        artigo = artigo.OrderBy(a => a.descricao.Length);
                    } else if (ordem == "descendente") {
                        artigo = artigo.OrderByDescending(a => a.descricao.Length);
                    }
                    break;

                case "plantacao comeca":
                    // Listagem de mes a mes para mediante o tipo de ordenacão 
                    // concatenar de ordem ascendente ou descendente
                    //
                    var janeiro = artigo.Where(a => a.plantacaoComeca == "Janeiro");
                    var fevereiro = artigo.Where(a => a.plantacaoComeca == "Fevereiro");
                    var marco = artigo.Where(a => a.plantacaoComeca == "Marco");
                    var abril = artigo.Where(a => a.plantacaoComeca == "Abril");
                    var maio = artigo.Where(a => a.plantacaoComeca == "Maio");
                    var junho = artigo.Where(a => a.plantacaoComeca == "Junho");
                    var julho = artigo.Where(a => a.plantacaoComeca == "Julho");
                    var agosto = artigo.Where(a => a.plantacaoComeca == "Agosto");
                    var setembro = artigo.Where(a => a.plantacaoComeca == "Setembro");
                    var outubro = artigo.Where(a => a.plantacaoComeca == "Outubro");
                    var novembro = artigo.Where(a => a.plantacaoComeca == "Novembro");
                    var dezembro = artigo.Where(a => a.plantacaoComeca == "Dezembro");

                    if (ordem == "ascendente") {
                        artigo = janeiro.Concat(fevereiro).Concat(marco).Concat(abril).Concat(maio).Concat(junho).Concat(julho).Concat(agosto).Concat(setembro).Concat(outubro).Concat(novembro).Concat(dezembro);
                    } else if (ordem == "descendente") {
                        artigo = dezembro.Concat(novembro).Concat(outubro).Concat(setembro).Concat(agosto).Concat(julho).Concat(junho).Concat(maio).Concat(abril).Concat(marco).Concat(fevereiro).Concat(janeiro);
                    }
                    break;

                case "plantacao acaba":
                    // Listagem de mes a mes para mediante o tipo de ordenacão 
                    // concatenar de ordem ascendente ou descendente
                    //
                    var janeiroA = artigo.Where(a => a.plantacaoComeca == "Janeiro");
                    var fevereiroA = artigo.Where(a => a.plantacaoComeca == "Fevereiro");
                    var marcoA = artigo.Where(a => a.plantacaoComeca == "Marco");
                    var abrilA = artigo.Where(a => a.plantacaoComeca == "Abril");
                    var maioA = artigo.Where(a => a.plantacaoComeca == "Maio");
                    var junhoA = artigo.Where(a => a.plantacaoComeca == "Junho");
                    var julhoA = artigo.Where(a => a.plantacaoComeca == "Julho");
                    var agostoA = artigo.Where(a => a.plantacaoComeca == "Agosto");
                    var setembroA = artigo.Where(a => a.plantacaoComeca == "Setembro");
                    var outubroA = artigo.Where(a => a.plantacaoComeca == "Outubro");
                    var novembroA = artigo.Where(a => a.plantacaoComeca == "Novembro");
                    var dezembroA = artigo.Where(a => a.plantacaoComeca == "Dezembro");

                    if (ordem == "ascendente") {
                        artigo = janeiroA.Concat(fevereiroA).Concat(marcoA).Concat(abrilA).Concat(maioA).Concat(junhoA).Concat(julhoA).Concat(agostoA).Concat(setembroA).Concat(outubroA).Concat(novembroA).Concat(dezembroA);
                    } else if (ordem == "descendente") {
                        artigo = dezembroA.Concat(novembroA).Concat(outubroA).Concat(setembroA).Concat(agostoA).Concat(julhoA).Concat(junhoA).Concat(maioA).Concat(abrilA).Concat(marcoA).Concat(fevereiroA).Concat(janeiroA);
                    }
                    break;

                case "peso":
                    if (ordem == "ascendente") {
                        artigo = artigo.OrderBy(a => a.peso);
                    } else if (ordem == "descendente") {
                        artigo = artigo.OrderByDescending(a => a.peso);
                    }
                    break;

                case "crescimento":

                    /*var itensiva = artigo.Where(a => a.crescimento == "Rápido");
                    var moderado = artigo.Where(a => a.crescimento == "Moderado");
                    var lento = artigo.Where(a => a.crescimento == "Lento");

                    if (ordem == "ascendente") {
                        artigo = lento.Concat(moderado).Concat(itensiva);
                    } else if (ordem == "descendente") {
                        artigo = itensiva.Concat(moderado).Concat(lento);
                    }
                    break;*/
/*
                case "luz":

                    /*var sol = artigo.Where(a => a.luz == "Sol");
                    var meiasombra = artigo.Where(a => a.luz == "Meia-Sombra");
                    var sombra = artigo.Where(a => a.luz == "Sombra");

                    if (ordem == "ascendente") {
                        artigo = sombra.Concat(meiasombra).Concat(sol);
                    } else if (ordem == "descendente") {
                        artigo = sol.Concat(meiasombra).Concat(sombra);
                    }
                    break;*/
/*
                case "rega":

                    /*var itensivaA = artigo.Where(a => a.rega == "Intensiva");
                    var regular = artigo.Where(a => a.rega == "Regular");
                    var reduzida = artigo.Where(a => a.rega == "Reduzida");

                    if (ordem == "ascendente") {
                        artigo = reduzida.Concat(regular).Concat(itensivaA);
                    } else if (ordem == "descendente") {
                        artigo = itensivaA.Concat(regular).Concat(reduzida);
                    }
                    break;*/
/*
                case "preco":
                    if (ordem == "ascendente") {
                        artigo = artigo.OrderBy(a => a.preco);
                    } else if (ordem == "descendente") {
                        artigo = artigo.OrderByDescending(a => a.preco);
                    }
                    break;
            }

            /*var artigo = (from umArtigo in db.Artigo
                       where umArtigo.disponibilidade == true
                       select umArtigo).Include(a => a.Categoria);*/

            /*if (User.Identity.IsAuthenticated == true && User.IsInRole("Administrador")) {

            }*/
   /*
            return View(artigo.ToList());
        }*/

        //[HttpPost]
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

        [Authorize]
        public ActionResult Pesquisa() {

            // Prepara a lista standart de artigos para enviar para a View
            //
            var artigo = (from umArtigo in db.Artigo
                          select umArtigo).Include(a => a.Categoria);

            // Recolhe o valor mais alto de preco e o mais baixo
            //
            ViewBag.primeiro_preco = artigo.OrderBy(a => a.preco).FirstOrDefault().preco;

            ViewBag.ultimo_preco = artigo.OrderByDescending(a => a.preco).FirstOrDefault().preco;

            // Recolhe o valor mais alto de peso e o mais baixo
            //
            ViewBag.primeiro_peso = artigo.OrderBy(a => a.peso).FirstOrDefault().peso;

            ViewBag.ultimo_peso = artigo.OrderByDescending(a => a.peso).FirstOrDefault().peso;

            // Recolhe o valor mais alto de crescimento e o mais baixo
            //
            ViewBag.primeiro_crescimento = artigo.OrderBy(a => a.crescimento).FirstOrDefault().crescimento;

            ViewBag.ultimo_crescimento = artigo.OrderByDescending(a => a.crescimento).FirstOrDefault().crescimento;

            // Recolhe o valor mais alto de luz e o mais baixo
            //
            ViewBag.primeira_luz = artigo.OrderBy(a => a.luz).FirstOrDefault().luz;

            ViewBag.ultima_luz = artigo.OrderByDescending(a => a.luz).FirstOrDefault().luz;

            // Recolhe o valor mais alto de rega e o mais baixo
            //
            ViewBag.primeira_rega = artigo.OrderBy(a => a.rega).FirstOrDefault().rega;

            ViewBag.ultima_rega = artigo.OrderByDescending(a => a.rega).FirstOrDefault().rega;

            return View(artigo.ToList());
        }

        [HttpPost]
        [Authorize]
        public ActionResult Pesquisa(string nome, string peso, string preco, string crescimento, string luz, string rega) {

            // Faz uma selecao de todos os artigos
            // para usar de forma auxilar
            //
            
            var artigo = (from umArtigo in db.Artigo
                          select umArtigo);

            // Verifica e captura os valores para primeira_luz e ultima_luz
            //
            var separa_rega = new string[50];
            var primeira_rega = 0.0;
            var ultima_rega = 0.0;
            if (rega != "" && rega.Count(x => x == ' ') == 1) {
                separa_rega = rega.Split(' ');
                var rega1 = float.Parse(separa_rega[0]);
                var rega2 = float.Parse(separa_rega[1]);
                if (rega1 <= (artigo.OrderByDescending(a => a.rega).FirstOrDefault().rega) && rega2 >= (artigo.OrderBy(a => a.rega).FirstOrDefault().rega)) {
                    primeira_rega = rega1;
                    ultima_rega = rega2;
                } else {
                    primeira_rega = (artigo.OrderByDescending(a => a.rega).FirstOrDefault().rega);
                    ultima_rega = (artigo.OrderBy(a => a.rega).FirstOrDefault().rega);
                }
            }

            // Verifica e captura os valores para primeiro_crescimento e ultimo_crescimento
            //
            var separa_luz = new string[50];
            var primeira_luz = 0.0;
            var ultima_luz = 0.0;
            if (luz != "" && luz.Count(x => x == ' ') == 1) {
                separa_luz = luz.Split(' ');
                var luz1 = float.Parse(separa_luz[0]);
                var luz2 = float.Parse(separa_luz[1]);
                if (luz1 <= (artigo.OrderByDescending(a => a.luz).FirstOrDefault().luz) && luz2 >= (artigo.OrderBy(a => a.luz).FirstOrDefault().luz)) {
                    primeira_luz = luz1;
                    ultima_luz = luz2;
                } else {
                    primeira_luz = (artigo.OrderByDescending(a => a.luz).FirstOrDefault().luz);
                    ultima_luz = (artigo.OrderBy(a => a.luz).FirstOrDefault().luz);
                }
            }

            // Verifica e captura os valores para primeiro_crescimento e ultimo_crescimento
            //
            var separa_crescimento = new string[50];
            var primeiro_crescimento = 0.0;
            var ultimo_crescimento = 0.0;
            if (crescimento != "" && crescimento.Count(x => x == ' ') == 1) {
                separa_crescimento = crescimento.Split(' ');
                var crescimento1 = float.Parse(separa_crescimento[0]);
                var crescimento2 = float.Parse(separa_crescimento[1]);
                if (crescimento1 <= (artigo.OrderByDescending(a => a.crescimento).FirstOrDefault().crescimento) && crescimento2 >= (artigo.OrderBy(a => a.crescimento).FirstOrDefault().crescimento)) {
                    primeiro_crescimento = crescimento1;
                    ultimo_crescimento = crescimento2;
                } else {
                    primeiro_crescimento = (artigo.OrderByDescending(a => a.crescimento).FirstOrDefault().crescimento);
                    ultimo_crescimento = (artigo.OrderBy(a => a.crescimento).FirstOrDefault().crescimento);
                }
            }

            // Verifica e captura os valores para primeiro_preco e ultimo_preco
            //
            var separa_preco = new string[50];
            var primeiro_preco = 0.0;
            var ultimo_preco = 0.0;
            if (preco != "" && preco.Count(x => x == ' ') == 1) {
                separa_preco = preco.Split(' ');
                var preco1 = float.Parse(separa_preco[0]);
                var preco2 = float.Parse(separa_preco[1]);
                if (preco1 <= (artigo.OrderByDescending(a => a.preco).FirstOrDefault().preco) && preco2 >= (artigo.OrderBy(a => a.preco).FirstOrDefault().preco)) {
                    primeiro_preco = preco1;
                    ultimo_preco = preco2;
                } else {
                    primeiro_preco = (artigo.OrderByDescending(a => a.preco).FirstOrDefault().preco);
                    ultimo_preco = (artigo.OrderBy(a => a.preco).FirstOrDefault().preco);
                }
            }

            // Verifica e captura os valores para primeiro_peso e ultimo_peso
            //
            var separa_peso = new string[50];
            var primeiro_peso = 0.0;
            var ultimo_peso = 0.0;
            if (peso != "" && peso.Count(x => x == ' ') == 1) {
                separa_peso = peso.Split(' ');
                var peso1 = float.Parse(separa_peso[0]);
                var peso2 = float.Parse(separa_peso[1]);
                if (peso1 <= (artigo.OrderByDescending(a => a.peso).FirstOrDefault().peso) && peso2 >= (artigo.OrderBy(a => a.peso).FirstOrDefault().peso)) {
                    primeiro_peso = peso1;
                    ultimo_peso = peso2;
                } else {
                    primeiro_peso = (artigo.OrderByDescending(a => a.peso).FirstOrDefault().peso);
                    ultimo_peso = (artigo.OrderBy(a => a.peso).FirstOrDefault().peso);
                }
            }

            // Faz uma pesquisa da palavra a encontrar pesquisa em cada um dos artigos se existe uma correspondencia para nome
            //
            if (nome != "") {
                artigo = artigo.Where(a => a.nome.Contains(nome) || a.nometecnico.Contains(nome) || a.descricao.Contains(nome));
                /*artigo = artigo.Concat(artigo.Where(a => a.nometecnico.Contains(nome)));
                artigo = artigo.Concat(artigo.Where(a => a.descricao.Contains(nome)));*/
                
            }

            // Implementa dois filtros para peso
            //
            artigo = artigo.Where(a => a.peso >= primeiro_peso);
            artigo = artigo.Where(a => a.peso <= ultimo_peso);

            // Implementa dois filtros para preco
            //
            artigo = artigo.Where(a => a.preco >= primeiro_preco);
            artigo = artigo.Where(a => a.preco <= ultimo_preco);

            // Implementa dois filtros para crescimento
            //
            artigo = artigo.Where(a => a.crescimento >= primeiro_crescimento);
            artigo = artigo.Where(a => a.crescimento <= ultimo_crescimento);

            // Implementa dois filtros para rega
            //
            artigo = artigo.Where(a => a.rega >= primeira_rega);
            artigo = artigo.Where(a => a.crescimento <= ultima_rega);

            // Implementa dois filtros para luz
            //
            artigo = artigo.Where(a => a.luz >= primeira_luz);
            artigo = artigo.Where(a => a.luz <= ultima_luz);

            var artigos = (from umArtigo in db.Artigo
                          select umArtigo);
            // Recolhe o valor mais alto de preco e o mais baixo
            //
            ViewBag.primeiro_preco = artigos.OrderBy(a => a.preco).FirstOrDefault().preco;

            ViewBag.ultimo_preco = artigos.OrderByDescending(a => a.preco).FirstOrDefault().preco;

            // Recolhe o valor mais alto de peso e o mais baixo
            //
            ViewBag.primeiro_peso = artigos.OrderBy(a => a.peso).FirstOrDefault().peso;

            ViewBag.ultimo_peso = artigos.OrderByDescending(a => a.peso).FirstOrDefault().peso;

            // Recolhe o valor de crescimento mais baixo e o mais elevado
            //
            ViewBag.primeiro_crescimento = artigos.OrderBy(a => a.crescimento).FirstOrDefault().crescimento;

            ViewBag.ultimo_crescimento = artigos.OrderByDescending(a => a.crescimento).FirstOrDefault().crescimento;

            // Recolhe o valor de luz mais baixo e mais elevado
            //
            ViewBag.primeira_luz = artigos.OrderBy(a => a.luz).FirstOrDefault().luz;

            ViewBag.ultima_luz = artigos.OrderByDescending(a => a.luz).FirstOrDefault().luz;

            // Recolhe o valor de rega mais baixo e o mais elevado
            //
            ViewBag.primeira_rega = artigos.OrderBy(a => a.rega).FirstOrDefault().rega;

            ViewBag.ultima_rega = artigos.OrderByDescending(a => a.rega).FirstOrDefault().rega;

            return View(artigo.ToList());
        }

        // GET: Artigoes/Details/5
        [Authorize]
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
                                      where umArtigo.descricao == "maluco"
                                      select umArtigo);

            // Prepara uma lista nula de CompraArtigos para listar todas 
            // as comprasArtigo onde o nosso artigo de ID = id aparece referenciado
            //
            var compra_artigos = (from umaCompraArtigos in db.Compra_Artigos
                                  where umaCompraArtigos.preco == -1
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
                    compra_artigo_temp.preco = var.preco;
                    compra_artigo_temp.quantidade = var.quantidade;

                    compra_artigos_list.Add(compra_artigo_temp);
                }
            }

            // Seleciona as CompraArtigo cujo ArtigoFK seja diferente do id
            // não são desejadas entradas para o produto para o qual são procurados os detalhes
            // apenas os mais procurados associados a este
            //
            compra_artigos =  compra_artigos_list.Where(a => a.ArtigoFK != 1).OrderByDescending(b => b.quantidade).Take(3).AsQueryable<CompraArtigo>();

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
        [Authorize(Roles = "Administrador")]
        [Authorize(Roles = "Profissonal")]
        public ActionResult Create() {
            ViewBag.CategoriaFK = new SelectList(db.Categoria, "CategoriaID", "tipo");
            return View();
        }

        // POST: Artigoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrador")]
        [Authorize(Roles = "Profissonal")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArtigoID,nome,nometecnico,disponibilidade,descricao,plantacaoComeca,plantacaoAcaba,peso,crescimento,preco,luz,rega,CategoriaFK")] Artigos artigo) {
            if (ModelState.IsValid) {
                db.Artigo.Add(artigo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaFK = new SelectList(db.Categoria, "CategoriaID", "tipo", artigo.CategoriaFK);
            return View(artigo);
        }

        // GET: Artigoes/Edit/5
        [Authorize(Roles = "Administrador")]
        [Authorize(Roles = "Profissonal")]
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
        [Authorize(Roles = "Administrador")]
        [Authorize(Roles = "Profissonal")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArtigoID,nome,nometecnico,disponibilidade,descricao,plantacaoComeca,plantacaoAcaba,peso,crescimento,luz,rega,CategoriaFK")] Artigos artigo) {
            if (ModelState.IsValid) {
                db.Entry(artigo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaFK = new SelectList(db.Categoria, "CategoriaID", "tipo", artigo.CategoriaFK);
            return View(artigo);
        }

        // GET: Artigoes/Delete/5
        [Authorize (Roles = "Administrador")]
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
                carrinho_artigos.quantidade = (int) id2;

                db.Carrinho_Artigos.Add(carrinho_artigos);
                db.SaveChanges();

            } else {
                CarrinhoArtigo carrinho_artigos = db.Carrinho_Artigos.Find(car_artID);
                carrinho_artigos.quantidade = carrinho_artigos.quantidade + (int) id2;

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

            car_artID.Select(c => { c.quantidade = (int) id2; return c; }).ToList();

            return View("Index");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Authorize]
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
                          where umArtigo.nome == "maluco"
                          select umArtigo);

            var artigo_mais_quantidade = artigo_comprado.GroupBy(a => a.ArtigoFK)
                                            .Select(a => new { ArtigoFK = a.Key, quantidade = a.Sum(b => b.quantidade) });

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
