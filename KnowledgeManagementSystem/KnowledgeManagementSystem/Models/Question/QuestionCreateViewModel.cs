using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KnowledgeManagementSystem.Models
{
    public class QuestionCreateViewModel
    {
        [Display(Name = "TestId")]
        public int TestId { get; set; }

        [Display(Name = "Text")]
        public string Text { get; set; }

        [Display(Name = "Success")]
        public Boolean Success { get; set; }
    }

}