namespace Task7
{
    using System;

    public static class RandomArray
    {
        /// <summary>
        /// Max value of array
        /// </summary>
        private static int maxValue = 1000;

        /// <summary>
        /// Min value of array
        /// </summary>
        private static int minValue = -1000;

        /// <summary>
        /// Selecting a method from two in the first job: either the user sets the size of the array, or takes the default value
        /// </summary>
        public static void ChoiceOfMethod()
        {
            bool programmWorks = true;

            while (programmWorks)
            {
                Console.WriteLine("\n0: " + Task7.Properties.Resource1.Exit);

                Console.WriteLine(Task7.Properties.Resource1.Task1);

                switch (Console.ReadLine())
                {
                    case "0":
                        programmWorks = false;
                        break;
                    case "1":
                        ArrayOfYourSize();
                        break;
                    case "2":
                        ArrayOfOurSize();
                        break;
                    default:
                        {
                            Console.WriteLine("Operation not entered correctly, enter again\n");
                        }

                        break;
                }
            }
        }

        /// <summary>
        /// The functionality of the method in which the user enters the dimension of the array
        /// </summary>
        public static void ArrayOfYourSize()
        {
            int programWorks = 1;

            while (programWorks == 1)
            {
                Console.WriteLine("Enter the size of your array: \n");

                int l = Check();

                int[] array = new int[l];

                Random(array, maxValue, minValue);

                Console.WriteLine("Your random massive is:");

                PrintArray(array);

                array.Sum();

                Console.WriteLine("\nSum of non-negarive elements is: {0}", SumOfArraysElements.FinalSum);

                Console.WriteLine("\nIf you want to repeat the task, press 1, back to menu another button: \n");

                int.TryParse(Console.ReadLine(), out programWorks);

                if (programWorks == 1)
                {
                    Console.Clear();
                }
            }
        }

        /// <summary>
        /// The functionality of the method with fixed dimension of the array
        /// </summary>
        public static void ArrayOfOurSize()
        {
            int n = 250;
            int programWorks = 1;
            while (programWorks == 1)
            {
                int[] array = new int[n];

                int maxValue = 1000;

                int minValue = -1000;

                Random(array, maxValue, minValue);

                Console.WriteLine("\nLength of massive is {0}", n);

                Console.WriteLine("\nYour random massive is:");

                PrintArray(array);

                array.Sum();

                Console.WriteLine("\nSum of non-negarive elements is: {0}", SumOfArraysElements.FinalSum);

                Console.WriteLine("\nIf you want to repeat the task, press 1, back to menu 0: \n");

                int.TryParse(Console.ReadLine(), out programWorks);

                if (programWorks == 1)
                {
                    Console.Clear();
                }
            }
        }

        /// <summary>
        /// Checking of non-zero value of length of array
        /// </summary>
        /// <returns>Returns n - length of array</returns>
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
        /// Random function
        /// </summary>
        /// <param name="array">Our array</param>
        /// <param name="max">Max value of array</param>
        /// <param name="min">Min value of array</param>
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
        /// <param name="array">Our array</param>
        public static void PrintArray(int[] array)
        {
            if (array.Length <= 100)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    Console.WriteLine("{0}", array[i]);
                }
            }
            else
            {
                Console.WriteLine("The length of your array is long so you'll see only the sum");
            }
        }
    }
}
