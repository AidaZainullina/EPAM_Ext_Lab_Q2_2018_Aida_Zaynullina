namespace Task
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

public class Task4
    {
        /// <summary>
        /// Calc 
        /// </summary>
        public static void Calc()
        {
            int programWorks = 1;
            while (programWorks == 1)
            {
                Console.WriteLine("Enter the N - number of triangls");
                int n = CheckOfNumber();
                for (int i = 0; i < n; i++)
                {
                    Print(n, i);
                }

                Console.WriteLine("If you want to repeat the task, press 1, back to menu press any other button:\n");
                int.TryParse(Console.ReadLine(), out programWorks);
                if (programWorks == 1)
                {
                    Console.Clear();
                }
            }
        }
        /// <summary>
        /// Checking length and width testing for non-zero
        /// </summary>
        /// <returns></returns>
        public static int CheckOfNumber()
        {
            int.TryParse(Console.ReadLine(), out int n);
            while (n <= 0)
            {
                Console.WriteLine("Enter a positive non-zero and non-string value of n - number of triangls");
                int.TryParse(Console.ReadLine(), out n);
            }

            return n;
        }
        /// <summary>
        /// Print strings
        /// </summary>
        /// <param name="n">n-number of triangle</param>
        /// <param name="i">i-triangle</param>
        public static void Print(int n, int i)
        {
            int space1 = ((n * 2) - 1) / 2;
            int space2 = i;
            int sign = 1;
            while (space2 > -1)
            {
                Print2(space1, ' ', false);
                Print2(sign, '*', true);
                sign += 2;
                space1--;
                space2--;
            }
        }
        /// <summary>
        /// Print strings
        /// </summary>
        /// <param name="n"></param>
        /// <param name="symbol"></param>
        /// <param name="flag"></param>
        public static void Print2(int n, char symbol, bool flag)
        {
            while (n > 0)
            {
                Console.Write("{0}", symbol);
                n--;
            }

            if (flag)
            {
                Console.WriteLine();
            }
        }
    }
}
