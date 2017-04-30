﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ViveirosID.Models {
    public class Artigos {

        // Inicializar as variaveis ListaDeCompras, ListaDeArtigos, ListaDeImagens
        public Artigos() {
            ListaDeCompras = new HashSet<CompraArtigo>();
            ListaDeCarrinhos = new HashSet<CarrinhoArtigo>();
            ListaDeImagens = new HashSet<Imagens>();
        }

        // Chave Primaria da Tabela ArtigoID
        [Key]
        public int ArtigoID { get; set; }

        [Required]
        [RegularExpression("([A-Z][a-zãáéõç]{3,11})[ ]?([A-Z][a-zãáéõç]{3,11}|[d][eo][s]?)?[ ]?([A-Z][a-zãáéõç]{3,11})?[ ]?([A-Z][a-zãáéõç]{3,11})?",
            ErrorMessage = "Nome do seu artigo em Portugues. Insira apenas caracteres [A-Z] e [a-z]. Comece as palavras por letra maiuscula. A segunda palavra pode ser um [de], [do] ou [dos]. Use apenas um espaço em branco [ ] entre palavras.")]
        public string nome { get; set; }

        [RegularExpression("([A-Z][a-z]{3,11})[ ]([a-z]{3,12})", ErrorMessage = "Nome cientifico da sua planta. Insira apenas caracteres [A-Z] e [a-z]. Coloque duas palavras. Comece primeira palavra por maiuscula e a segunda por minuscula.")]
        public string nometecnico { get; set; }

        public Boolean disponibilidade { get; set; }

        public string descricao { get; set; }

        [RegularExpression("([J][a][n][e][i][r][o])|([F][e][v][e][r][e][i][r][o])|([M][a][r][ç][o])|([A][b][r][i][l])|([M][a][i][o])|([J][u][n][h][o])|([J][u][l][h][o])|([A][g][o][s][t][o])|([S][e][t][e][m][b][r][o])|([O][u][t][u][b][r][o])|([N][o][v][e][m][b][r][o])|([D][e][z][e][m][b][r][o])",
            ErrorMessage = "Mes do ano para comecar a plantar o seu artigo. Coloque apenas palavras reservadas para meses do ano: Janeiro, Fevereiro, ..., Dezembro")]
        public string plantacaoComeca { get; set; }

        [RegularExpression("([J][a][n][e][i][r][o])|([F][e][v][e][r][e][i][r][o])|([M][a][r][ç][o])|([A][b][r][i][l])|([M][a][i][o])|([J][u][n][h][o])|([J][u][l][h][o])|([A][g][o][s][t][o])|([S][e][t][e][m][b][r][o])|([O][u][t][u][b][r][o])|([N][o][v][e][m][b][r][o])|([D][e][z][e][m][b][r][o])",
            ErrorMessage = "Mes do ano para interromper a plantação do seu artigo. Coloque apenas palavras reservadas para meses do ano: Janeiro, Fevereiro, ..., Dezembro")]
        public string plantacaoAcaba { get; set; }

        [RegularExpression("([0-9]{2})([0-9]{0,7})",
            ErrorMessage = "Peso do seu artigo em gramas. Coloque apenas numeros. No minimo 2 no máximo 9")]
        public float peso { get; set; }

        [RegularExpression("([R][á][p][i][d][o])|([M][o][d][e][r][a][d][o])|([L][e][n][t][o])",
            ErrorMessage = "Taxa de crescimento oo seu artigo. Coloque uma das seguintes três palavras: Rápido, Moderado ou Lento")]
        public string crescimento { get; set; }

        [RegularExpression("([S][o][l])|([M][e][i][a][-][S][o][m][b][r][a])|([S][o][m][b][r][a])",
            ErrorMessage = "Quantidade de Luz que o seu artigo deve receber. Coloque uma das seguintes três palavras: Sol, Meia-Sombra ou Sombra.")]
        public string Luz { get; set; }

        [RegularExpression("([I][n][t][e][n][s][i][v][a])|([R][e][g][u][l][a][r])|([R][e][d][u][z][i][d][a])",
            ErrorMessage = "Quantidade de água que o seu artigo merece. Coloque uma das seguintes três palavras: Intensiva, Regular e Reduzida.")]
        public string Rega { get; set; }


        public float preço { get; set; }


        // Para cada artigo existe uma Categoria
        // Inicializa a chave forateira desse relacionamento
        [ForeignKey("Categoria")]
        public int CategoriaFK { get; set; }

        // Relaciona um Artigo com uma Categoria
        public Categorias Categoria { get; set; }

        // Um Artigo tem uma lista de Compras
        public virtual ICollection<CompraArtigo> ListaDeCompras { get; set; }
        // Um Artigo tem uma lista de Carrinho
        public virtual ICollection<CarrinhoArtigo> ListaDeCarrinhos { get; set; }
        // Um Artigo tem uma lista de Imagens
        public virtual ICollection<Imagens> ListaDeImagens { get; set; }
    }
}