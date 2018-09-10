namespace Task7
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    public class ThirdTask
    {
        /// <summary>
        /// Min value for random
        /// </summary>
        private static readonly int MinRandValue = -500;

        /// <summary>
        /// Max value for random
        /// </summary>
        private static readonly int MaxRandValue = 500;

        /// <summary>
        /// Random declaration.
        /// </summary>
        /// 
        private static Random rnd = new Random();

        /// <summary>
        ///  Constructor
        /// </summary>
        public ThirdTask()
        {
            int programWorks = 1;

            while (programWorks == 1)
            {
                int[] arrayOriginal = GenerateArray();

                PrintArray(arrayOriginal, Properties.Resource1.OArray);

                PrintArray(Search(arrayOriginal), Properties.Resource1.Dirict);

                PrintArray(Search(IsPositive, arrayOriginal), Properties.Resource1.Delegate);

                PrintArray(Search(delegate (int x) { return x > 0; }, arrayOriginal), Properties.Resource1.AMethod);

                PrintArray(Search((x) => x > 0, arrayOriginal), Properties.Resource1.LExpression);

                PrintArray(LinqSearch(arrayOriginal), Properties.Resource1.Linq);

                Console.WriteLine("\nIf you want to repeat the task, press 1, back to menu another button: \n");
                int.TryParse(Console.ReadLine(), out programWorks);

                if (programWorks == 1)
                {
                    Console.Clear();
                }
            }
        }

        /// <summary>
        /// Condition delegate.
        /// </summary>
        /// <param name="x">Used value.</param>
        /// <returns>Returns Boolean value.</returns>\
        public delegate bool IsPositiveD(int x);

        /// <summary>
        /// Instance creation
        /// </summary>
        public static void MenuOfThirdTask()
        {
            ThirdTask t3 = new ThirdTask();
        }

        /// <summary>
        /// Generates an array with random elements
        /// </summary>
        /// <param name="size">Size of array</param>
        /// <returns>Returns generated random array</returns>
        public static int[] GenerateArray(int size = 100)
        {
            int[] generatedArray = new int[size];

            for (int i = 0; i < size; i++)
            {
                generatedArray[i] = rnd.Next(MinRandValue, MaxRandValue);
            }

            return generatedArray;
        }

        /// <summary>
        /// The method determines whether the number is positive
        /// </summary>
        /// <param name="x">Condition is right.</param>
        /// <returns>Returns a Boolean value</returns>
        public static bool IsPositive(int x)
        {
            return x > 0;
        }

        /// <summary>
        /// Directly search
        /// </summary>
        /// <param name="originalArray">Original array</param>
        /// <returns>Returns an array after passing condition</returns>
        public static int[] Search(int[] originalArray)
        {
            var filtredArray = new List<int>();

            Stopwatch sw = new Stopwatch();

            sw.Start();

            for (int i = 0; i < originalArray.Length; i++)
            {
                if (IsPositive(originalArray[i]))
                {
                    filtredArray.Add(originalArray[i]);
                }
            }

            sw.Stop();

            Console.Write("\nElapsed time: {0}", sw.ElapsedTicks);

            return filtredArray.ToArray();
        }

        /// <summary>
        /// Search using delegates
        /// </summary>
        /// <param name="condition">Condition</param>
        /// <param name="originalArray">Original array</param>
        /// <returns>Returns an array after passing condition</returns>
        public static int[] Search(IsPositiveD condition, int[] originalArray)
        {
            var filtredArray = new List<int>();

            Stopwatch sw = new Stopwatch();

            sw.Start();

            for (int i = 0; i < originalArray.Length; i++)
            {
                if (condition(originalArray[i]))
                {
                    filtredArray.Add(originalArray[i]);
                }
            }

            sw.Stop();

            Console.Write("\nElapsed time: {0}", sw.ElapsedTicks);

            return filtredArray.ToArray();
        }

        /// <summary>
        /// Search by LINQ expression
        /// </summary>
        /// <param name="originalArray">Original array</param>
        /// <returns>Returns an array after passing condition</returns>
        public static int[] LinqSearch(int[] originalArray)
        {
            Stopwatch sw = new Stopwatch();

            sw.Start();

            var filtredArray = from element in originalArray
                                where element > 0
                                select element;
            sw.Stop();

            Console.Write("\nElapsed time: {0}", sw.ElapsedTicks);

            return filtredArray.ToArray();
        }

        /// <summary>
        /// Print an array to the console
        /// </summary>
        /// <param name="array">Printed array</param>
        /// <param name="name">The string name of array</param>
        public static void PrintArray(int[] array, string name = "NoName")
        {
            Console.Write("\n{0}\n[", name);

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0}\t", array[i]);
            }

            Console.WriteLine("]");
        }
    }
}
