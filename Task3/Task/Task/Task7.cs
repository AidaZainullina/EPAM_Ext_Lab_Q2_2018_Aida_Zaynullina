namespace Task
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

public class Task7
    {
        /// <summary>
        /// Working of program, work with strings
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
                BubbleSort(array);
                Console.WriteLine("Your sorted massive is:");
                PrintArray(array);
                Console.WriteLine("Min value of sorted massive is: " + array[0]);
                Console.WriteLine("Max value of sorted massive is: " + array[array.Length - 1]);

                Console.WriteLine("If you want to repeat the task, press 1, back to menu 0:\n");
                int.TryParse(Console.ReadLine(), out programWorks);
                if (programWorks == 1)
                {
                    Console.Clear();
                }
            }   
        }
        /// <summary>
        /// Checking numbers for non-zero
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
        /// Making random
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
        /// Printing array
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
        /// Sorting
        /// </summary>
        /// <param name="mas">array</param>
        /// <returns></returns>
        public static int[] BubbleSort(int[] mas)
        {
            int t;
            for (int i = 0; i < mas.Length; i++)
            {
                for (int j = i + 1; j < mas.Length; j++)
                {
                    if (mas[i] > mas[j])
                    {
                        t = mas[i];
                        mas[i] = mas[j];
                        mas[j] = t;
                    }
                }
            }

            return mas;
        }
    }
}
