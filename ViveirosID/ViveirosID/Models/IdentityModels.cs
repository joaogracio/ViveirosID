using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace ViveirosID.Models {
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser {

        //nova coluna na tabela AspUSers
        public int IDutilizador { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager) {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser> {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false) {
        }

        public static ApplicationDbContext Create() {
            return new ApplicationDbContext();
        }

        // Instrucoes para criar a tabela dentro da base de dados
        public virtual DbSet<Utilizadores> Utilizador { get; set; }
        public virtual DbSet<Compras> Compra { get; set; }
        public virtual DbSet<Artigos> Artigo { get; set; }
        public virtual DbSet<CompraArtigo> Compra_Artigos { get; set; }
        public virtual DbSet<Carrinhos> Carrinho { get; set; }
        public virtual DbSet<CarrinhoArtigo> Carrinho_Artigos { get; set; }
        public virtual DbSet<Imagens> Imagem { get; set; }
        public virtual DbSet<Categorias> Categoria { get; set; }

        public System.Data.Entity.DbSet<ViveirosID.Models.ContentViewModel> ContentViewModels { get; set; }
    }

    //class UtilizadorMap : EntityTypeConfiguration<Utilizador> {
    //    public UtilizadorMap() {
    //        this.HasKey(c => c.UtilizadorID);
    //        this.Property(c => c.UtilizadorID)
    //            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
    //        this.HasRequired(c1 => c1.Carrinho).WithRequiredPrincipal(c2 => c2.Utilizador);
    //    }
    //}
}