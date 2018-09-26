namespace KnowledgeManagementSystem.Models
{
    using System.ComponentModel.DataAnnotations;

    public class UserCreateViewModel
    {
        [Display(Name = "Login")]
        public string Login { get; set; }

        [Display(Name = "Email")]
         public string Email { get; set; }

        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Role")]
        public string Role { get; set; }
    }
}
