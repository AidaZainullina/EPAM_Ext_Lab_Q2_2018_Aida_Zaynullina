namespace KnowledgeSystemDAL.Models
{
    public class Variant
    {
        public int Id { get; set; }

        public int QuestionId { get; set; }

        public int IsRight { get; set; }

        public string Text { get; set; }

        //public int Score { get; set; }
    }
}
