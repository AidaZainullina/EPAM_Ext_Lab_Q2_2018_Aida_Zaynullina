namespace KnowledgeManagementSystem.Models.Role
{
    using System.ComponentModel.DataAnnotations;

    public class RoleCreateViewModel
    {
        [Display(Name = "Name")]
        public string Name { get; set; }
    } 
}