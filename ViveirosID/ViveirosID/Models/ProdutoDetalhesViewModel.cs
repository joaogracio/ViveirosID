using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ViveirosID.Models {
    public class ProdutoDetalhesViewModel {

        public ProdutoDetalhesViewModel() {
            Artigos = new HashSet<Artigos>();
            Imagens = new HashSet<Imagens>();
        }

        // Artigo a cerca do qual se estão a procurar os detalhes
        //
        public Artigos Artigo { get; set; }

        // Lista de Imagens Respectivas ao grupo de Artigos Enviado
        // Varias Imagens por Artigos
        //
        public virtual ICollection<Imagens> Imagens { get; set; }

        // Lista de Artigos a serem diponibilizados
        // 
        public virtual ICollection<Artigos> Artigos { get; set; }

    }
}