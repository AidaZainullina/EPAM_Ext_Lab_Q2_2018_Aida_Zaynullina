using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KnowledgeManagementSystem.Models
{
    public class TestCreateViewModel
    {
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Duration")]
        public DateTime Duration { get; set; }
    }
}