using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ViveirosID.Models {

    public class CarrinhoArtigo {

        // Tabela resultante do relacionamento Carrinho Artigos
        // muitos para muitos

        // Chave primaria de Carrinho_Artigos
        // Nao e possivel a concatenação das duas chaves forasteiras
        // Artigo e Carrinho
        [Key]
        public int ID { get; set; }

        public int quantidade { get; set; }

        // Chave Forasteira para Artigo
        [ForeignKey("Artigo")]
        public int ArtigoFK { get; set; }

        // Referencia um Artigo para um Carrinho
        // Carrinho_Artigos tem um Artigo
        public Artigos Artigo { get; set; }

        // Chave Forasteira para Carrinho
        [ForeignKey("Carrinho")]
        public int CarrinhoFK { get; set; }

        // Referencia um Carrinho para um Artigo
        // Carrinho_Artigos tem um Carrinho
        public Carrinhos Carrinho { get; set; }

    }
}