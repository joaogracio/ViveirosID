using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ViveirosID.Models {

    public class CompraArtigo {

        // Tabela que resulta do relacionamento
        // muitos para muitos Compra Artigos

        // Chave primeira desta tabela
        // que fica nas "vezes" da concatenacao
        // de duas chaves forasteiras Artigo e Compra
        [Key]
        public int ID { get; set; }

        public int quantidade { get; set; }

        public double preco { get; set; }

        public int IVA { get; set; }

       
        /// /////////////////////////////////////////////////////////////////////////////////////
  
        // Chave forasteira para Artigo
        [ForeignKey("Artigo")]
        public int ArtigoFK { get; set; }

        // Nesta Tabela para uma Compra existe um Artigo
        // visse versa
        public Artigos Artigo { get; set; }

        // Chave forasteira para Compra
        [ForeignKey("Compra")]
        public int CompraFK { get; set; }

        // Nesta Tabela para uma Compra existe um Artigo
        // visse versa
        public Compras Compra { get; set; }
        // Criar aqui um Constraint
    }
}