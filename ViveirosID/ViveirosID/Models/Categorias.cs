using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ViveirosID.Models {

    public class Categorias {

        // Inicializar a variavel Lista de Artigos
        public Categorias() {
            ListaDeArtigos = new HashSet<Artigos>();
        }

        // Chave Primaria do Utilizador
        [Key]
        public int CategoriaID { get; set; }

        [RegularExpression("([A-Z][a-z]{4,15})[ ]?([A-Z][a-z]{4,15}|[d][e]|[d][o][s]?|[p][a][r][a]|[e])?[ ]?([A-Z][a-z]{4,15}|[d][e]|[d][o][s]?|[p][a][r][a]|[e])?[ ]?([A-Z][a-z]{4,15}|[d][e]|[d][o][s]?|[p][a][r][a]|[e])?[ ]?([A-Z][a-z]{4,15}|[d][e]|[d][o][s]?|[p][a][r][a]|[e])?",
            ErrorMessage = "Coloque aqui a descricao do tipo de categoria. Usa uma primeira palavra começada em maiuscula seguida de minisculas. Para as restantes palavras para alem de palavras começadas em maiuscula, pode usar: para, de, do, dos. Use até cinco palavras deste geito. Atenção um espaço em branco entre palavras.")]
        public string tipo { get; set; }

        // Um utilizador tem uma lista de compras
        public virtual ICollection<Artigos> ListaDeArtigos { get; set; }

    }

}