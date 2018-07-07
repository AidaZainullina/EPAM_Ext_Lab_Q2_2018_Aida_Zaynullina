namespace Task
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

   public class Task1
    {
        /// <summary>
        /// This method calc square
        /// </summary>
        public static void Calc()
        {
            int programWorks = 1;
            while (programWorks == 1)
            {
                Console.WriteLine("Could you please enter the length of the rectangle?");
                int length = CheckOfNumber();
                Console.WriteLine("Could you please enter the width of the rectangle?");
                int width = CheckOfNumber();
                int areaOfRectangle = length * width;
                Console.WriteLine("The area of the rectangle = {0}", areaOfRectangle);

                Console.WriteLine("If you want to repeat the task, press 1, back to menu press any other button:\n");
                int.TryParse(Console.ReadLine(), out programWorks);
                if (programWorks == 1)
                {
                    Console.Clear();
                }
            }
        }
        /// <summary>
        /// Checking length and width testing for non-zero
        /// </summary>
        /// <returns></returns>
        public static int CheckOfNumber()
        {
            int.TryParse(Console.ReadLine(), out int length);
            while (length <= 0)
            {
                Console.WriteLine("Enter a positive non-zero value");
                int.TryParse(Console.ReadLine(), out length);
            }

            return length;
        }
    }
}
