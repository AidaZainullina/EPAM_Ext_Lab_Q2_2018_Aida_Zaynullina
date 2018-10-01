using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeSystem.Models.Test
{
    public class TestResultViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Desciption { get; set; }

        public int TotalQuestions { get; set; }

        public int UserAnswered { get; set; }

        public int UserRightAnswered { get; set; }

        public double UserScore
        {
            get
            {
                var score = (UserRightAnswered / (double)TotalQuestions) * 100;
                return score;
            }
        }

        public List<QuestionResultViewModel> QuestionInfo { get; set; } = new List<QuestionResultViewModel>();
    }

    public class QuestionResultViewModel
    {
        public int QuestionId { get; set; }
        public List<string> UserAnswer { get; set; } = new List<string>();
        public List<string> RightAnswer { get; set; } = new List<string>();
    }
}