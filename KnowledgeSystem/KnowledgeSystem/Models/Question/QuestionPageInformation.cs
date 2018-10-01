using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeSystem.Models.Question
{
    public class QuestionPageInformation
    {
        public int TestId { get; set; }

        public int? TestTime { get; set; }

        public int QuestionId { get; set; }

        public int TotalPages { get; set; }
    }
}