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
    
    public partial class Imagens
    {
        public int ImagemID { get; set; }
        public string Nome { get; set; }
        public string Directorio { get; set; }
        public string Descricao { get; set; }
        public string Tipo { get; set; }
        public int ArtigoFK { get; set; }
    
        public virtual Artigos Artigos { get; set; }
    }
}
