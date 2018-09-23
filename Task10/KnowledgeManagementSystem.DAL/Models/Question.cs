namespace Task10
{
    using System.Collections.Generic;

    public class Question
    {
        public int Id { get; set; }

        public Test Test { get; set; }

        public string Text { get; set; }

        public List<Variant> Variant { get; set; }
		
        public bool Success { get; set; }
    }

	public class Variant
    {
        public int Id { get; set; }

        public bool IsRight { get; set; }

        public string Text { get; set; }

        public int Score { get; set; }  

        public VariantType VariantType { get; set; }
	}

	public class VariantType
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
