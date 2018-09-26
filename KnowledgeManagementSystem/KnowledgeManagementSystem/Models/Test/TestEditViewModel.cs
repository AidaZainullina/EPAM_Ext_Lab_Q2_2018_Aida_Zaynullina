namespace KnowledgeManagementSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class TestEditViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Duration")]
        public DateTime Duration { get; set; }
    }
}