namespace KnowledgeSystemDAL.Models
{
    using System;

    public class Report
    {
        public int Id { get; set; }

        public int UserID { get; set; }

        public int TestId { get; set; }

        public int Score { get; set; }

        public DateTime Date { get; set; }

        public DateTime Duration { get; set; }
    }
}
