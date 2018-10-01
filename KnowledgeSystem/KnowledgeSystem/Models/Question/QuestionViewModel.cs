using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeSystem.Models.Question
{
    public class QuestionViewModel
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public int TestID { get; set; }

        public int Success { get; set; }
    }
}