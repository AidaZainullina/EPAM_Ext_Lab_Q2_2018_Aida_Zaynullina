namespace Task
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

public class Task3
    {
        public static void Calc()
        {
            int calcWork = 1;
            while (calcWork == 1)
            {
                Console.WriteLine("Enter the N  - number of rows");
                int n = CheckOfNumber();
                int space = ((n * 2) - 1) / 2;
                int sign = 1;
                while (space > -1)
                {
                    Print(space, ' ', false);
                    Print(sign, '*', true);
                    sign += 2;
                    space--;
                }

                Console.WriteLine("If you want to repeat the task, press 1, back to menu press any other button:\n");
                int.TryParse(Console.ReadLine(), out calcWork);
                if (calcWork == 1)
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
                Console.WriteLine("Enter a positive non-zero and non-string value of n");
                int.TryParse(Console.ReadLine(), out n);
            }

            return n;
        }
        /// <summary>
        /// Print strings
        /// </summary>
        /// <param name="n"></param>
        /// <param name="symbol"></param>
        /// <param name="flag"></param>
        public static void Print(int n, char symbol, bool flag)
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
