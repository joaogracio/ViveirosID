using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using System;
using ViveirosID.Models;

[assembly: OwinStartupAttribute(typeof(ViveirosID.Startup))]
namespace ViveirosID
{
    public partial class Startup
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        private void iniciaAplicacao()
        {

            //VetsDB db = new VetsDB();
            
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            // criar a Role 'Administrador'
            if (!roleManager.RoleExists("Administrador"))
            {
                // não existe a 'role'
                // então, criar essa role
                var role = new IdentityRole();
                role.Name = "Administrador";
                roleManager.Create(role);

                // criar um utilizador 'Administrador do Sistema que representa a loja'
                // Neste caso João Grácio
                var Joao_Gracio = new ApplicationUser();
                Joao_Gracio.UserName = "joao_gracio@ipt.pt";
                Joao_Gracio.Email = "joao_gracio@ipt.pt";
                // user.Nome = "Luís Freitas";
                string userPWD_Joao_Gracio = "123_Asd";
                var chkUser_Joao_Gracio = userManager.Create(Joao_Gracio, userPWD_Joao_Gracio);
                //Adicionar o Utilizador à respetiva Role-Dono-
                if (chkUser_Joao_Gracio.Succeeded)
                {
                    var result1 = userManager.AddToRole(Joao_Gracio.Id, "Administrador");
                }

                // Cria um novo Utilizador associado ao AspNetUser atraves do AspNetUser ID (string)
                // Neste caso Pedro Dias
                //
                Utilizadores Joao_Gracio_user = new Utilizadores();
                //utilizador.sexo = sexo;
                Joao_Gracio_user.nome = "João";
                Joao_Gracio_user.apelido = "Grácio";
                Joao_Gracio_user.datadenascimento = Convert.ToDateTime("21/05/1898");
                Joao_Gracio_user.NIF = Convert.ToInt32("128900337");
                Joao_Gracio_user.morada = "Rua Primeiro de Dezembro";
                Joao_Gracio_user.local = "Nossa Senhora de Fátima";
                Joao_Gracio_user.codigoposta = "2330-088";
                Joao_Gracio_user.cidade = "Entroncamento";
                Joao_Gracio_user.distrito = "Santarém";
                Joao_Gracio_user.pais = "Portugal";
                Joao_Gracio_user.telefone = "966005796";
                // Aqui relaciona-se um AspUser a um Utilizador
                //
                Joao_Gracio_user.IDaspuser = Joao_Gracio.Id;
                //utilizador.newsletter = newsletter; 
                db.Utilizador.Add(Joao_Gracio_user);
                // Cria um novo Carrinho que vai ser relacionado com o Utilizador
                // Este ira ser o Carrinho deste Utilizador (num relacionamento um para um)
                //
                Carrinhos Joao_Gracio_Carrinho = new Carrinhos();
                Joao_Gracio_Carrinho.peso = 0;
                Joao_Gracio_Carrinho.precototal = 0;
                Joao_Gracio_Carrinho.ultimaAlteracao = DateTime.Now;
                Joao_Gracio_Carrinho.Utilizador = Joao_Gracio_user;
                Joao_Gracio_Carrinho.UtilizadorFK = Joao_Gracio_user.UtilizadorID;

                db.Carrinho.Add(Joao_Gracio_Carrinho);
                db.SaveChanges();

                // Atribui o ID do carrinho ao CarrinhoFK do utilizador
                //
                Joao_Gracio_user.CarrinhoFK = Joao_Gracio_Carrinho.CarrinhoID;
            }


            // Criar a role 'Profissional'
            if (!roleManager.RoleExists("Profissional"))
            {
                var role = new IdentityRole();
                role.Name = "Profissional";
                roleManager.Create(role);

                // criar um utilizador 'Cliente da loja'
                // Neste caso Pedro Dias
                var Ana_Gois = new ApplicationUser();
                Ana_Gois.UserName = "ana_gois@ipt.pt";
                Ana_Gois.Email = "ana_gois@ipt.pt";
                // user.Nome = "Luís Freitas";
                string userPWD_Ana_Gois = "123_Asd";
                var chkUser_Ana_Gois = userManager.Create(Ana_Gois, userPWD_Ana_Gois);
                //Adicionar o Utilizador à respetiva Role-Dono-
                if (chkUser_Ana_Gois.Succeeded)
                {
                    var result1 = userManager.AddToRole(Ana_Gois.Id, "Profissional");
                }

                // Cria um novo Utilizador associado ao AspNetUser atraves do AspNetUser ID (string)
                // Neste caso Pedro Dias
                //
                Utilizadores Ana_Gois_user = new Utilizadores();
                //utilizador.sexo = sexo;
                Ana_Gois_user.nome = "Ana";
                Ana_Gois_user.apelido = "Gois";
                Ana_Gois_user.datadenascimento = Convert.ToDateTime("05/06/1977");
                Ana_Gois_user.NIF = Convert.ToInt32("128900775");
                Ana_Gois_user.morada = "Rua da Sorriso";
                Ana_Gois_user.local = "Planicie da Calma";
                Ana_Gois_user.codigoposta = "2220-033";
                Ana_Gois_user.cidade = "Tomar";
                Ana_Gois_user.distrito = "Santarém";
                Ana_Gois_user.pais = "Portugal";
                Ana_Gois_user.telefone = "960579644";
                // Aqui relaciona-se um AspUser a um Utilizador
                //
                Ana_Gois_user.IDaspuser = Ana_Gois.Id;
                //utilizador.newsletter = newsletter; 
                db.Utilizador.Add(Ana_Gois_user);
                // Cria um novo Carrinho que vai ser relacionado com o Utilizador
                // Este ira ser o Carrinho deste Utilizador (num relacionamento um para um)
                //
                Carrinhos Ana_Gois_Carrinho = new Carrinhos();
                Ana_Gois_Carrinho.peso = 0;
                Ana_Gois_Carrinho.precototal = 0;
                Ana_Gois_Carrinho.ultimaAlteracao = DateTime.Now;
                Ana_Gois_Carrinho.Utilizador = Ana_Gois_user;
                Ana_Gois_Carrinho.UtilizadorFK = Ana_Gois_user.UtilizadorID;

                db.Carrinho.Add(Ana_Gois_Carrinho);
                db.SaveChanges();

                // Atribui o ID do carrinho ao CarrinhoFK do utilizador
                //
                Ana_Gois_user.CarrinhoFK = Ana_Gois_Carrinho.CarrinhoID;
            }

            // Criar a role 'Cliente'
            if (!roleManager.RoleExists("Cliente"))
            {
                var role = new IdentityRole();
                role.Name = "Cliente";
                roleManager.Create(role);

                // criar um utilizador 'Cliente da loja'
                // Neste caso Pedro Dias
                var Pedro_Dias = new ApplicationUser();
                Pedro_Dias.UserName = "pedro_dias@ipt.pt";
                Pedro_Dias.Email = "pedro_dias@ipt.pt";
                // user.Nome = "Luís Freitas";
                string userPWD_Ped_Dias = "123_Asd";
                var chkUser_Ped_Dias = userManager.Create(Pedro_Dias, userPWD_Ped_Dias);
                //Adicionar o Utilizador à respetiva Role-Dono-
                if (chkUser_Ped_Dias.Succeeded)
                {
                    var result1 = userManager.AddToRole(Pedro_Dias.Id, "Cliente");
                }

                // Cria um novo Utilizador associado ao AspNetUser atraves do AspNetUser ID (string)
                // Neste caso Pedro Dias
                //
                Utilizadores Pedro_Dias_user = new Utilizadores();
                //utilizador.sexo = sexo;
                Pedro_Dias_user.nome = "Pedro";
                Pedro_Dias_user.apelido = "Dias";
                Pedro_Dias_user.datadenascimento = Convert.ToDateTime("05/06/1989");
                Pedro_Dias_user.NIF = Convert.ToInt32("128900778");
                Pedro_Dias_user.morada = "Rua da Alegria";
                Pedro_Dias_user.local = "Lagar do Ouro";
                Pedro_Dias_user.codigoposta = "2440-011";
                Pedro_Dias_user.cidade = "Abrantes";
                Pedro_Dias_user.distrito = "Santarém";
                Pedro_Dias_user.pais = "Portugal";
                Pedro_Dias_user.telefone = "960579600";
                // Aqui relaciona-se um AspUser a um Utilizador
                //
                Pedro_Dias_user.IDaspuser = Pedro_Dias.Id;
                //utilizador.newsletter = newsletter; 
                db.Utilizador.Add(Pedro_Dias_user);
                // Cria um novo Carrinho que vai ser relacionado com o Utilizador
                // Este ira ser o Carrinho deste Utilizador (num relacionamento um para um)
                //
                Carrinhos Pedro_Dias_Carrinho = new Carrinhos();
                Pedro_Dias_Carrinho.peso = 0;
                Pedro_Dias_Carrinho.precototal = 0;
                Pedro_Dias_Carrinho.ultimaAlteracao = DateTime.Now;
                Pedro_Dias_Carrinho.Utilizador = Pedro_Dias_user;
                Pedro_Dias_Carrinho.UtilizadorFK = Pedro_Dias_user.UtilizadorID;

                db.Carrinho.Add(Pedro_Dias_Carrinho);
                db.SaveChanges();

                // Atribui o ID do carrinho ao CarrinhoFK do utilizador
                //
                Pedro_Dias_user.CarrinhoFK = Pedro_Dias_Carrinho.CarrinhoID;


                // criar um utilizador 'Cliente da loja'
                // Neste caso Pedro Dias
                var Casimiro_Batista = new ApplicationUser();
                Casimiro_Batista.UserName = "casimiro_batista@ipt.pt";
                Casimiro_Batista.Email = "casimiro_batista@ipt.pt";
                // user.Nome = "Luís Freitas";
                string userPWD_Cas_Bas = "123_Asd";
                var chkUser_Cas_Bas = userManager.Create(Casimiro_Batista, userPWD_Cas_Bas);
                //Adicionar o Utilizador à respetiva Role-Dono-
                if (chkUser_Cas_Bas.Succeeded)
                {
                    var result1 = userManager.AddToRole(Casimiro_Batista.Id, "Cliente");
                }

                // Cria um novo Utilizador associado ao AspNetUser atraves do AspNetUser ID (string)
                // Neste caso Pedro Dias
                //
                Utilizadores Casimiro_Batista_user = new Utilizadores();
                //utilizador.sexo = sexo;
                Casimiro_Batista_user.nome = "Casimiro";
                Casimiro_Batista_user.apelido = "Batista";
                Casimiro_Batista_user.datadenascimento = Convert.ToDateTime("27/03/1977");
                Casimiro_Batista_user.NIF = Convert.ToInt32("128900777");
                Casimiro_Batista_user.morada = "Rua dos Operários";
                Casimiro_Batista_user.local = "Montanha da Força";
                Casimiro_Batista_user.codigoposta = "2330-011";
                Casimiro_Batista_user.cidade = "Coimbra";
                Casimiro_Batista_user.distrito = "Coimbra";
                Casimiro_Batista_user.pais = "Portugal";
                Casimiro_Batista_user.telefone = "960579601";
                // Aqui relaciona-se um AspUser a um Utilizador
                //
                Casimiro_Batista_user.IDaspuser = Casimiro_Batista.Id;
                //utilizador.newsletter = newsletter; 
                db.Utilizador.Add(Casimiro_Batista_user);
                // Cria um novo Carrinho que vai ser relacionado com o Utilizador
                // Este ira ser o Carrinho deste Utilizador (num relacionamento um para um)
                //
                Carrinhos Casimiro_Batista_Carrinho = new Carrinhos();
                Casimiro_Batista_Carrinho.peso = 0;
                Casimiro_Batista_Carrinho.precototal = 0;
                Casimiro_Batista_Carrinho.ultimaAlteracao = DateTime.Now;
                Casimiro_Batista_Carrinho.Utilizador = Casimiro_Batista_user;
                Casimiro_Batista_Carrinho.UtilizadorFK = Casimiro_Batista_user.UtilizadorID;

                db.Carrinho.Add(Casimiro_Batista_Carrinho);
                db.SaveChanges();

                // Atribui o ID do carrinho ao CarrinhoFK do utilizador
                //
                Casimiro_Batista_user.CarrinhoFK = Casimiro_Batista_Carrinho.CarrinhoID;


                // criar um utilizador 'Cliente da loja'
                // Neste caso Casimiro Pereira
                var Casimiro_Pereira = new ApplicationUser();
                Casimiro_Pereira.UserName = "casimiro_pereira@ipt.pt";
                Casimiro_Pereira.Email = "casimiro_pereira@ipt.pt";
                // user.Nome = "Luís Freitas";
                string userPWD_Cas_Per = "123_Asd";
                var chkUser_Cas_Per = userManager.Create(Casimiro_Pereira, userPWD_Cas_Per);
                //Adicionar o Utilizador à respetiva Role-Dono-
                if (chkUser_Cas_Bas.Succeeded)
                {
                    var result1 = userManager.AddToRole(Casimiro_Pereira.Id, "Cliente");
                }

                // Cria um novo Utilizador associado ao AspNetUser atraves do AspNetUser ID (string)
                // Neste caso Pedro Dias
                //
                Utilizadores Casimiro_Pereira_user = new Utilizadores();
                //utilizador.sexo = sexo;
                Casimiro_Pereira_user.nome = "Casimiro";
                Casimiro_Pereira_user.apelido = "Pereira";
                Casimiro_Pereira_user.datadenascimento = Convert.ToDateTime("25/04/1974");
                Casimiro_Pereira_user.NIF = Convert.ToInt32("128900776");
                Casimiro_Pereira_user.morada = "Rua do Espírito Santo";
                Casimiro_Pereira_user.local = "Nossa Senhora de Fátima";
                Casimiro_Pereira_user.codigoposta = "2220-011";
                Casimiro_Pereira_user.cidade = "Tomar";
                Casimiro_Pereira_user.distrito = "Santarém";
                Casimiro_Pereira_user.pais = "Portugal";
                Casimiro_Pereira_user.telefone = "960579602";
                // Aqui relaciona-se um AspUser a um Utilizador
                //
                Casimiro_Pereira_user.IDaspuser = Casimiro_Pereira.Id;
                //utilizador.newsletter = newsletter; 
                db.Utilizador.Add(Casimiro_Pereira_user);
                // Cria um novo Carrinho que vai ser relacionado com o Utilizador
                // Este ira ser o Carrinho deste Utilizador (num relacionamento um para um)
                //
                Carrinhos Casimiro_Pereira_Carrinho = new Carrinhos();
                Casimiro_Pereira_Carrinho.peso = 0;
                Casimiro_Pereira_Carrinho.precototal = 0;
                Casimiro_Pereira_Carrinho.ultimaAlteracao = DateTime.Now;
                Casimiro_Pereira_Carrinho.Utilizador = Casimiro_Pereira_user;
                Casimiro_Pereira_Carrinho.UtilizadorFK = Casimiro_Pereira_user.UtilizadorID;

                db.Carrinho.Add(Casimiro_Pereira_Carrinho);
                db.SaveChanges();

                // Atribui o ID do carrinho ao CarrinhoFK do utilizador
                //
                Casimiro_Pereira_user.CarrinhoFK = Casimiro_Pereira_Carrinho.CarrinhoID;


                db.SaveChanges();
            }

            // https://code.msdn.microsoft.com/ASPNET-MVC-5-Security-And-44cbdb97
        }

        public void Configuration(IAppBuilder app)
        {
            iniciaAplicacao();
            ConfigureAuth(app);
        }
    }
}
