using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ViveirosID.Models {

    public class Carrinhos {

        // Inicializar a variavel Lista de Compras
        public Carrinhos() {
            ListadeArtigos = new HashSet<CarrinhoArtigo>();
        }

        // Chave Primaria da Tabela Carrinho
        [Key]
        public int CarrinhoID { get; set; }

        public float precototal { get; set; }

        public DateTime ultimaAlteracao { get; set; }

        public float peso { get; set; }

        [ForeignKey("Utilizador")]
        public int UtilizadorFK;

        public virtual Utilizadores Utilizador { get; set; }
        //*************************************************************************************

        // Um utilizador tem uma lista de compras
        public virtual ICollection<CarrinhoArtigo> ListadeArtigos { get; set; }
    }
}