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
        public string nome { get; set; }
        public float preco { get; set; }
        public float preco_total_prd { get; set; }
        public int quantidade { get; set; }
        public string tipo { get; set; }

        /*public virtual ICollection<Imagens> Imagens { get; set; }*/
    }
}