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

        public TestModel Test { get; set; }

        public string Text { get; set; }

		//list Variants
		//success - пользователь правильно ответил
    }

	class Variant {
		//id
		//bool isRight
		//Text
		//type - radiobutton/checkbox/text
		//points - баллов
		
	}

	class VarianType { }//=Role
}
