using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeSystem.Models.Variant
{
    public class VariantViewModel
    {
        public int Id { get; set; }

        public int QuestionId { get; set; }

        public int IsRight { get; set; }

        public string Text { get; set; }
    }
}