//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ViveirosID.Views
{
    using System;
    using System.Collections.Generic;
    
    public partial class Utilizadores
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Utilizadores()
        {
            this.Carrinhos = new HashSet<Carrinhos>();
            this.UtilizadorCompras = new HashSet<UtilizadorCompras>();
        }
    
        public int UtilizadorID { get; set; }
        public string nome { get; set; }
        public string apelido { get; set; }
        public System.DateTime datadenascimento { get; set; }
        public int NIF { get; set; }
        public string morada { get; set; }
        public string local { get; set; }
        public string codigoposta { get; set; }
        public string cidade { get; set; }
        public string distrito { get; set; }
        public string pais { get; set; }
        public string telefone { get; set; }
        public int CarrinhoFK { get; set; }
        public string IDaspuser { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Carrinhos> Carrinhos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UtilizadorCompras> UtilizadorCompras { get; set; }
    }
}