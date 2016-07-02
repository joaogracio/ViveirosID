using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ViveirosID.Models {
    public class Utilizadores {
        public Utilizadores() {
            Compras = new HashSet<UtilizadorCompra>();
            Carrinho = new HashSet<Carrinhos>();
        }

        // Chave Primaria da Tabela Utilizador
        [Key]
        [Required]
        public int UtilizadorID { get; set; }

        //public Boolean sexo { get; set; }

        [Required]
        public string nome { get; set; }

        [Required]
        public string apelido { get; set; }

        [Required]
        public DateTime? datadenascimento { get; set; }

        [Required]
        public int? NIF { get; set; }

        [Required]
        public string morada { get; set; }

        [Required]
        public string local { get; set; }

        [Required]
        public string codigoposta { get; set; }

        [Required]
        public string cidade { get; set; }

        [Required]
        public string distrito { get; set; }

        [Required]
        public string pais { get; set; }

        [Required]
        public string telefone { get; set; }

        //public Boolean newsletter { get; set; }


        // Cria uma Chave Forasteira para a Tabela Utilizador
        [ForeignKey("Carrinho")]
        public int CarrinhoFK { get; set; }

        public string IDaspuser { get; set; }
        // Determina que para cada Utilizador existe um Carrinho

        public virtual ICollection<Carrinhos> Carrinho { get; set; }
        public virtual ICollection<UtilizadorCompra> Compras { get; set; }

        // public virtual Carrinho Carrinho { get; set; }
    }
}