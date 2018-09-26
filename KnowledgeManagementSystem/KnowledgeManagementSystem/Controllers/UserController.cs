namespace KnowledgeManagementSystem.Controllers
{
    using AutoMapper;
    using KnowledgeManagementSystem.DAL.Repositories;
    using KnowledgeManagementSystem.DAL.Repositories.UserRole;
    using KnowledgeManagementSystem.Models;
    using System.Net;
    using System.Web.Mvc;
    using Task10;

    public class UserController : Controller
    {
        UserRepository userRepository = new UserRepository();
        RoleRepository roleRepository = new RoleRepository();

        public ActionResult Create()
        {
            ViewBag.RoleList = this.roleRepository.GetAll();
            return View(Mapper.Map<User, UserCreateViewModel>(new User()));
        }

        [HttpPost]
        public ActionResult Create(UserCreateViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                this.userRepository.Save(Mapper.Map<UserCreateViewModel, User>(userViewModel));
                return RedirectToAction("Index");
            }
            else
            {
                return View(userViewModel);
            }
        }

        public ActionResult Edit(int id)
        {
            return this.View(Mapper.Map<User, UserEditViewModel>(this.userRepository.Get(id)));
        }

        [HttpPost]
        public ActionResult Edit(UserEditViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                this.userRepository.Save(Mapper.Map<UserEditViewModel, User>(userViewModel));
                return RedirectToAction("List");
            }
            else
            {
                return View(userViewModel);
            }
        }


        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = userRepository.Get(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            userRepository.Delete(id);

            return RedirectToAction("Index");
        }

        public ActionResult GetAll()
        {
            return this.View(this.userRepository.GetAll());
        }

        public ActionResult Get(int id)
        {
            return this.View(this.userRepository.Get(id));
        }
    }
}