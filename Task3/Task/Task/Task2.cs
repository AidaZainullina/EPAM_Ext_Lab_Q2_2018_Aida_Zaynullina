namespace Task
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

public class Task2
    {
        /// <summary>
        /// Calc N - number of rows
        /// </summary>
        public static void Calc()
        {
            int programWorks = 1;
            while (programWorks == 1)
            {
                Console.WriteLine("Enter the number N.");
                int n = CheckOfNumber();
                Console.ReadKey();
                Print(n, '*');

                Console.WriteLine("If you want to repeat the task, press 1, back to menu 0:\n");
                int.TryParse(Console.ReadLine(), out programWorks);
                if (programWorks == 1)
                {
                    Console.Clear();
                }
            }
        }
        /// <summary>
        /// Checking number for non-zero
        /// </summary>
        /// <returns></returns>
        public static int CheckOfNumber()
        {
            int.TryParse(Console.ReadLine(), out int n);
            while (n <= 0)
            {
                Console.WriteLine("Enter a positive non-zero value of n");
                int.TryParse(Console.ReadLine(), out n);
            }

            return n;
        }
        /// <summary>
        /// Print strings
        /// </summary>
        /// <param name="n"></param>
        /// <param name="s"></param>
        public static void Print(int n, char s)
        {
            for (int i = 0; i < n; i++)
            {
                int count = i;
                while (count >= 0)
                {
                    Console.Write("{0}", s);
                    count -= 1;
                }

                Console.WriteLine();
            }
        }
    }
}
