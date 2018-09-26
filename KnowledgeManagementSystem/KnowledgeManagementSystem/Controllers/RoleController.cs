namespace KnowledgeManagementSystem.Controllers
{
    using AutoMapper;
    using KnowledgeManagementSystem.DAL.Repositories.UserRole;
    using KnowledgeManagementSystem.Models.Role;
    using System.Collections.Generic;
    using System.Net;
    using System.Web.Mvc;
    using Task10;

    public class RoleController : Controller
    {
        RoleRepository roleRepository = new RoleRepository();

        public ActionResult GetAllRoles()
        {
            RoleRepository roleRepository = new RoleRepository();

            List<Role> roles = roleRepository.GetAll();
            if (roles != null)
            {
                return this.View(roles);
            }

            return this.View(new List<Role>());
        }

        public ActionResult GetRoleById(int id)
        {
            Role roles = roleRepository.Get(id);
            if (roles != null)
            {
                return this.View(roles);
            }

            return this.View(new Role());
        }

        public ActionResult Edit(int id)
        {
            return this.View(Mapper.Map<Role, RoleEditViewModel>(this.roleRepository.Get(id)));
        }

        [HttpPost]
        public ActionResult Edit(RoleEditViewModel roleViewModel)
        {
            if (ModelState.IsValid)
            {
                this.roleRepository.Save(Mapper.Map<RoleEditViewModel, Role>(roleViewModel));
                return RedirectToAction("List");
            }
            else
            {
                return View(roleViewModel);
            }
        }
        //public ActionResult DeleteRoleById(int id)
        //{
        //    RoleRepository roleRepo = new RoleRepository();

        //    roleRepo.Delete(id);

        //    return this.View(roleRepo);
        //}

        public ActionResult Delete(int id)
        {
            RoleRepository roleRepository = new RoleRepository();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Role role = roleRepository.Get(id);

            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RoleRepository roleRepository = new RoleRepository();
            roleRepository.Delete(id);

            return RedirectToAction("Index");
        }

    }
}