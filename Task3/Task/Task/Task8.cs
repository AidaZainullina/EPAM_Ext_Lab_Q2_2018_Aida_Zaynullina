namespace Task
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

 public class Task8
    {
       private static int n = 4;
        /// <summary>
        /// working with array
        /// </summary>
        public static void Array()
        {
            int programWorks = 1;
            while (programWorks == 1)
            {
                n = Check();
                int[,,] array3D = new int[n, n, n];
                int max = 1000;
                int min = -1000;
                Random(array3D, max, min);
                Console.WriteLine("Your random massive is:");
                PrintArray(array3D);
                ChangePositive(array3D);
                Console.WriteLine("Your change massive is:");
                PrintArray(array3D);

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
            int.TryParse(Console.ReadLine(), out int N);
            while (N <= 0)
            {
                Console.WriteLine("Enter a positive non-zero value");
                int.TryParse(Console.ReadLine(), out N);
            }

            return N;
        }
        /// <summary>
        /// Doing random
        /// </summary>
        /// <param name="array3D"></param>
        /// <param name="max"></param>
        /// <param name="min"></param>
        public static void Random(int[,,] array3D, int max, int min)
        {
            Random random = new Random();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        array3D[i, j, k] = random.Next(min, max);
                    }
                }
            }
        }
        /// <summary>
        /// Print our array
        /// </summary>
        /// <param name="array3D"></param>
        public static void PrintArray(int[,,] array3D)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        Console.WriteLine("{0}", array3D[i, j, k]);
                    }
                }
            }
        }
        /// <summary>
        /// Change positive numbers to zero
        /// </summary>
        /// <param name="array3D"></param>
        public static void ChangePositive(int[,,] array3D)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        if (array3D[i, j, k] > 0)
                        {
                            array3D[i, j, k] = 0;  
                        }
                    }
                }
            }
        }
    } 
}
