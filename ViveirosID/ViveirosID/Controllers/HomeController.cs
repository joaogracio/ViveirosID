using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViveirosID.Models;

namespace ViveirosID.Controllers {
    public class HomeController : Controller {

        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index() {

            //Fazer uma lista de todos os artigos que aparecem em compras
            //
            var artigos_comprados = (from umaCompra in db.Compra
                                     from umaCompraArtigo in db.Compra_Artigos
                                     where umaCompra.CompraID == umaCompraArtigo.CompraFK
                                     select umaCompraArtigo);

            //Cria uma lista de artigos nula
            //
            var artigos = (from umArtigo in db.Artigo
                           where umArtigo.Nome == ""
                           select umArtigo);

            var artigos_mais_Quantidade = artigos_comprados.GroupBy(a => a.ArtigoFK)
                                            .Select(a => new { ArtigoFK = a.Key, Quantidade = a.Sum(b => b.Quantidade) });

            artigos_mais_Quantidade = artigos_mais_Quantidade.OrderByDescending(a => a.Quantidade);

            artigos_mais_Quantidade = artigos_mais_Quantidade.Take(4);

            foreach (var elm in artigos_mais_Quantidade)
            {
                var artigo_temp = (from umArtigo in db.Artigo
                                   where umArtigo.ArtigoID == elm.ArtigoFK
                                   select umArtigo);
                artigos = artigos.Concat(artigo_temp);
            }

            //artigos = artigos.GroupBy(a => a.ArtigoID).Select(y => y.FirstOrDefault()).Take(4);
            
            return View(artigos.ToList());
            
        }

        public ActionResult About() {
            ViewBag.Message = "Como chegamos até aqui.";

            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Como entrar em contacto com nosco.";

            return View();
        }
    }
}