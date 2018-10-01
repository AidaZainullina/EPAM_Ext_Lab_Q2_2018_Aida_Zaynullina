using KnowledgeSystem.Models.Account;
using KnowledgeSystemDAL.Repositories.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KnowledgeSystem.Controllers
{
    public class HomePageController : Controller
    {
        UserRepository userRepository = new UserRepository();

        // GET: HomePage
        public ActionResult UserInfo()
        {
            return View();
        }
    }
}