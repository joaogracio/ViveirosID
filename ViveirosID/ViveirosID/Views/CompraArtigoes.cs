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
    
    public partial class CompraArtigoes
    {
        public int ID { get; set; }
        public int quantidade { get; set; }
        public double Preco { get; set; }
        public int IVA { get; set; }
        public int ArtigoFK { get; set; }
        public int CompraFK { get; set; }
    
        public virtual Artigos Artigos { get; set; }
        public virtual Compras Compras { get; set; }
    }
}
