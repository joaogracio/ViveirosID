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
    
    public partial class Imagens
    {
        public int ImagemID { get; set; }
        public string nome { get; set; }
        public string directorio { get; set; }
        public string descricao { get; set; }
        public string tipo { get; set; }
        public int ArtigoFK { get; set; }
    
        public virtual Artigos Artigos { get; set; }
    }
}