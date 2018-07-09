﻿namespace Task
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

public class Task11
    {
        /// <summary>
        /// Working with our program
        /// </summary>
        public static void Calc()
        {
            int programWorks = 1;
            while (programWorks == 1)
            {
                Console.WriteLine("Enter a new line:\n");
                string str = Console.ReadLine();
                AvgLengthOfWord(str);

                Console.WriteLine("If you want to repeat the task, press 1, back to menu press any other button:\n");//todo pn хардкод у тебя это сообщение дублируется многократно. Все строки-сообщения - в ресурсы.
				int.TryParse(Console.ReadLine(), out programWorks);
                if (programWorks == 1)
                {
                    Console.Clear();
                }
            }
        }
        /// <summary>
        /// working with our string
        /// </summary>
        /// <param name="str">string</param>
        public static void AvgLengthOfWord(string str)
        {
            string[] words = str.Split(new[] { ' ', '-', '!', '?', ':', ',', '.' }, StringSplitOptions.RemoveEmptyEntries);//todo pn хардкод
            double avgLength = words.Aggregate(0, (count, nextWord) => count += nextWord.Length) / words.Length;//todo pn упало здесь
            Console.WriteLine("Average length of the words = {0}", avgLength);//todo pn чот он как-то неправильно считает среднюю длину слова
        }
    }
}