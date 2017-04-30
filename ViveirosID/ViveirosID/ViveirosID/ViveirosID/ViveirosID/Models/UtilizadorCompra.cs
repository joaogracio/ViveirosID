using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ViveirosID.Models {
    public class UtilizadorCompra {

        // Chave primeira desta tabela
        // que fica nas "vezes" da concatenacao
        // de duas chaves forasteiras Utilizador e Compra
        [Key]
        public int ID { get; set; }

        // Chave Forasteira da Tabela Utilizador
        [ForeignKey("Utilizador")]
        public int UtilizadorFK { get; set; }

        // existe uma compra para cada Utilizador e vsvs
        public Utilizadores Utilizador { get; set; }

        // Chave Forasteira da Tabela Compra
        [ForeignKey("Compra")]
        public int CompraFK { get; set; }

        // existe uma compra para cada Utilizador e vsvs
        public Compras Compra { get; set; }

    }
}