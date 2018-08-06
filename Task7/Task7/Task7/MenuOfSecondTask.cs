namespace Task7
{
    using System;

    public class MenuOfSecondTask
    {
        /// <summary>
        /// The Second task's
        /// </summary>
        public static void Check()
        {
            bool programmWorks = true;
            while (programmWorks)
            {
                Console.WriteLine("\n0: " + Task7.Properties.Resource1.Exit);
                Console.WriteLine(Task7.Properties.Resource1.Task2);
                switch (Console.ReadLine())
                {
                    case "0":
                        programmWorks = false;
                        break;
                    case "1":
                        UseYourString();
                        break;
                    case "2":
                        UseOurString();
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
        /// Instantiating a class
        /// </summary>
        public static void UseOurString()
        {
            SecondTaskOurString t2 = new SecondTaskOurString();
        }

        /// <summary>
        /// Instantiating a class
        /// </summary>
        public static void UseYourString()
        {
            SecondTaskYourString t2 = new SecondTaskYourString();
        }
    }
}