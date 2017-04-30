using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Viveiros.Models;
using System.Text.RegularExpressions;
using ViveirosID;
using ViveirosID.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ViveirosID.Controllers {

    [Authorize]
    public class AccountController : Controller {

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private ApplicationDbContext db = new ApplicationDbContext();

        public AccountController() {
        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager) {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager {
            get {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager {
            get {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set {
                _userManager = value;
            }
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl) {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl) {
            if (!ModelState.IsValid) {
                return View(model);
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
            switch (result) {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
            }
        }

        //
        // GET: /Account/VerifyCode
        [AllowAnonymous]
        public async Task<ActionResult> VerifyCode(string provider, string returnUrl, bool rememberMe) {
            // Require that the user has already logged in via username/password or external login
            if (!await SignInManager.HasBeenVerifiedAsync()) {
                return View("Error");
            }
            return View(new VerifyCodeViewModel { Provider = provider, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/VerifyCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VerifyCode(VerifyCodeViewModel model) {
            if (!ModelState.IsValid) {
                return View(model);
            }

            // The following code protects for brute force attacks against the two factor codes. 
            // If a user enters incorrect codes for a specified amount of time then the user account 
            // will be locked out for a specified amount of time. 
            // You can configure the account lockout settings in IdentityConfig
            var result = await SignInManager.TwoFactorSignInAsync(model.Provider, model.Code, isPersistent: model.RememberMe, rememberBrowser: model.RememberBrowser);
            switch (result) {
                case SignInStatus.Success:
                    return RedirectToLocal(model.ReturnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid code.");
                    return View(model);
            }
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register() {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model, string nome, string apelido, string datadenascimento, string email, string NIF, string morada, string local, string codigoposta, string cidade, string distrito, string pais, string telefone /*,Boolean newsletter*/) {
            // Variavel Booleana no sentido de determinar todos os valores passam na filtragem das expressoes regulares
            // 
            Boolean regex_reject = false;

            // Expressoes Regulares para averiguar a validade das entradas
            //
            String reg_nome = "([A-Z][a-zãáéíõç]{3,11})[ ]?";
            String reg_apelido = "([A-Z][a-zãáéíõç]{3,11})[ ]?";
            String reg_datadenascimento = "^([0-9]{4}[-/]?((0[13-9]|1[012])[-/]?(0[1-9]|[12][0-9]|30)|(0[13578]|1[02])[-/]?31|02[-/]?(0[1-9]|1[0-9]|2[0-8]))|([0-9]{2}(([2468][048]|[02468][48])|[13579][26])|([13579][26]|[02468][048]|0[0-9]|1[0-6])00)[-/]?02[-/]?29)$";
            String reg_email = "";
            String reg_NIF = "([0-9]{9})";
            String reg_morada = "([R][u][a]|[E][s][t][r][a][d][a]|[A][v][e][n][i][d][a])[ ]?([A-Z][a-zãáéíõç]{3,11})[ ]?([A-Z][a-zãáéõç]{3,11}|[d][eo][s]?)?[ ]?([A-Z][a-zãáéõç]{3,11}|[d][eo][s]?)?[ ]?([A-Z][a-zãáéõç]{3,11}|[d][eo][s]?)?[ ]?";
            String reg_local = "";
            String reg_codigoposta = "([0-9]{4})-([0-9]{3})";
            String reg_cidade = "([A-Z][a-zãáéíõç]{3,11})[ ]?";
            String reg_distrito = "([A-Z][a-zãáéíõç]{3,11})[ ]?";
            String reg_pais = "([A-Z][a-zãáéíõç]{3,11})[ ]?";
            String reg_telefone = "([29][0-9]{8})";

            // Verifica cada uma das entradas atraves das expressoes regulares acima declaradas
            //
            if (!Regex.IsMatch(nome, reg_nome)) {
                ModelState.AddModelError("nome", "Introduza apenas um nome. Este nome deve começar por maiuscula, não pode usar números e tem que ter no máximo 11 caracteres.");
                // o nome nao pode ser nulo
                regex_reject = true;
            }
            if (!Regex.IsMatch(apelido, reg_apelido)) {
                ModelState.AddModelError("apelido", "Introduza apenas um apelido. Este nome deve começar por maiuscula, não pode usar números e tem que ter no máximo 11 caracteres.");
                regex_reject = true;
            }
            if (!Regex.IsMatch(datadenascimento, reg_datadenascimento)) {
                ModelState.AddModelError("datadenascimento", "Introduza a data de nascimento no seguinte formato: 1987-05-21. Ano, mes, dia. Separado por ifen - .");
                regex_reject = true;
            }
            if (!Regex.IsMatch(email, reg_email)) {
                ModelState.AddModelError("email", "");
                regex_reject = true;
            }
            if (!Regex.IsMatch(NIF, reg_NIF)) {
                ModelState.AddModelError("NIF", "Introduza o seu número de contribuinte usando apenas números, use 9 números.");
                regex_reject = true;
            }
            if (!Regex.IsMatch(morada, reg_morada)) {
                ModelState.AddModelError("morada", "Introduza a sua morada começando com uma de três palavras: Rua, Avenida, Estrada. Continue usando palvaras começadas por maiuscula. Pode usar tambem: de, do, dos.");
                regex_reject = true;
            }
            if (!Regex.IsMatch(local, reg_local)) {
                ModelState.AddModelError("local", "");
                regex_reject = true;
            }
            if (!Regex.IsMatch(codigoposta, reg_codigoposta)) {
                ModelState.AddModelError("codigoposta", "Introduza o seu código postal através de 4 números seperados por um ifen - . Exemplo: 2330-088");
                regex_reject = true;
            }
            if (!Regex.IsMatch(cidade, reg_cidade)) {
                ModelState.AddModelError("cidade", "Introduza a sua cidade usando apenas caracteres o primeiro caracter deve ser uma maiuscula, e os seguintes minusculas não use números.");
                regex_reject = true;
            }
            if (!Regex.IsMatch(distrito, reg_distrito)) {
                ModelState.AddModelError("distrito", "Introduza o seu distrito usando apenas caracteres o primeiro caracter deve ser uma maiuscula, e os seguintes minusculas não use números.");
                regex_reject = true;
            }
            if (!Regex.IsMatch(pais, reg_pais)) {
                ModelState.AddModelError("pais", "Introduza o seu pais usando apenas caracteres o primeiro caracter deve ser uma maiuscula, e os seguintes minusculas não use números.");
                regex_reject = true;
            }
            if (!Regex.IsMatch(telefone, reg_telefone)) {
                ModelState.AddModelError("telefone", "Introduza o seu telefone usando apenas digitos comece o seu número por 2 ou 9.");
                regex_reject = true;
            }

            // Se todas as expressoes regulares para os valores associados ao novo utilizador estao correctas avança
            //
            if (!regex_reject) {

                // Verifica se o modelo AspNetUser é válido
                //
                if (ModelState.IsValid) {

                    var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                    var result = await UserManager.CreateAsync(user, model.Password);
                    if (result.Succeeded) {

                        var roleresult = UserManager.AddToRole(user.Id, "Cliente");

                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                        // Cria um novo Utilizador associado ao AspNetUser atraves do AspNetUser ID (string)
                        //
                        Utilizadores utilizador = new Utilizadores();
                        //utilizador.sexo = sexo;
                        utilizador.nome = nome;
                        utilizador.apelido = apelido;
                        utilizador.datadenascimento = Convert.ToDateTime(datadenascimento);
                        utilizador.NIF = Convert.ToInt32(NIF);
                        utilizador.morada = morada;
                        utilizador.local = local;
                        utilizador.codigoposta = codigoposta;
                        utilizador.cidade = cidade;
                        utilizador.distrito = distrito;
                        utilizador.pais = pais;
                        utilizador.telefone = telefone;
                        // Aqui relaciona-se um AspUser a um Utilizador
                        //
                        utilizador.IDaspuser = user.Id;
                        //utilizador.newsletter = newsletter; 
                        db.Utilizador.Add(utilizador);
                        db.SaveChanges();

                        // Cria um novo Carrinho que vai ser relacionado com o Utilizador
                        // Este ira ser o Carrinho deste Utilizador (num relacionamento um para um)
                        //
                        Carrinhos carrinho = new Carrinhos();
                        carrinho.peso = 0;
                        carrinho.preçototal = 0;
                        carrinho.ultimaAlteracao = DateTime.Now;
                        carrinho.UtilizadorFK = utilizador.UtilizadorID;

                        db.Carrinho.Add(carrinho);
                        db.SaveChanges();

                        // Atribui o ID do carrinho ao CarrinhoFK do utilizador
                        //
                        utilizador.CarrinhoFK = carrinho.CarrinhoID;
                        db.SaveChanges();

                        return RedirectToAction("Index", "Home");
                    }
                    AddErrors(result);
                }
            }
            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ConfirmEmail
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string userId, string code) {
            if (userId == null || code == null) {
                return View("Error");
            }
            var result = await UserManager.ConfirmEmailAsync(userId, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        //
        // GET: /Account/ForgotPassword
        [AllowAnonymous]
        public ActionResult ForgotPassword() {
            return View();
        }

        //
        // POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model) {
            if (ModelState.IsValid) {
                var user = await UserManager.FindByNameAsync(model.Email);
                if (user == null || !(await UserManager.IsEmailConfirmedAsync(user.Id))) {
                    // Don't reveal that the user does not exist or is not confirmed
                    return View("ForgotPasswordConfirmation");
                }

                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                // Send an email with this link
                // string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                // var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);		
                // await UserManager.SendEmailAsync(user.Id, "Reset Password", "Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>");
                // return RedirectToAction("ForgotPasswordConfirmation", "Account");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ForgotPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation() {
            return View();
        }

        //
        // GET: /Account/ResetPassword
        [AllowAnonymous]
        public ActionResult ResetPassword(string code) {
            return code == null ? View("Error") : View();
        }

        //
        // POST: /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model) {
            if (!ModelState.IsValid) {
                return View(model);
            }
            var user = await UserManager.FindByNameAsync(model.Email);
            if (user == null) {
                // Don't reveal that the user does not exist
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            var result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
            if (result.Succeeded) {
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            AddErrors(result);
            return View();
        }

        //
        // GET: /Account/ResetPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation() {
            return View();
        }

        //
        // POST: /Account/ExternalLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl) {
            // Request a redirect to the external login provider
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        }

        //
        // GET: /Account/SendCode
        [AllowAnonymous]
        public async Task<ActionResult> SendCode(string returnUrl, bool rememberMe) {
            var userId = await SignInManager.GetVerifiedUserIdAsync();
            if (userId == null) {
                return View("Error");
            }
            var userFactors = await UserManager.GetValidTwoFactorProvidersAsync(userId);
            var factorOptions = userFactors.Select(purpose => new SelectListItem { Text = purpose, Value = purpose }).ToList();
            return View(new SendCodeViewModel { Providers = factorOptions, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/SendCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendCode(SendCodeViewModel model) {
            if (!ModelState.IsValid) {
                return View();
            }

            // Generate the token and send it
            if (!await SignInManager.SendTwoFactorCodeAsync(model.SelectedProvider)) {
                return View("Error");
            }
            return RedirectToAction("VerifyCode", new { Provider = model.SelectedProvider, ReturnUrl = model.ReturnUrl, RememberMe = model.RememberMe });
        }

        //
        // GET: /Account/ExternalLoginCallback
        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginCallback(string returnUrl) {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
            if (loginInfo == null) {
                return RedirectToAction("Login");
            }

            // Sign in the user with this external login provider if the user already has a login
            var result = await SignInManager.ExternalSignInAsync(loginInfo, isPersistent: false);
            switch (result) {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = false });
                case SignInStatus.Failure:
                default:
                    // If the user does not have an account, then prompt the user to create an account
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
                    return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = loginInfo.Email });
            }
        }

        //
        // POST: /Account/ExternalLoginConfirmation
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl) {
            if (User.Identity.IsAuthenticated) {
                return RedirectToAction("Index", "Manage");
            }

            if (ModelState.IsValid) {
                // Get the information about the user from the external login provider
                var info = await AuthenticationManager.GetExternalLoginInfoAsync();
                if (info == null) {
                    return View("ExternalLoginFailure");
                }
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user);
                if (result.Succeeded) {
                    result = await UserManager.AddLoginAsync(user.Id, info.Login);
                    if (result.Succeeded) {
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                        return RedirectToLocal(returnUrl);
                    }
                }
                AddErrors(result);
            }

            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff() {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/ExternalLoginFailure
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure() {
            return View();
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                if (_userManager != null) {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null) {
                    _signInManager.Dispose();
                    _signInManager = null;
                }
            }

            base.Dispose(disposing);
        }

        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager {
            get {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result) {
            foreach (var error in result.Errors) {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl) {
            if (Url.IsLocalUrl(returnUrl)) {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null) {
            }

            public ChallengeResult(string provider, string redirectUri, string userId) {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context) {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null) {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion
    }
}