namespace Task
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

public class Task5
    {
        /// <summary>
        /// Calc
        /// </summary>
        public static void Calc()
        {
            int programWorks = 1;
            while (programWorks == 1)
            {
                double firstNumber = 3.0;
                double secondNumber = 5.0;
                double sum = 0.0;
                double maxNumber = 1000.0;
                double i;

                for (i = 0.0; i < maxNumber; i++)
                {
                    if ((i % firstNumber == 0) ^ (i % secondNumber == 0))
                    {
                        sum += i;
                    }
                }

                Console.WriteLine("Sum of all numbers less than {0}, multiples of {1} or {2} = {3} ", maxNumber, firstNumber, secondNumber, sum);

                Console.WriteLine("If you want to repeat the task, press 1, back to menu 0:\n");
                int.TryParse(Console.ReadLine(), out programWorks);
                if (programWorks == 1)
                {
                    Console.Clear();
                }
            } 
        }
    }
}
