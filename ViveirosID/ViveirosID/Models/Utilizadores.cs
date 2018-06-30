using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ViveirosID.Models {
    public class Utilizadores {
        public Utilizadores() {
            Compra = new HashSet<Compras>();
            Carrinho = new HashSet<Carrinhos>();
        }

        // Chave Primaria da Tabela Utilizador
        [Key]
        [Required]
        public int UtilizadorID { get; set; }

        //public Boolean sexo { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Apelido { get; set; }

        [Required]
        public DateTime? DataDeNascimento { get; set; }

        [Required]
        public int? NIF { get; set; }

        [Required]
        public string Morada { get; set; }

        [Required]
        public string Local { get; set; }

        [Required]
        public string Codigopostal { get; set; }

        [Required]
        public string Cidade { get; set; }

        [Required]
        public string Distrito { get; set; }

        [Required]
        public string Pais { get; set; }

        [Required]
        public string Telefone { get; set; }

        public double Preco_transporte { get; set; }

        // Cria uma Chave Forasteira para a Tabela Utilizador
        [ForeignKey("Carrinho")]
        public int CarrinhoFK { get; set; }       

        public virtual ICollection<Carrinhos> Carrinho { get; set; }

        public string IDaspuser { get; set; }
        // Determina que para cada Utilizador existe um Carrinho


        //  public virtual Carrinhos Carrinho { get; set; }

        public virtual ICollection<Compras> Compra { get; set; }

        // public virtual Carrinho Carrinho { get; set; }
    }
}