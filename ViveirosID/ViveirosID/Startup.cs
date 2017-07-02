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

            // criar a Role 'Veterinario'
            if (!roleManager.RoleExists("Veterinario"))
            {
                // não existe a 'role'
                // então, criar essa role
                var role = new IdentityRole();
                role.Name = "Veterinario";
                roleManager.Create(role);
            }

            // Criar a role 'Funcionario'
            if (!roleManager.RoleExists("Funcionario"))
            {
                var role = new IdentityRole();
                role.Name = "Funcionario";
                roleManager.Create(role);
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


                // criar um utilizador 'Cliente da loja'
                // Neste caso Pedro Dias
                var Casimiro_Batista = new ApplicationUser();
                Casimiro_Batista.UserName = "casimiro_batista@ipt.pt";
                Casimiro_Batista.Email = "casimiro_batista@ipt.pt";
                // user.Nome = "Luís Freitas";
                string userPWD_Cas_Bas = "123_Asd";
                var chkUser_Cas_Bas = userManager.Create(Pedro_Dias, userPWD_Cas_Bas);
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

                db.SaveChanges();
            }

            // https://code.msdn.microsoft.com/ASPNET-MVC-5-Security-And-44cbdb97
        }

        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
