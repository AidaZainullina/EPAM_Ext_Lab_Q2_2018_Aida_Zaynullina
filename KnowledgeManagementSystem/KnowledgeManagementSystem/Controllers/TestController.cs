namespace KnowledgeManagementSystem.Controllers
{
    using KnowledgeManagementSystem.DAL.Repositories.Test;
    using System;
    using System.Web.Mvc;
    using AutoMapper;   
    using Task10;
    using KnowledgeManagementSystem.Models;
    using System.Net;

    public class TestController : Controller
    {
        TestRepository testRep = new TestRepository();

        public ActionResult Create()
        {
            ViewBag.TestList = this.testRep.GetAll();
            return View(Mapper.Map<Test, TestCreateViewModel>(new Test()));
        }

        [HttpPost]
        public ActionResult Create(TestCreateViewModel testViewModel)
        {
            if (ModelState.IsValid)
            {
                this.testRep.Save(Mapper.Map<TestCreateViewModel, Test>(testViewModel));
                return RedirectToAction("Index");
            }
            else
            {
                return View(testViewModel);
            }
        }

        public ActionResult Edit(int id)
        {
            return this.View(Mapper.Map<Test, TestEditViewModel>(this.testRep.Get(id)));
        }


        [HttpPost]
        public ActionResult Edit(TestEditViewModel testViewModel)
        {
            if (ModelState.IsValid)
            {
                this.testRep.Save(Mapper.Map<TestEditViewModel, Test>(testViewModel));
                return RedirectToAction("List");
            }
            else
            {
                return View(testViewModel);
            }
        }

        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            testRep.Get(id);
            
            if (testRep == null)
            {
                return HttpNotFound();
            }
            return View(testRep);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            testRep.Delete(id);

            return RedirectToAction("Index");
        }

        public ActionResult GetAll()
        {
            return this.View(this.testRep.GetAll());
        }

        public ActionResult Get(int id)
        {
            return this.View(this.testRep.Get(id));
        }
    }
}