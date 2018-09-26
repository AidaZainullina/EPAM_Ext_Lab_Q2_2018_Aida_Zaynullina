namespace KnowledgeManagementSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class QuestionEditViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "TestId")]
        public int TestId { get; set; }

        [Display(Name = "Text")]
        public string Text { get; set; }

        [Display(Name = "Success")]
        public Boolean Success { get; set; }
    }
}