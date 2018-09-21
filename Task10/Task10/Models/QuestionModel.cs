using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task10
{
   public class QuestionModel
    {
        public int QuestionId { get; set; }

        public int TestId { get; set; }

        public string Text { get; set; }

        public Dictionary<int, string> AnswerOptions { get; set; }

        public List<string> RightAnswer { get; set; }

        public List<string> UserChoice { get; set; }

        public bool Checkboxed { get; set; }
    }
}
