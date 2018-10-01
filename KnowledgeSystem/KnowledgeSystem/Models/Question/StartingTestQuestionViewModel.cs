using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KnowledgeSystem.Models.Variant;

namespace KnowledgeSystem.Models.Question
{
    public class StartingTestQuestionViewModel
    {
        public List<QuestionViewModel> Question { get; set; } = new List<QuestionViewModel>();
        public List<VariantViewModel> Variants { get; set; } = new List<VariantViewModel>();
        public List<string> UserVatiants { get; set; }
        public QuestionPageInformation QuestionPageInformation { get; set; }
    }
}