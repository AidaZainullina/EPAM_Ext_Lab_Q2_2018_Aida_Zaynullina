namespace Task
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

public class Task10
    {
        private static int summ = 0;

        private static int n = 3;
        /// <summary>
        /// Wotking with program
        /// </summary>
        public static void Array()
        {
            int programWorks = 1;
            while (programWorks == 1)
            {
                int[,] array2D = new int[n, n];
                int maxValue = 1000;
                int minValue = -1000;
                Random(array2D, maxValue, minValue);
                Console.WriteLine("Your random massive is:");
                PrintArray(array2D);
                Sum(array2D);
                Console.WriteLine("Sum of elements that are at even positions is: {0}", summ);

                Console.WriteLine("If you want to repeat the task, press 1, back to menu 0:\n");
                int.TryParse(Console.ReadLine(), out programWorks);
                if (programWorks == 1)
                {
                    Console.Clear();
                }
            }
        }
        /// <summary>
        /// Checking number for non-zero value
        /// </summary>
        /// <returns></returns>
        public static int Check()
        {
            int.TryParse(Console.ReadLine(), out int n);
            while (n <= 0)
            {
                Console.WriteLine("Enter a positive non-zero value");
                int.TryParse(Console.ReadLine(), out n);
            }

            return n;
        }
        /// <summary>
        /// Working with random
        /// </summary>
        /// <param name="array2D"></param>
        /// <param name="max"></param>
        /// <param name="min"></param>
        public static void Random(int[,] array2D, int max, int min)
        {
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    array2D[i, j] = random.Next(min, max);
                }
            }
        }
        /// <summary>
        /// Printing our array
        /// </summary>
        /// <param name="array2D"></param>
        public static void PrintArray(int[,] array2D)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.WriteLine("{0}", array2D[i, j]);
                }
            }
        }
        /// <summary>
        /// Calc Sum
        /// </summary>
        /// <param name="array2D">our 2D array</param>
        /// <returns></returns>
        public static int Sum(int[,] array2D)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if ((i + j) % 2 == 0)
                    {
                        summ += array2D[i, j];
                    }
                }
            }

            return summ;
        }
    }
}
