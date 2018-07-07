namespace Task
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

public class Task12
    {
        private string str1 = string.Empty;
        private string str2 = string.Empty;
        private string resultStr = string.Empty;
        /// <summary>
        /// working with our strings
        /// </summary>
        public static void String()
        {
            int programWorks = 1;
            while (programWorks == 1)
            {
                Console.WriteLine("Enter the first line:\n");
                string str1 = Console.ReadLine();
                Console.WriteLine("Enter the second line:\n");
                string str2 = Console.ReadLine();
                Doubling(str1, str2);

                Console.WriteLine("If you want to repeat the task, press 1, back to menu 0:\n");
                int.TryParse(Console.ReadLine(), out programWorks);
                if (programWorks == 1)
                {
                    Console.Clear();
                }
            }
        }
          /// <summary>
          /// Making doubling letters
          /// </summary>
          /// <param name="str1"></param>
          /// <param name="str2"></param>
        public static void Doubling(string str1, string str2)
        {
            Letter(str2);
            for (int i = 0; i < str2.Length; i++)
            {
                if (str1.Contains(str2[i]))
                {
                   str1 = str1.Replace(str2[i].ToString(), string.Format("{0}{1}", str2[i], str2[i]));
                }
            }

            Console.WriteLine("Your doubling string is: \n {0}", str1);
        }

        public static void Letter(string str)
        {
            int i = 0;
            while (true)
            {
                var tmp = str[i].ToString();
                str = str.Replace(tmp, string.Empty);
                str = str.Insert(i, tmp);
                i++;
                if (str.Length - 1 < i)
                {
                    break;
                }
            }
        }
    }
}
