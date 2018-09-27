namespace KnowledgeSystemDAL.Models
{
    public class Role
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public void Saver()
        {
            if (Id == 1)
                Name = "Admin";
            if (Id == 2)
                Name = "User";
        }

        public void Default()
        {
            Id = 2;
            Name = "User";
        }
    }
}
