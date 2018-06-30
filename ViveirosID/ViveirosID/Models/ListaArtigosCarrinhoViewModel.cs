using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ViveirosID.Models;

namespace Viveiros.Models {
    public class ListaArtigosCarrinhoViewModel {

        /*public ListaArtigosCarrinhoViewModel() {
            Imagens = new HashSet<Imagens>();
        }*/
        public int ArtigoID { get; set; }
        public string Nome { get; set; }
        public float Preco { get; set; }
        public float Preco_total_prd { get; set; }
        public int Quantidade { get; set; }
        public string Tipo { get; set; }

        /*public virtual ICollection<Imagens> Imagens { get; set; }*/
    }
}