namespace Task7
{
    using System;

    public class SecondTaskOurString
    {
        /// <summary>
        /// Functionality of the third job with the default string
        /// </summary>
        public SecondTaskOurString()
        {
            int programWorks = 1;
            while (programWorks == 1)
            {
                string[] str = { "1", "2.2", "ghjyd", "-1e10", "0.121887" };
                Console.WriteLine("Your string is: \n");
                for (int i = 0; i < str.Length; i++)
                {
                    Console.WriteLine(str[i]);
                }

                foreach (var element in str)
                {
                    Console.WriteLine(element.FindPositiveNum());
                }

                Console.WriteLine("\nIf you want to repeat the task, press 1, back to menu another button: \n");
                int.TryParse(Console.ReadLine(), out programWorks);
                if (programWorks == 1)
                {
                    Console.Clear();
                }
            }
        }
    }
}
