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
                    // Listagem de mes a mes para mediante o tipo de ordenação 
                    // concatenar de ordem ascendente ou descendente
                    //
                    var janeiro = artigo.Where(a => a.plantacaoComeca == "Janeiro");
                    var fevereiro = artigo.Where(a => a.plantacaoComeca == "Fevereiro");
                    var março = artigo.Where(a => a.plantacaoComeca == "Março");
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
                        artigo = janeiro.Concat(fevereiro).Concat(março).Concat(abril).Concat(maio).Concat(junho).Concat(julho).Concat(agosto).Concat(setembro).Concat(outubro).Concat(novembro).Concat(dezembro);
                    } else if (ordem == "descendente") {
                        artigo = dezembro.Concat(novembro).Concat(outubro).Concat(setembro).Concat(agosto).Concat(julho).Concat(junho).Concat(maio).Concat(abril).Concat(março).Concat(fevereiro).Concat(janeiro);
                    }
                    break;

                case "plantacao acaba":
                    // Listagem de mes a mes para mediante o tipo de ordenação 
                    // concatenar de ordem ascendente ou descendente
                    //
                    var janeiroA = artigo.Where(a => a.plantacaoComeca == "Janeiro");
                    var fevereiroA = artigo.Where(a => a.plantacaoComeca == "Fevereiro");
                    var marçoA = artigo.Where(a => a.plantacaoComeca == "Março");
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
                        artigo = janeiroA.Concat(fevereiroA).Concat(marçoA).Concat(abrilA).Concat(maioA).Concat(junhoA).Concat(julhoA).Concat(agostoA).Concat(setembroA).Concat(outubroA).Concat(novembroA).Concat(dezembroA);
                    } else if (ordem == "descendente") {
                        artigo = dezembroA.Concat(novembroA).Concat(outubroA).Concat(setembroA).Concat(agostoA).Concat(julhoA).Concat(junhoA).Concat(maioA).Concat(abrilA).Concat(marçoA).Concat(fevereiroA).Concat(janeiroA);
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

                    var itensiva = artigo.Where(a => a.crescimento == "Rápido");
                    var moderado = artigo.Where(a => a.crescimento == "Moderado");
                    var lento = artigo.Where(a => a.crescimento == "Lento");

                    if (ordem == "ascendente") {
                        artigo = lento.Concat(moderado).Concat(itensiva);
                    } else if (ordem == "descendente") {
                        artigo = itensiva.Concat(moderado).Concat(lento);
                    }
                    break;

                case "luz":

                    var sol = artigo.Where(a => a.Luz == "Sol");
                    var meiasombra = artigo.Where(a => a.Luz == "Meia-Sombra");
                    var sombra = artigo.Where(a => a.Luz == "Sombra");

                    if (ordem == "ascendente") {
                        artigo = sombra.Concat(meiasombra).Concat(sol);
                    } else if (ordem == "descendente") {
                        artigo = sol.Concat(meiasombra).Concat(sombra);
                    }
                    break;

                case "rega":

                    var itensivaA = artigo.Where(a => a.Rega == "Intensiva");
                    var regular = artigo.Where(a => a.Rega == "Regular");
                    var reduzida = artigo.Where(a => a.Rega == "Reduzida");

                    if (ordem == "ascendente") {
                        artigo = reduzida.Concat(regular).Concat(itensivaA);
                    } else if (ordem == "descendente") {
                        artigo = itensivaA.Concat(regular).Concat(reduzida);
                    }
                    break;

                case "preço":
                    if (ordem == "ascendente") {
                        artigo = artigo.OrderBy(a => a.preço);
                    } else if (ordem == "descendente") {
                        artigo = artigo.OrderByDescending(a => a.preço);
                    }
                    break;
            }

            /*var artigo = (from umArtigo in db.Artigo
                       where umArtigo.disponibilidade == true
                       select umArtigo).Include(a => a.Categoria);*/

            /*if (User.Identity.IsAuthenticated == true && User.IsInRole("Administrador")) {

            }*/
           
            return View(artigo.ToList());
        }

        [HttpPost]
        public ActionResult Index() {

            var artigo = (from umArtigo in db.Artigo
                          select umArtigo).Include(a => a.Categoria);

            // Get Post Params Here
            var var1 = Request["Ordem"];

            return View(artigo.ToList());
        
        }

        public ActionResult Pesquisa() {

            // Prepara a lista standart de artigos para enviar para a View
            //
            var artigo = (from umArtigo in db.Artigo
                          select umArtigo).Include(a => a.Categoria);

            // Recolhe o valor mais alto de preço e o mais baixo
            //
            ViewBag.primeiro_preço = artigo.OrderBy(a => a.preço).FirstOrDefault().preço;

            ViewBag.ultimo_preço = artigo.OrderByDescending(a => a.preço).FirstOrDefault().preço;

            // Recolhe o valor mais alto de peso e o mais baixo
            //
            ViewBag.primeiro_peso = artigo.OrderBy(a => a.peso).FirstOrDefault().peso;

            ViewBag.ultimo_peso = artigo.OrderByDescending(a => a.peso).FirstOrDefault().peso;

            // Recolhe as três palavras de escolha de Crescimento
            // Rápido, Moderado, Lento
            //
            ViewBag.crescimento = new string[3] { "Lento", "Moderado", "Rapido" };

            // Recolhe as três palavras relacionadas com a Luz 
            // Sol, Meia-Sombra, Sombra
            //
            ViewBag.luz = new string[3] { "Sombra", "Meia-Sombra", "Sol" };

            // Recolhe as três palavras relacionadas com a Rega
            // Intensiva, Regula, Reduzida
            //
            ViewBag.rega = new string[3] { "Reduzida", "Regular", "Intensiva" };

            return View(artigo.ToList());
        }

        [HttpPost]
        public ActionResult Pesquisa(string nome, string peso, string preço, string crescimento, string luz, string rega, string ordem) {
            
            // Faz uma listagem "usual" de todos os artigos 
            // listagem esta que vai depois ser filtrada e apresentada
            //
            /*var artigo = (from umArtigo in db.Artigo
                          select umArtigo).Include(a => a.Categoria);*/

            // Separa a string peso => "de 2 gramas até 8 gramas" pelo caracter ' '
            //
            var separa_por_espaço_arr = peso.Split(' ');

            // Regista dois inteiros relativos ao limite inferior e superior do preço em gramas
            //
            var primeiro_peso = Int32.Parse(separa_por_espaço_arr[1]);

            var segundo_peso = Int32.Parse(separa_por_espaço_arr[4]);


            // Separa a string preço => "de €2 até €8" pelo caracter €
            // de forma a recolher os numeros referentes aos preços
            // o resultados deste split é o seguinte: ["de "]["2 até "]["8"]
            //
            var separa_por_euro_arr = preço.Split('€');

            // Separa a string ["2 até "] pelo caracter ' ' de forma a isolar o numero
            //
            var primeiro_valor_arr = separa_por_euro_arr[1].Split(' ');

            // Converte a string que contem o primeiro preço para int
            //
            var primeiro_preço = float.Parse(primeiro_valor_arr[0]);

            // Convert a string que contem o segundo preço para int
            //
            var segundo_preço = float.Parse(separa_por_euro_arr[2]);

            // Separa a string relativa ao crescimento "de Lento até Rapido"
            // Recolhe o primeiro e ultimo valor para crescimento
            //
            var separa_crescimento = crescimento.Split(' ');

            var primeiro_crescimento = separa_crescimento[1];

            var ultimo_crescimento = separa_crescimento[3];

            // Separa a string relativa ao luz "de Sombra até Sol"
            // Recolhe o primeiro e ultimo valor para crescimento
            //
            var separa_luz = luz.Split(' ');

            var primeira_luz = separa_luz[1];

            var ultima_luz = separa_luz[3];

            // Separa a string relativa ao rega "de Reduzida até Intensiva"
            // Recolhe o primeiro e ultimo valor para rega
            //
            var separa_rega = rega.Split(' ');

            var primeira_rega = separa_rega[1];

            var ultima_rega = separa_rega[3];


            // SIMULAÇAO DA AQUISIÇÃO DE DADOS DE TODOS OS TIPOS DE crescimento, rega, luz
            var str_crescimento = new string[3]{ "Lento", "Moderado", "Rapido" };
            var str_luz = new string[3] { "Sombra", "Meia-Sombra", "Sol" };
            var str_rega = new string[3] { "Reduzida", "Regular", "Intensiva" };
            // SIMULAÇAO DA AQUISIÇÃO DE DADOS DE TODOS OS TIPOS DE crescimento, rega, luz

            var primeiro_crescimento_pos = 0;

            var ultimo_crescimento_pos = 0;

            var primeira_luz_pos = 0;

            var ultima_luz_pos = 0;

            var primeira_rega_pos = 0;

            var ultima_rega_pos = 0;

            // Encontra a posição da primeiro_crescimento e ultimo_crescimento
            // para atribuir o valor da posição correpondente do array str_crescimento
            // em primeiro_crescimento_pos e ultimo_crescimento_pos
            //
            for (var i = 0; i <= str_crescimento.Length - 1; i++) {
                if (str_crescimento[i].Equals(primeiro_crescimento)) {
                    primeiro_crescimento_pos = i;
                }
                if (str_crescimento[i].Equals(ultimo_crescimento)) {
                    ultimo_crescimento_pos = i;
                }
            }

            // Encontra a posição da primeira_rega e ultima_rega
            // para atribuir o valor dessas posições correspondentes ao str_rega
            // em primeira_rega_pos e ultima_rega_pos
            //
            for (var i = 0; i <= str_rega.Length - 1; i++) {
                if (str_rega[i].Equals(primeira_rega)) {
                    primeira_rega_pos = i;
                }
                if (str_rega[i].Equals(ultima_rega)) {
                    ultima_rega_pos = i;
                }
            }

            // Encontra a posição da primeira_luz e ultima_luz
            // para atribuir o valor dessas posições correspondentes ao str_luz
            // em primeira_luz_pos e ultima_luz_pos
            //
            for (var i = 0; i <= str_luz.Length - 1; i++) {
                if (str_luz[i].Equals(primeira_luz)) {
                    primeira_luz_pos = i;
                }
                if (str_luz[i].Equals(ultima_luz)) {
                    ultima_luz_pos = i;
                }
            }

            // IMPLEMENTAÇÃO DE TODOS OS FILTROS E CRIAÇÃO DE VIEWBAGS PARA ENVIAR COM OS LIMITOS DOS FILTROS PARA A VIEW

            // Faz uma selecao de todos os artigos
            // para usar de forma auxilar
            //
            var todo_artigo = (from umArtigo in db.Artigo
                               select umArtigo);

            var artigo = (from umArtigo in db.Artigo
                          where umArtigo.crescimento == "Maluco"
                          select umArtigo);

            // ISTO PODIA SER FEITO COM RECURSO A NUMEROS PARA LUZ, REGA, CRESCIMENTO MAS EU FUI TEIMOSO 
            // E CONTINUEI O PROCESSO ASSIM

            // Faz a filtragem por luz
            //
            for (var i = primeira_luz_pos; i <= ultima_luz_pos; i++) {
                var str_pos = str_luz[i];
                artigo = artigo.Concat(todo_artigo.Where(a => a.Luz.Equals(str_pos)));
                /*try {
                    var nome_str = artigo_not_null.FirstOrDefault().nome;
                    artigo = artigo_not_null;
                } catch (System.NullReferenceException ex) {
                    
                }*/
            }

            // Faz a filtragem por rega
            //
            for (var i = primeira_rega_pos; i <= ultima_rega_pos; i++) {
                var str_pos = str_rega[i];
                artigo = artigo.Concat(todo_artigo.Where(a => a.Rega.Equals(str_pos)));
                /*try {
                    var nome_str = artigo_not_null.FirstOrDefault().nome;
                    artigo = artigo_not_null;
                } catch (System.NullReferenceException ex) {

                }*/
            }

            // Faz a filtragem por crescimento
            //
            for (var i = primeiro_crescimento_pos; i <= ultimo_crescimento_pos; i++) {
                var str_pos = str_luz[i];
                artigo = artigo.Concat(todo_artigo.Where(a => a.crescimento.Equals(str_pos)));
                /*try {
                    var nome_str = artigo_not_null.FirstOrDefault().nome;
                    artigo = artigo_not_null;
                } catch (System.NullReferenceException ex) {

                }*/
            }

            // Faz uma pesquisa da palavra a encontrar pesquisa em cada um dos artigos se existe uma correspondencia para nome
            //
            if (nome != null) {
                artigo = artigo.Where(a => a.nome.Contains(nome) || a.nometecnico.Contains(nome) || a.descricao.Contains(nome));
                /*artigo = artigo.Concat(artigo.Where(a => a.nometecnico.Contains(nome)));
                artigo = artigo.Concat(artigo.Where(a => a.descricao.Contains(nome)));*/
                
            }

            // Implementa dois filtros para peso
            //
            artigo = artigo.Where(a => a.peso >= primeiro_peso);
            artigo = artigo.Where(a => a.peso <= segundo_peso);

            // Implementa dois filtros para preço
            artigo = artigo.Where(a => a.preço >= primeiro_preço);
            artigo = artigo.Where(a => a.preço <= segundo_preço);

            /*if (ordem == "descendente") {
                artigo = artigo.OrderByDescending(a => a.nome);
            } else if (ordem == "ascendente") {
                artigo = artigo.OrderBy(a => a.nome);
            }*/

            // Recolhe o valor mais alto de preço e o mais baixo
            //
            ViewBag.primeiro_preço = todo_artigo.OrderBy(a => a.preço).FirstOrDefault().preço;

            ViewBag.ultimo_preço = todo_artigo.OrderByDescending(a => a.preço).FirstOrDefault().preço;

            // Recolhe o valor mais alto de peso e o mais baixo
            //
            ViewBag.primeiro_peso = todo_artigo.OrderBy(a => a.peso).FirstOrDefault().peso;

            ViewBag.ultimo_peso = todo_artigo.OrderByDescending(a => a.peso).FirstOrDefault().peso;

            // Recolhe as três palavras de escolha de Crescimento
            // Rápido, Moderado, Lento
            //
            ViewBag.crescimento = new string[3] { "Lento", "Moderado", "Rapido" };

            // Recolhe as três palavras relacionadas com a Luz 
            // Sol, Meia-Sombra, Sombra
            //
            ViewBag.luz = new string[3] { "Sombra", "Meia-Sombra", "Sol"};

            // Recolhe as três palavras relacionadas com a Rega
            // Intensiva, Regula, Reduzida
            //
            ViewBag.rega = new string[3] { "Reduzida", "Regular", "Intensiva" };

            return View(artigo.ToList());
        }

        // GET: Artigoes/Details/5
        [Authorize]
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
        [Authorize (Roles="Administrador")]
        public ActionResult Create() {
            ViewBag.CategoriaFK = new SelectList(db.Categoria, "CategoriaID", "tipo");
            return View();
        }

        // POST: Artigoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize (Roles = "Administrador")]
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
        [Authorize (Roles = "Administrador")]
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
        [Authorize (Roles = "Administrador")]
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
