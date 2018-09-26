namespace KnowledgeManagementSystem.Controllers
{
    using KnowledgeManagementSystem.DAL.Repositories;
    using KnowledgeManagementSystem.Models;
    using System.Threading;
    using System.Web.Mvc;
    using System.Web.Security;
    using Task10;

    public class AccountController : Controller
    { 
        public ActionResult LogOn()
        {
            if (Thread.CurrentPrincipal.Identity.IsAuthenticated)
            {
                return this.Redirect(string.Format("/user/{0}", Thread.CurrentPrincipal.Identity.Name));
            }

            return this.View();
        }

        [HttpPost]
        public ActionResult LogOn(UserPasswordViewModel userAndPassword, string returnUrl)
        {
            UserRepository repo = new UserRepository();

            if (!string.IsNullOrEmpty(userAndPassword.Email) && !string.IsNullOrEmpty(userAndPassword.Password))
            {
                User user = repo.GetAll().Find(e => e.Email.Equals(userAndPassword.Email));
                if (user != null)
                {
                    if (user.Password.Trim(' ').Equals(userAndPassword.Password))
                    {
                        FormsAuthentication.SetAuthCookie(user.Id.ToString(), false);

                        if (returnUrl == null || returnUrl.Equals(string.Empty))
                        {
                            returnUrl = string.Format("/user/{0}", user.Id);
                        }

                        return this.Redirect(returnUrl);
                    }
                }
            }

            return this.View(userAndPassword);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return this.Redirect("~/");
        }
    }
}