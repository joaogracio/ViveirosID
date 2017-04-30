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
            ListaDeArtigos = new HashSet<CarrinhoArtigo>();
        }

        // Chave Primaria da Tabela Carrinho
        [Key]
        public int CarrinhoID { get; set; }

        public float preçototal { get; set; }

        public DateTime ultimaAlteracao { get; set; }

        public float peso { get; set; }

        // Inicializa a Chave Forasteira para Utilizador
        // Para cada Carrinho existe um Utilizador
        [ForeignKey("Utilizador")]
        public int UtilizadorFK { get; set; }

        public virtual Utilizadores Utilizador { get; set; }

        // Um utilizador tem uma lista de compras
        public virtual ICollection<CarrinhoArtigo> ListaDeArtigos { get; set; }
    }
}