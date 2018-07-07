namespace Task
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Task9
    {
        private static int summ = 0;
        /// <summary>
        /// Working with array
        /// </summary>
        public static void Array()
        {
            int programWorks = 1;
            while (programWorks == 1)
            {
                Console.WriteLine("Enter the size of array");
                int n = Check();
                int[] array = new int[n];
                int maxValue = 1000;
                int minValue = -1000;
                Random(array, maxValue, minValue);
                Console.WriteLine("Your random massive is:");
                PrintArray(array);
                Sum(array);
                Console.WriteLine("Sum of non-negarive elements is: {0}", summ);

                Console.WriteLine("If you want to repeat the task, press 1, back to menu press any other button:\n");
                int.TryParse(Console.ReadLine(), out programWorks);
                if (programWorks == 1)
                {
                    Console.Clear();
                }
            } 
        }
        /// <summary>
        /// Checking numbers  for non-zero
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
        /// <param name="array"></param>
        /// <param name="max"></param>
        /// <param name="min"></param>
        public static void Random(int[] array, int max, int min)
        {
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(min, max);
            }
        }
        /// <summary>
        /// Print our array
        /// </summary>
        /// <param name="array"></param>
        public static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine("{0}", array[i]);
            }
        }
        /// <summary>
        /// Calc sum
        /// </summary>
        /// <param name="array">our array</param>
        /// <returns></returns>
        public static int Sum(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] >= 0)
                {
                    summ += array[i];
                }
            }

            return summ;
        }
    }
}