﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities2 : DbContext
    {
        public Entities2()
            : base("name=Entities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Artigos> Artigos { get; set; }
        public virtual DbSet<CarrinhoArtigoes> CarrinhoArtigoes { get; set; }
        public virtual DbSet<Carrinhos> Carrinhos { get; set; }
        public virtual DbSet<Categorias> Categorias { get; set; }
        public virtual DbSet<CompraArtigoes> CompraArtigoes { get; set; }
        public virtual DbSet<Compras> Compras { get; set; }
        public virtual DbSet<ContentViewModels> ContentViewModels { get; set; }
        public virtual DbSet<Cupons> Cupons { get; set; }
        public virtual DbSet<CuponsArtigos> CuponsArtigos { get; set; }
        public virtual DbSet<Imagens> Imagens { get; set; }
        public virtual DbSet<Utilizadores> Utilizadores { get; set; }
    }
}
