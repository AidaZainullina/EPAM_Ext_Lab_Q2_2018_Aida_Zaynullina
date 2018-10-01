namespace KnowledgeManagementSystem.Controllers
{
    using KnowledgeSystem.Models.Account;
    using KnowledgeSystemDAL.Models;
    using KnowledgeSystemDAL.Repositories.User;
    using System.Web.Mvc;
    using System.Web.Security;
    

    public class AccountController : Controller
    {
        UserRepository userRepository = new UserRepository();
        
        // GET: Account
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(UserLoginModel model, string ReturnUrl)
        {
            var user = userRepository.Get(model.Name);

            if (user != null)
            {
                if (model.Password.Equals((user.Password)))
                {
                    FormsAuthentication.SetAuthCookie(model.Name, false);

                    Session["UserID"] = user.Id;

                    return RedirectToAction("Index", "Test");
                }
                else
                {
                    ModelState.AddModelError("", "There is no user with that name or password..");
                }
            }
            else
            {
                ModelState.AddModelError("", "There is no user with that name or password..");
            }
            return View(model);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterUserModel model)
        {
            var user = userRepository.Get(model.Name);

            if (user.Name == null)
            {
                if (model.Password == model.ConfirmedPassword)
                {
                    User ragistrationUser = new User();
                    
                    ragistrationUser.Name = model.Name;

                    ragistrationUser.Password = model.Password;

                    ragistrationUser.Email = model.Email;

                    ragistrationUser.Role = 2;

                    userRepository.Save(ragistrationUser);

                    FormsAuthentication.SetAuthCookie(model.Name, false);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Passwords do not match");
                }
            }
            else
            {
                ModelState.AddModelError("", "A user with this data already exists");
            }
            return View(model);
        }

        public ActionResult LogOf()
        {
            FormsAuthentication.SignOut();

            return Redirect("~/");
        }
    }
}