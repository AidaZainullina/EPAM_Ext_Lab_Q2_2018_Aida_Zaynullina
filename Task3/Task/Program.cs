namespace Task
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

   public class Program
    {
       public static void Main(string[] args)
        {
            bool calculatorWorks = true;
            while (calculatorWorks)
            {
                Console.WriteLine("0: Exit");
                Console.WriteLine("1: Task 1");
                Console.WriteLine("2: Task 2");
                Console.WriteLine("3: Task 3");
                Console.WriteLine("4: Task 4");
                Console.WriteLine("5: Task 5");
                Console.WriteLine("6: Task 6");
                Console.WriteLine("7: Task 7");
                Console.WriteLine("8: Task 8");
                Console.WriteLine("9: Task 9");
                Console.WriteLine("10: Task 10");
                Console.WriteLine("11: Task 11");
                Console.WriteLine("12: Task 12");
                Console.WriteLine("13: Task 13");

                switch (Console.ReadLine())
                {
                    case "0":
                        calculatorWorks = false;
                        break;
                    case "1":
                        Task1.Calc();
                        break;
                    case "2":
                        Task2.Calc();
                        break;
                    case "3":
                        Task3.Calc();
                        break;
                    case "4":
                        Task4.Calc();
                        break;
                    case "5":
                        Task5.Calc();
                        break;
                    case "6":
                        Task6.Styles();
                        break;
                    case "7":
                        Task7.Array();
                        break;
                    case "8":
                        Task8.Array();
                        break;
                    case "9":
                        Task9.Array();
                        break;
                    case "10":
                        Task10.Array();
                        break;
                    case "11":
                        Task11.Calc();
                        break;
                    case "12":
                        Task12.String();
                        break;
                    case "13":
                        Task13.Calc();
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
   }
}
