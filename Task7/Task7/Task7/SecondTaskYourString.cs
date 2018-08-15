namespace Task7
{
    using System;

    public class SecondTaskYourString
    {
        /// <summary>
        /// Functionality of the third task with the string which user print
        /// </summary>
        public SecondTaskYourString()
        {
            int programWorks = 1;
            while (programWorks == 1)
            {
                Console.WriteLine("Enter your line, please");
                string str = Console.ReadLine();
                SplitMethod(str);

                Console.WriteLine("\nIf you want to repeat the task, press 1, back to menu another button: \n");
                int.TryParse(Console.ReadLine(), out programWorks);
                if (programWorks == 1)
                {
                    Console.Clear();
                }
            }
        }

        public static void SplitMethod(string str)
        {
            string[] words = str.Split(new[] { ' ', '-', '!', '?', ':', ',', '.' }, StringSplitOptions.RemoveEmptyEntries);//todo pn хардкод. Есть Char.IsSeparator
			Console.WriteLine("Your string is: \n");
            for (int i = 0; i < words.Length; i++)
            {
                Console.WriteLine(words[i]);
            }

            foreach (var element in words)
            {
                string a = element.ToString();
                Console.WriteLine(a.FindPositiveNum());
            }
        }
    }
}
