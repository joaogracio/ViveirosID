//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ViveirosID.Views.Shared
{
    using System;
    using System.Collections.Generic;
    
    public partial class Carrinhos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Carrinhos()
        {
            this.CarrinhoArtigoes = new HashSet<CarrinhoArtigoes>();
        }
    
        public int CarrinhoID { get; set; }
        public float precototal { get; set; }
        public System.DateTime ultimaAlteracao { get; set; }
        public float peso { get; set; }
        public Nullable<int> Utilizador_UtilizadorID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarrinhoArtigoes> CarrinhoArtigoes { get; set; }
        public virtual Utilizadores Utilizadores { get; set; }
    }
}