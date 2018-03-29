using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ViveirosID.Models
{
    public class CuponsArtigos
    {
        [Key]
        public int ID { get; set; }
        public int percentagem { get; set; }

        // Cria uma Chave forasteira para a variavel Artigo
        [ForeignKey("Artigo")]
        public int ArtigoFK { get; set; }

        // Relaciona uma Imagem com um Artigo
        public Artigos Artigo { get; set; }

        // Cria uma Chave forasteira para a variavel Artigo
        [ForeignKey("Cupon")]
        public int CuponsFK { get; set; }

        // Relaciona uma Imagem com um Artigo
        public Cupons Cupon { get; set; }
    }
}