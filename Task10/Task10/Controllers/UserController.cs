using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Task10.Models;

namespace Task10.Controllers
{
    public class UserController : Controller
    {
        //IBaseRepository<UserModel> repo;



        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [Authorize(Roles = "Admin")]
        public ActionResult EditUser(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Mapper.Initialize(cfg => cfg.CreateMap<UserModel, EditUserViewModel>()
                .ForMember("Login", opt => opt.MapFrom(src => src.Email)));

            EditUserViewModel user = Mapper.Map<UserModel, EditUserViewModel>(repo.Get(id.Value));

            return View(user);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return HttpNotFound();
            // Настройка AutoMapper
            Mapper.Initialize(cfg => cfg.CreateMap<UserModel, EditUserViewModel>()
                    .ForMember("Login", opt => opt.MapFrom(src => src.Email)));
            // Выполняем сопоставление
            EditUserViewModel user = Mapper.Map<UserModel, EditUserViewModel>(repo.Get(id.Value));
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Настройка AutoMapper
                Mapper.Initialize(cfg => cfg.CreateMap<EditUserViewModel, UserModel>()
                    .ForMember("Email", opt => opt.MapFrom(src => src.Name)));
                // Выполняем сопоставление
                UserModel user = Mapper.Map<EditUserViewModel, UserModel>(model);
                repo.Update(user);
                repo.Save();
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
