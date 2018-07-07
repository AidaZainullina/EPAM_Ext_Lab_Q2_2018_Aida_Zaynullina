namespace Task
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
public class Task13
    {
        private static int n = 100;
       /// <summary>
       /// Working with our program
       /// </summary>
        public static void Calc()
        {
            int programWorks = 1;
            while (programWorks == 1)
            {
                Console.WriteLine("Enter the number of measurements:");
                double numberMeasurements = CheckOfNumber();
                Tests(n, numberMeasurements);

                Console.WriteLine("If you want to repeat the task, press 1, back to menu 0:\n");
                int.TryParse(Console.ReadLine(), out programWorks);
                if (programWorks == 1)
                {
                    Console.Clear();
                }
            }
        }
        /// <summary>
        /// Checking for non-zero value
        /// </summary>
        /// <returns></returns>
        public static double CheckOfNumber()
        {
            double.TryParse(Console.ReadLine(), out double numberMeasurements);
            while (numberMeasurements <= 0)
            {
                Console.WriteLine("Enter a positive non-zero and non-string value of NumberMeasurements");
                double.TryParse(Console.ReadLine(), out numberMeasurements);
            }

            return numberMeasurements;
        }
        /// <summary>
        /// Making test
        /// </summary>
        /// <param name="n"></param>
        /// <param name="numberMeasurements"></param>
        public static void Tests(int n, double numberMeasurements)
        {
            TimeSpan timeString = new TimeSpan(0, 0, 0, 0);
            TimeSpan timeStringBuilder = new TimeSpan(0, 0, 0, 0);

            StreamWriter sw = new StreamWriter("Conclusion.txt");

            for (int i = 0; i < numberMeasurements; i++)
            {
                timeString += TestString(n);
                timeStringBuilder += TestStringBuilder(n);
                n = n * 2;
            }

            Console.WriteLine("If you need to see verage time of measurements, please open Conclusion.txt in this project. Thank you");

            double averageString = timeString.TotalMilliseconds / numberMeasurements;
            double averageStringBuilder = timeStringBuilder.TotalMilliseconds / numberMeasurements;
            sw.WriteLine("Average Time of measurements of String  is {0} milliseconds\n", averageString);
            sw.WriteLine("Average Time of measurements of StringBuilder  is {0} milliseconds\n", averageStringBuilder);
            sw.Close();
        }
        /// <summary>
        /// Testing String
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static TimeSpan TestString(int n)
        {
            var sw = new Stopwatch();
            sw.Start();
            string str = string.Empty;
            for (int i = 0; i < n; i++)
            {
                str += "*";
            }

            sw.Stop();
            Console.WriteLine("Time of measurements of String after *^{0}  :\n{1}", n, sw.Elapsed);

            return sw.Elapsed;
        }
        /// <summary>
        /// Testing StringBuilder
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static TimeSpan TestStringBuilder(int n)
        {
            var sw = new Stopwatch();
            sw.Start();
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                str.Append("*");
            }

            sw.Stop();

            Console.WriteLine("Time of measurements of StringBuilder after *^{0}  :\n{1}", n, sw.Elapsed);
            return sw.Elapsed;
        }
    }
}