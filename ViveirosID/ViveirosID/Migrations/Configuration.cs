namespace ViveirosID.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ViveirosID.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationDataLossAllowed = true;
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ViveirosID.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Categoria.AddOrUpdate(
                c => c.CategoriaID,
                new Categorias() { CategoriaID = 1, tipo = "Frutos" },
                new Categorias() { CategoriaID = 2, tipo = "Aromáticas"},
                new Categorias() { CategoriaID = 3, tipo = "Legumes"},
                new Categorias() { CategoriaID = 4, tipo = "Flores"}
                );

            context.Artigo.AddOrUpdate(
                a => a.ArtigoID,
                new Artigos() { ArtigoID = 1, CategoriaFK = 1, crescimento = 3, descricao = "Framboesa muito resistente. Deve ser colocada em terrenos de elevada alcalinidade.",
                                    disponibilidade = true, luz = 3, nome = "Framboesa", nometecnico = "Framboesis_radicali", peso = 15, preco = 1, rega = 2, plantacaoComeca = "Março", plantacaoAcaba = "Julho"},
                new Artigos() { ArtigoID = 2, CategoriaFK = 1, crescimento = 2, descricao = "Groselha originária da peninsula Ibérica. Adapta-se bem a climas mediterrâneos",
                                    disponibilidade = true, luz = 2, nome = "Groselha", nometecnico = "Groselhis_iberica", peso = 10, preco = 2, rega = 3, plantacaoComeca = "Abril", plantacaoAcaba = "Junho"},
                new Artigos() { ArtigoID = 3, CategoriaFK = 1, crescimento = 4, descricao = "Melancia é um fruto muito antigo natural dos paises do médio oriente.",
                                    disponibilidade = true, luz = 4, nome = "Melancia", nometecnico = "Melancia_redondis", peso = 10, preco = 1, rega = 4, plantacaoComeca = "Fevereiro", plantacaoAcaba = "Maio"},
                new Artigos() { ArtigoID = 4, CategoriaFK = 4, crescimento = 2, descricao = "Flores com pé muito alto. Florescem entre a primavera e o verão.",
                                    disponibilidade = true, luz = 4, nome = "Candelula", nometecnico = "Candelula_candelulis", peso = 10, preco = 2, rega = 3, plantacaoAcaba = "Março", plantacaoComeca = "Abril"},
                new Artigos() { ArtigoID = 5, CategoriaFK = 4, crescimento = 2, descricao = "Flor muito gentil. Com crescimento modesto.",
                                    disponibilidade = true, luz = 3, nome = "Cosmo", nometecnico = "Cosmo_cosmis", peso = 14, preco = 3, rega = 4, plantacaoComeca = "Janeiro", plantacaoAcaba = "Abril"},
                new Artigos() { ArtigoID = 6, CategoriaFK = 2, crescimento = 3, descricao = "Alecrim muito cheiroso, selvagem muito resistente ainda que necessite de água abundantemente.",
                                    disponibilidade = true, luz = 4, nome = "Alecrim", nometecnico = "Alecrinis_runderalis", peso = 16, preco = 1, rega = 4, plantacaoComeca = "Setembro", plantacaoAcaba = "Maio"},
                new Artigos() { ArtigoID = 7, CategoriaFK = 2, crescimento = 4, descricao = "Erva Aromática muito procurada pelos gatos, devido ao seu aroma e propriadades medicinais.",
                                    disponibilidade = true, luz = 3, nome = "Erva do Gato", nometecnico = "Ervas_gatis", peso = 20, preco = 1, rega = 2, plantacaoComeca = "Janeiro", plantacaoAcaba = "Junho"},
                new Artigos() { ArtigoID = 8, CategoriaFK = 3, crescimento = 4, descricao = "Arruda muito resistente. Conhecida pela planta das bruxas.",
                                    disponibilidade = true, luz = 5, nome = "Arruda", nometecnico = "Arruda_arrudis", peso = 13, preco = 2, rega = 2, plantacaoComeca = "Outubro", plantacaoAcaba = "Março"},
                new Artigos() { ArtigoID = 9, CategoriaFK = 3, crescimento = 2, descricao = "Cebola roxa com um crescimento um pouco lento. Mas com um paladar muito rico",
                                    disponibilidade = true, luz = 5, nome = "Cebola Roxa", nometecnico = "Cebola_roxis", peso = 20, preco = 2, rega = 4, plantacaoComeca = "Novembro", plantacaoAcaba = "Abril"},
                new Artigos() { ArtigoID = 10, CategoriaFK = 4, crescimento = 3, descricao = "Cebola branca com um crescimento mais acelarado",
                                    disponibilidade = true, luz = 5, nome = "Cebola Branca", nometecnico = "Cebolis_branquis", peso = 20, preco = 1, rega = 4, plantacaoComeca = "Novembro", plantacaoAcaba = "Abril"}
                );

        }
    }
}
