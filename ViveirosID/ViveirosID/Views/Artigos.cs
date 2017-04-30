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
    
    public partial class Artigos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Artigos()
        {
            this.CarrinhoArtigoes = new HashSet<CarrinhoArtigoes>();
            this.CompraArtigoes = new HashSet<CompraArtigoes>();
            this.Imagens = new HashSet<Imagens>();
        }
    
        public int ArtigoID { get; set; }
        public string nome { get; set; }
        public string nometecnico { get; set; }
        public bool disponibilidade { get; set; }
        public string descricao { get; set; }
        public string plantacaoComeca { get; set; }
        public string plantacaoAcaba { get; set; }
        public float peso { get; set; }
        public float crescimento { get; set; }
        public float Luz { get; set; }
        public float Rega { get; set; }
        public float preço { get; set; }
        public int CategoriaFK { get; set; }
    
        public virtual Categorias Categorias { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarrinhoArtigoes> CarrinhoArtigoes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CompraArtigoes> CompraArtigoes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Imagens> Imagens { get; set; }
    }
}
