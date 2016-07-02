namespace ViveirosID.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            /*
            CreateTable(
                "dbo.Artigos",
                c => new
                    {
                        ArtigoID = c.Int(nullable: false, identity: true),
                        nome = c.String(nullable: false),
                        nometecnico = c.String(),
                        disponibilidade = c.Boolean(nullable: false),
                        descricao = c.String(),
                        plantacaoComeca = c.String(),
                        plantacaoAcaba = c.String(),
                        peso = c.Single(nullable: false),
                        crescimento = c.String(),
                        Luz = c.String(),
                        Rega = c.String(),
                        preço = c.Double(nullable: false),
                        CategoriaFK = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ArtigoID)
                .ForeignKey("dbo.Categorias", t => t.CategoriaFK, cascadeDelete: true)
                .Index(t => t.CategoriaFK);
            
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        CategoriaID = c.Int(nullable: false, identity: true),
                        tipo = c.String(),
                    })
                .PrimaryKey(t => t.CategoriaID);
            
            CreateTable(
                "dbo.CarrinhoArtigoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        quantidade = c.Int(nullable: false),
                        ArtigoFK = c.Int(nullable: false),
                        CarrinhoFK = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Artigos", t => t.ArtigoFK, cascadeDelete: true)
                .ForeignKey("dbo.Carrinhos", t => t.CarrinhoFK, cascadeDelete: true)
                .Index(t => t.ArtigoFK)
                .Index(t => t.CarrinhoFK);
            
            CreateTable(
                "dbo.Carrinhos",
                c => new
                    {
                        CarrinhoID = c.Int(nullable: false, identity: true),
                        preçototal = c.Double(nullable: false),
                        ultimaAlteracao = c.DateTime(nullable: false),
                        peso = c.Single(nullable: false),
                        UtilizadorFK = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CarrinhoID)
                .ForeignKey("dbo.Utilizadores", t => t.UtilizadorFK, cascadeDelete: true)
                .Index(t => t.UtilizadorFK);
            
            CreateTable(
                "dbo.Utilizadores",
                c => new
                    {
                        UtilizadorID = c.Int(nullable: false, identity: true),
                        nome = c.String(nullable: false),
                        apelido = c.String(nullable: false),
                        datadenascimento = c.DateTime(nullable: false),
                        NIF = c.Int(nullable: false),
                        morada = c.String(nullable: false),
                        local = c.String(nullable: false),
                        codigoposta = c.String(nullable: false),
                        cidade = c.String(nullable: false),
                        distrito = c.String(nullable: false),
                        pais = c.String(nullable: false),
                        telefone = c.String(nullable: false),
                        CarrinhoFK = c.Int(nullable: false),
                        IDaspuser = c.String(),
                    })
                .PrimaryKey(t => t.UtilizadorID);
            
            CreateTable(
                "dbo.UtilizadorCompras",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UtilizadorFK = c.Int(nullable: false),
                        CompraFK = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Compras", t => t.CompraFK, cascadeDelete: true)
                .ForeignKey("dbo.Utilizadores", t => t.UtilizadorFK, cascadeDelete: true)
                .Index(t => t.UtilizadorFK)
                .Index(t => t.CompraFK);
            
            CreateTable(
                "dbo.Compras",
                c => new
                    {
                        CompraID = c.Int(nullable: false, identity: true),
                        metodoentrega = c.String(),
                        metodopagamento = c.String(),
                        estado = c.String(),
                        data = c.DateTime(nullable: false),
                        precototal = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.CompraID);
            
            CreateTable(
                "dbo.CompraArtigoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        quantidade = c.Int(nullable: false),
                        preço = c.Double(nullable: false),
                        IVA = c.Int(nullable: false),
                        ArtigoFK = c.Int(nullable: false),
                        CompraFK = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Artigos", t => t.ArtigoFK, cascadeDelete: true)
                .ForeignKey("dbo.Compras", t => t.CompraFK, cascadeDelete: true)
                .Index(t => t.ArtigoFK)
                .Index(t => t.CompraFK);
            
            CreateTable(
                "dbo.Imagens",
                c => new
                    {
                        ImagemID = c.Int(nullable: false, identity: true),
                        nome = c.String(),
                        directorio = c.String(),
                        descricao = c.String(),
                        tipo = c.String(),
                        ArtigoFK = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ImagemID)
                .ForeignKey("dbo.Artigos", t => t.ArtigoFK, cascadeDelete: true)
                .Index(t => t.ArtigoFK);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        IDutilizador = c.Int(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            */
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Imagens", "ArtigoFK", "dbo.Artigos");
            DropForeignKey("dbo.CarrinhoArtigoes", "CarrinhoFK", "dbo.Carrinhos");
            DropForeignKey("dbo.Carrinhos", "UtilizadorFK", "dbo.Utilizadores");
            DropForeignKey("dbo.UtilizadorCompras", "UtilizadorFK", "dbo.Utilizadores");
            DropForeignKey("dbo.UtilizadorCompras", "CompraFK", "dbo.Compras");
            DropForeignKey("dbo.CompraArtigoes", "CompraFK", "dbo.Compras");
            DropForeignKey("dbo.CompraArtigoes", "ArtigoFK", "dbo.Artigos");
            DropForeignKey("dbo.CarrinhoArtigoes", "ArtigoFK", "dbo.Artigos");
            DropForeignKey("dbo.Artigos", "CategoriaFK", "dbo.Categorias");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Imagens", new[] { "ArtigoFK" });
            DropIndex("dbo.CompraArtigoes", new[] { "CompraFK" });
            DropIndex("dbo.CompraArtigoes", new[] { "ArtigoFK" });
            DropIndex("dbo.UtilizadorCompras", new[] { "CompraFK" });
            DropIndex("dbo.UtilizadorCompras", new[] { "UtilizadorFK" });
            DropIndex("dbo.Carrinhos", new[] { "UtilizadorFK" });
            DropIndex("dbo.CarrinhoArtigoes", new[] { "CarrinhoFK" });
            DropIndex("dbo.CarrinhoArtigoes", new[] { "ArtigoFK" });
            DropIndex("dbo.Artigos", new[] { "CategoriaFK" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Imagens");
            DropTable("dbo.CompraArtigoes");
            DropTable("dbo.Compras");
            DropTable("dbo.UtilizadorCompras");
            DropTable("dbo.Utilizadores");
            DropTable("dbo.Carrinhos");
            DropTable("dbo.CarrinhoArtigoes");
            DropTable("dbo.Categorias");
            DropTable("dbo.Artigos");
        }
    }
}
