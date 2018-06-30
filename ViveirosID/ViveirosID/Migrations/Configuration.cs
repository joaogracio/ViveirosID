namespace ViveirosID.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
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
                new Categorias() { CategoriaID = 1, Tipo = "Frutos" },
                new Categorias() { CategoriaID = 2, Tipo = "Aromáticas" },
                new Categorias() { CategoriaID = 3, Tipo = "Legumes" },
                new Categorias() { CategoriaID = 4, Tipo = "Flores" }
                );

            context.Artigo.AddOrUpdate(
                a => a.ArtigoID,
                new Artigos()
                {
                    ArtigoID = 1,
                    CategoriaFK = 1,
                    Crescimento = 3,
                    Descricao = "Framboesa muito resistente. Deve ser colocada em terrenos de elevada alcalinidade.",
                    Disponibilidade = true,
                    Luz = 3,
                    Nome = "Framboesa",
                    Nometecnico = "Framboesis_radicali",
                    Peso = 15,
                    Preco = 1,
                    Rega = 2,
                    PlantacaoComeca = "Março",
                    PlantacaoAcaba = "Julho"
                },

                new Artigos()
                {
                    ArtigoID = 2,
                    CategoriaFK = 1,
                    Crescimento = 2,
                    Descricao = "Groselha originária da peninsula Ibérica. Adapta-se bem a climas mediterrâneos",
                    Disponibilidade = true,
                    Luz = 2,
                    Nome = "Groselha",
                    Nometecnico = "Groselhis_iberica",
                    Peso = 10,
                    Preco = 2,
                    Rega = 3,
                    PlantacaoComeca = "Abril",
                    PlantacaoAcaba = "Junho"
                },

                new Artigos()
                {
                    ArtigoID = 3,
                    CategoriaFK = 1,
                    Crescimento = 4,
                    Descricao = "Melancia é um fruto muito antigo natural dos paises do médio oriente.",
                    Disponibilidade = true,
                    Luz = 4,
                    Nome = "Melancia",
                    Nometecnico = "Melancia_redondis",
                    Peso = 10,
                    Preco = 1,
                    Rega = 4,
                    PlantacaoComeca = "Fevereiro",
                    PlantacaoAcaba = "Maio"
                },

                new Artigos()
                {
                    ArtigoID = 4,
                    CategoriaFK = 4,
                    Crescimento = 2,
                    Descricao = "Flores com pé muito alto. Florescem entre a primavera e o verão.",
                    Disponibilidade = true,
                    Luz = 4,
                    Nome = "Candelula",
                    Nometecnico = "Candelula_candelulis",
                    Peso = 10,
                    Preco = 2,
                    Rega = 3,
                    PlantacaoAcaba = "Março",
                    PlantacaoComeca = "Abril"
                },

                new Artigos()
                {
                    ArtigoID = 5,
                    CategoriaFK = 4,
                    Crescimento = 2,
                    Descricao = "Flor muito gentil. Com Crescimento modesto.",
                    Disponibilidade = true,
                    Luz = 3,
                    Nome = "Cosmo",
                    Nometecnico = "Cosmo_cosmis",
                    Peso = 14,
                    Preco = 3,
                    Rega = 4,
                    PlantacaoComeca = "Janeiro",
                    PlantacaoAcaba = "Abril"
                },

                new Artigos()
                {
                    ArtigoID = 6,
                    CategoriaFK = 2,
                    Crescimento = 3,
                    Descricao = "Alecrim muito cheiroso, selvagem muito resistente ainda que necessite de água abundantemente.",
                    Disponibilidade = true,
                    Luz = 4,
                    Nome = "Alecrim",
                    Nometecnico = "Alecrinis_runderalis",
                    Peso = 16,
                    Preco = 1,
                    Rega = 4,
                    PlantacaoComeca = "Setembro",
                    PlantacaoAcaba = "Maio"
                },

                new Artigos()
                {
                    ArtigoID = 7,
                    CategoriaFK = 2,
                    Crescimento = 4,
                    Descricao = "Erva Aromática muito procurada pelos gatos, devido ao seu aroma e propriadades medicinais.",
                    Disponibilidade = true,
                    Luz = 3,
                    Nome = "Erva_do_Gato",
                    Nometecnico = "Ervas_gatis",
                    Peso = 20,
                    Preco = 1,
                    Rega = 2,
                    PlantacaoComeca = "Janeiro",
                    PlantacaoAcaba = "Junho"
                },

                new Artigos()
                {
                    ArtigoID = 8,
                    CategoriaFK = 3,
                    Crescimento = 4,
                    Descricao = "Arruda muito resistente. Conhecida pela planta das bruxas.",
                    Disponibilidade = true,
                    Luz = 5,
                    Nome = "Arruda",
                    Nometecnico = "Arruda_arrudis",
                    Peso = 13,
                    Preco = 2,
                    Rega = 2,
                    PlantacaoComeca = "Outubro",
                    PlantacaoAcaba = "Março"
                },

                new Artigos()
                {
                    ArtigoID = 9,
                    CategoriaFK = 3,
                    Crescimento = 2,
                    Descricao = "Cebola roxa com um Crescimento um pouco lento. Mas com um paladar muito rico",
                    Disponibilidade = true,
                    Luz = 5,
                    Nome = "Cebola_Roxa",
                    Nometecnico = "Cebola_roxis",
                    Peso = 20,
                    Preco = 2,
                    Rega = 4,
                    PlantacaoComeca = "Novembro",
                    PlantacaoAcaba = "Abril"
                },

                new Artigos()
                {
                    ArtigoID = 10,
                    CategoriaFK = 4,
                    Crescimento = 3,
                    Descricao = "Cebola branca com um Crescimento mais acelarado",
                    Disponibilidade = true,
                    Luz = 5,
                    Nome = "Cebola_Branca",
                    Nometecnico = "Cebolis_branquis",
                    Peso = 20,
                    Preco = 1,
                    Rega = 4,
                    PlantacaoComeca = "Novembro",
                    PlantacaoAcaba = "Abril"
                }
                );

            context.Imagem.AddOrUpdate(
                a => a.ImagemID,
                    new Imagens() { ImagemID = 1, Nome = "Alecrim", Directorio = "Alecrim_1.jpeg", Descricao = "", ArtigoFK = 4 },
                    new Imagens() { ImagemID = 2, Nome = "Arruda", Directorio = "Arruda_1.jpeg", Descricao = "", ArtigoFK = 6 },
                    new Imagens() { ImagemID = 3, Nome = "Candelula", Directorio = "Candelula_1.jpeg", Descricao = "Foto equivocada!...", ArtigoFK = 8 },
                    new Imagens() { ImagemID = 4, Nome = "Cebola_Branca", Directorio = "Cebola_Branca_1.jpeg", Descricao = "", ArtigoFK = 10 },
                    new Imagens() { ImagemID = 5, Nome = "Cebola_Roxa", Directorio = "Cebola_Roxa_1.jpeg", Descricao = "", ArtigoFK = 7 },
                    new Imagens() { ImagemID = 6, Nome = "Cosmo", Directorio = "Cebola_Roxa_1.jpeg", Descricao = "", ArtigoFK = 9 },
                    new Imagens() { ImagemID = 7, Nome = "Erva_do_Gato", Directorio = "Erva_do_Gato_1.jpeg", Descricao = "", ArtigoFK = 5 },
                    new Imagens() { ImagemID = 8, Nome = "Framboesa", Directorio = "Framboesa_1.jpeg", Descricao = "", ArtigoFK = 1 },
                    new Imagens() { ImagemID = 9, Nome = "Groselha", Directorio = "Groselha_1.jpeg", Descricao = "", ArtigoFK = 2 },
                    new Imagens() { ImagemID = 10, Nome = "Melancia", Directorio = "Melancia_1.jpeg", Descricao = "", ArtigoFK = 3 }
            );

        }
    }
}


























