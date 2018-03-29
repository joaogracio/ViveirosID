        [Key]
        public int CuponsID { get; set; }
        public string codigo { get; set; }
        public string descricao { get; set; }
        public DateTime dataLimite { get; set; }

        // Um Artigo tem uma lista de Compras
        public virtual ICollection<CuponsArtigos> ListaDeCuponsArtigos { get; set; }
       
    }
}