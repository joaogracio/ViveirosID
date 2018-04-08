using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ViveirosID.Models
{
    public class Cupons
    {
        // Inicializar as variaveis ListaDeCompras, ListaDeArtigos, ListaDeImagens
        public Cupons()
        {
            ListaDeCuponsArtigos = new HashSet<CuponsArtigos>();
        }

        [Key]
        public int CuponsID { get; set; }
        public string codigo { get; set; }
        public string descricao { get; set; }
        public DateTime dataLimite { get; set; }

        // Um Artigo tem uma lista de Compras
        public virtual ICollection<CuponsArtigos> ListaDeCuponsArtigos { get; set; }
       
    }
}