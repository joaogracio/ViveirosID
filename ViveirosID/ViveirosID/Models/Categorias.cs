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

        [RegularExpression("([A-Z][a-zá]{4,15})[ ]?([A-Z][a-zá]{4,15}|[d][e]|[d][o][s]?|[p][a][r][a]|[e])?[ ]?([A-Z][a-z]{4,15}|[d][e]|[d][o][s]?|[p][a][r][a]|[e])?[ ]?([A-Z][a-z]{4,15}|[d][e]|[d][o][s]?|[p][a][r][a]|[e])?[ ]?([A-Z][a-z]{4,15}|[d][e]|[d][o][s]?|[p][a][r][a]|[e])?",
            ErrorMessage = "Coloque aqui a descricao do Tipo de categoria. Usa uma primeira palavra comecada em maiuscula seguida de minisculas. Para as restantes palavras para alem de palavras comecadas em maiuscula, pode usar: para, de, do, dos. Use até cinco palavras deste geito. Atencão um espaco em branco entre palavras.")]
        public string Tipo { get; set; }

        // Um utilizador tem uma lista de compras
        public virtual ICollection<Artigos> ListaDeArtigos { get; set; }

    }

}