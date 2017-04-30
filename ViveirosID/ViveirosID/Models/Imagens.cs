using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ViveirosID.Models
{
    public class Imagens {

        // Chave Primaria da Tabela Imagem
        [Key]
        public int ImagemID { get; set; }

        public string nome { get; set; }

        public string directorio { get; set; }

        public string descricao { get; set; }

        public string tipo { get; set; }

        // Cria uma Chave forasteira para a variavel Artigo
        [ForeignKey("Artigo")]
        public int ArtigoFK { get; set; }

        // Relaciona uma Imagem com um Artigo
        public Artigos Artigo { get; set; }


    }
}