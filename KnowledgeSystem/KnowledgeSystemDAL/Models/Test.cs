namespace KnowledgeSystemDAL.Models
{
    using System;

    public class Test
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime? Duration { get; set; }

        public int UserId { get; set; }

        public string Description { get; set; }

        public int Score { get; set; }
    }
}
