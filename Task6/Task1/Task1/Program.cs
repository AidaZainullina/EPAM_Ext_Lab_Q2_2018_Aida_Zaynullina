namespace Task1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using static Sorting;

    public class Program
    {
        private static string[] fixedArray = { "qwe", "qwert", "abc", "qwerty\n" };

        public delegate bool Сomparison(string string1, string string2);

        public static void Main(string[] args)
        {
            bool programWorks = true;
            while (programWorks)
            {
                Console.WriteLine("0: Exit");
                Console.WriteLine("1: to sort the words we have set");
                Console.WriteLine("2: to sort the words you will enter\n");

                switch (Console.ReadLine())
                {
                    case "0":
                        programWorks = false;
                        break;
                    case "1":
                        SortingOfFixedWords();
                        break;
                    case "2":
                        SortingOfInputWords();
                        break;
                    default:
                        {
                            Console.WriteLine("Operation not entered correctly, enter again");
                        }

                        break;
                }
            }

            Console.ReadKey();
        }
        
        public static void SortingOfFixedWords()
        {
            var comparison = new Сomparison(Sorting.СomparisonMethod);
            Console.WriteLine("\nOur fixed words are: ");
            foreach (string item in fixedArray)
            {
                Console.Write(item + " ");
            }

            Sorting.Sort(fixedArray, comparison, 0, fixedArray.Length - 1);
            Console.WriteLine("\nOur fixed words after sorting are:\n");
            foreach (var string_ in fixedArray)
            {
                Console.WriteLine(string_);
            }
        }

        public static void SortingOfInputWords()
        {
            var comparison = new Сomparison(Sorting.СomparisonMethod);
            string[] inputArray = Input.InputArray();
            Console.WriteLine("\nYour words after sorting are:\n");
            Sorting.Sort(inputArray, comparison, 0, inputArray.Length - 1);
            foreach (var string_ in inputArray)
            {
                Console.WriteLine(string_);
            }

            Console.WriteLine("\n");
        }
    }
}
