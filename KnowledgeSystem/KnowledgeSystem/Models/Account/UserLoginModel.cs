namespace KnowledgeSystem.Models.Account
{
    using System.ComponentModel.DataAnnotations;

    public class UserLoginModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}