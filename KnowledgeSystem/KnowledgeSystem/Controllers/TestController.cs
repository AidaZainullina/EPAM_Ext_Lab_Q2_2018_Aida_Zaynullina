using KnowledgeSystemDAL.Repositories.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KnowledgeSystemDAL.Repositories.Question;
using AutoMapper;
using KnowledgeSystem.Models.Test;
using KnowledgeSystem.Models.Page;
using KnowledgeSystem.Models.Question;
using KnowledgeSystem.Models.Variant;
using KnowledgeSystemDAL.Repositories.Variant;

namespace KnowledgeSystem.Controllers
{
    public class TestController : Controller
    {
        // GET: Test

        TestRepository testRepository = new TestRepository();
        QuestionRepository questionRepository = new QuestionRepository();
        VariantRepository variantRepository = new VariantRepository();

        // GET: Test
        
        public ActionResult Index(int page = 1)
        {

            ViewBag.User = User.Identity.Name;
            int pageSize = testRepository.GetCount();
            var testsPerPages = testRepository.GetAllByUserID((int)Session["UserID"]);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<KnowledgeSystemDAL.Models.Test, IndexTestViewModel>());
            var mapper = config.CreateMapper();
            var tests = mapper.Map<List<KnowledgeSystemDAL.Models.Test>, IEnumerable<TestViewModel>>(testsPerPages);

            var pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = testRepository.GetCount() };
            var ivm = new IndexViewModel { PageInfo = pageInfo, Tests = tests };
  
            return View(ivm);
        }

        
        public ActionResult PreStartingTest(int Id)
        {
            return RedirectToAction("TestStart", new { Id });
        }
        
        public ActionResult TestStarting(int testId, int questionId = 1)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<KnowledgeSystemDAL.Models.Question, StartingTestQuestionViewModel>());
            var mapper = config.CreateMapper();
            List<QuestionViewModel> questions = new List<QuestionViewModel>();
            foreach (var item in questionRepository.GetAllQuestionByTestId(testId))
            {
                QuestionViewModel questionViewModel = new QuestionViewModel();

                questionViewModel.Id = item.Id;
                questionViewModel.Text = item.Text;
                questionViewModel.TestID = item.TestID;

                questions.Add(questionViewModel);
            }

            List<VariantViewModel> variants = new List<VariantViewModel>();
            foreach (var item in variantRepository.GetAllByQuestionId(questionId))
            {
                VariantViewModel variant = new VariantViewModel();
                variant.Id = item.Id;
                variant.Text = item.Text;
                variant.IsRight = item.IsRight;
                variant.QuestionId = item.QuestionId;

                variants.Add(variant);
            }
            variants.Count();
            var pageInfo = new QuestionPageInformation { TestId = testId, QuestionId = questionId, TotalPages = questionRepository.GetAllQuestionByTestId(testId).Count };
            var startingQuestionViewModel = new StartingTestQuestionViewModel { QuestionPageInformation = pageInfo, Question = questions, Variants = variants };

            
            return View(startingQuestionViewModel);
        }
        
        public ActionResult TestCheckAnswer()
        {

            return View();
        }
        
        public ActionResult TestResult()
        {
            return View();
        }
    }
}