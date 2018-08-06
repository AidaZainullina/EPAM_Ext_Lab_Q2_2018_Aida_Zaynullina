namespace Task7
{
    using System;

    public class Program
    {
        /// <summary>
        /// The program menu
        /// </summary>
        /// <param name="args">array</param>
        public static void Main(string[] args)
        {
            bool calculatorWorks = true;
            while (calculatorWorks)
            {
                Console.WriteLine("0: " + Task7.Properties.Resource1.Exit);
                Console.WriteLine("1: " + Task7.Properties.Resource1.Task1Theme);
                Console.WriteLine("2: " + Task7.Properties.Resource1.Task2Theme);
                Console.WriteLine("3: " + Task7.Properties.Resource1.Task3Theme + "\n");

                switch (Console.ReadLine())
                {
                    case "0":
                        calculatorWorks = false;
                        break;
                    case "1":
                        RandomArray.ChoiceOfMethod();
                        break;
                    case "2":
                        MenuOfSecondTask.Check();
                        break;
                    case "3":
                        ThirdTask.MenuOfThirdTask();
                        break;
                    default:
                        {
                            Console.WriteLine("Operation not entered correctly, enter again");
                        }

                        break;
                }
            }
        }
    }
}
