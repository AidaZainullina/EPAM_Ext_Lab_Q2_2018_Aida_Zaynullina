namespace KnowledgeManagementSystem.Controllers
{
    using AutoMapper;
    using KnowledgeManagementSystem.DAL.Repositories.Question;
    using KnowledgeManagementSystem.Models;
    using System.Net;
    using System.Web.Mvc;
    using Task10;

    public class QuestionController : Controller
    {
        QuestionRepository questionRepository = new QuestionRepository();
        
        [HttpPost]
        public ActionResult Create(QuestionCreateViewModel questionViewModel)
        {
            if (ModelState.IsValid)
            {
                this.questionRepository.Save(Mapper.Map<QuestionCreateViewModel, Question>(questionViewModel));
                return RedirectToAction("Index");
            }
            else
            {
                return View(questionViewModel);
            }
        }

        public ActionResult Edit(int id)
        {
            return this.View(Mapper.Map<Question, QuestionEditViewModel>(this.questionRepository.Get(id)));
        }


        [HttpPost]
        public ActionResult Edit(QuestionEditViewModel questionViewModel)
        {
            if (ModelState.IsValid)
            {
                this.questionRepository.Save(Mapper.Map<QuestionEditViewModel, Question>(questionViewModel));
                return RedirectToAction("List");
            }
            else
            {
                return View(questionViewModel);
            }
        }

        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            questionRepository.Get(id);

            if (questionRepository == null)
            {
                return HttpNotFound();
            }
            return View(questionRepository);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            questionRepository.Delete(id);

            return RedirectToAction("Index");
        }

        public ActionResult GetAll()
        {
            return this.View(this.questionRepository.GetAll());
        }

        public ActionResult Get(int id)
        {
            return this.View(this.questionRepository.Get(id));
        }
    }
}