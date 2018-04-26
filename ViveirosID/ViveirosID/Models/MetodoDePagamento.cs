using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ViveirosID.Models
{
    public class MetodoDePagamento
    {
        [Key]
        public int MetodoDePagamentoID { get; set; }

        [Required]
        [RegularExpression("([T][r][a][n][s][f][e][r][e][n][c][i][a])|([V][i][s][a])|([E][n][v][e][l][o][p][e])",
            ErrorMessage = "No nome metodos de pagamento coloque apenas: Transferencia, Envelope ou Visa.")]
        public string metodoNome { get; set; }
    }
}